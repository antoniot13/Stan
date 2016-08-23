namespace Stan.SQLData {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StanoviDB : DbContext {
        public StanoviDB()
            : base("name=StanoviDB") {
        }

        public virtual DbSet<Stan> Stans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}
