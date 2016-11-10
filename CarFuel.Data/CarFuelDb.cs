using CarFuel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Data {
    public class CarFuelDb : DbContext {

        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder
                  .Entity<Car>()
                  .Property(t => t.Modal)
                  .HasColumnAnnotation("AuthorName", "Veerakit T");
        }
    }
}
