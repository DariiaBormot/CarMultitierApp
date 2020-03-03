using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CarContext : DbContext 
    {
        public CarContext() : base(@"Data Source=.\MSSQLSERVER1;Initial Catalog=CarsDataBase;Integrated Security=True") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarContext, DataAccessLayer.Migrations.Configuration>());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DetailType> DetailTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>()
                .HasMany(d => d.Details)
                .WithRequired(c => c.Car);

            modelBuilder.Entity<Detail>()
               .HasRequired(c => c.Car)
               .WithMany(c => c.Details)
               .HasForeignKey(k => k.CarId);

        }

    }
}
