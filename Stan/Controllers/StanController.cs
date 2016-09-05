using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stan.Models;
using Stan.SQLData;
using System.Diagnostics;

namespace Stan.Controllers
{
    public class StanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stan
        public ActionResult Index()
        {
            List<SQLData.Stan> s = db.Stans.ToList();
            s.Reverse();
            return View(s);
        }

        // POST: Search
        [HttpPost]
        public ActionResult Search(string Lokacija, string KvadraturaOd, string KvadraturaDo, string CenaOd, string CenaDo) {

            int kvOd = 0;
            int kvDo = int.MaxValue;
            int.TryParse(KvadraturaOd, out kvOd);
            int.TryParse(KvadraturaDo, out kvDo);

            int ceOd = 0;
            int ceDo = int.MaxValue;
            int.TryParse(CenaOd, out ceOd);
            int.TryParse(CenaDo, out ceDo);

            IEnumerable<Stan.SQLData.Stan> Results = from stan in db.Stans
                                         where stan.Kvadratura >= kvOd &&
                                         stan.Kvadratura <= kvDo &&
                                         stan.Cena >= ceOd &&
                                         stan.Cena <= ceDo &&
                                         stan.Lokacija == Lokacija
                                         orderby stan.Cena ascending
                                         select stan;
            
            return View(Results);
        }

        // GET: Mine
        [Authorize]
        public ActionResult Mine() {
            return View(from stan in db.Stans where stan.GazdaId == User.Identity.Name select stan);
        }

        // GET: Stan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SQLData.Stan stan = db.Stans.Find(id);
            if (stan == null)
            {
                return HttpNotFound();
            }
            return View(stan);
        }

        // GET: Stan/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Kvadratura,BrojNaSobi,NaKojSprat,ImaLift,ImaKujna,ImaToalet,ImaTerasa,Namesten,DatumObjaven,KontaktIme,KontaktBroj,Lokacija,Opis,Cena")] SQLData.Stan stan, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                stan.GazdaId = User.Identity.Name;
                stan.DatumObjaven = DateTime.Now;
                db.Stans.Add(stan);
                db.SaveChanges();

                if (file != null && file.ContentLength > 0) {
                    //string Filename = stan.Id + "_" + stan.GazdaId + "." + file.FileName.Split('.').Last();
                    string Filename = stan.Id + "_" + stan.GazdaId + ".jpg";
                    string SavePath = Server.MapPath("~/Images/") + Filename;
                    Debug.WriteLine("Save: " + SavePath);
                    file.SaveAs(SavePath);
                }

                return RedirectToAction("Index");
            }

            return View(stan);
        }

        // GET: Stan/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SQLData.Stan stan = db.Stans.Find(id);
            if (stan == null)
            {
                return HttpNotFound();
            }
            return View(stan);
        }

        // POST: Stan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,GazdaId,Kvadratura,BrojNaSobi,NaKojSprat,ImaLift,ImaKujna,ImaToalet,ImaTerasa,Namesten,DatumObjaven,KontaktIme,KontaktBroj,Lokacija,Opis,Cena")] SQLData.Stan stan)
        {
            if (ModelState.IsValid)
            {
                stan.GazdaId = User.Identity.Name;
                stan.DatumObjaven = DateTime.Now;
                db.Entry(stan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stan);
        }

        // GET: Stan/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SQLData.Stan stan = db.Stans.Find(id);
            if (stan == null)
            {
                return HttpNotFound();
            }
            return View(stan);
        }

        // POST: Stan/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SQLData.Stan stan = db.Stans.Find(id);
            db.Stans.Remove(stan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetPesrons()
        {
            StanoviDB e = new StanoviDB();
            var result = e.Stans.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
