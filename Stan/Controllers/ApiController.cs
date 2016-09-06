using Stan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Stan.Controllers
{
    public class ApiController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Get/howMany
        public string Get(int howMany) {
            if (howMany == 1) {
                return new JavaScriptSerializer().Serialize(db.Stans.First());
            } else if (howMany > 1) {
                return new JavaScriptSerializer().Serialize(db.Stans.Take(howMany).ToList());
            }
            return "Error: use howMany = 1 or bigger! \n" +
                "Example: ../Api/Get?howMany=3";
        }

        // GET: PieChart
        public string PieChart() {

            Dictionary<string, double> dict = new Dictionary<string, double>();

            var stanovi = db.Stans.ToList();

            foreach (var s in stanovi) {
                if (dict.ContainsKey(s.Lokacija)) {
                    ++dict[s.Lokacija];
                } else {
                    dict.Add(s.Lokacija, 1);
                }
            }

            return new JavaScriptSerializer().Serialize(dict);
        }
    }
}