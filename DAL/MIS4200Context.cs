using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EA446115_MIS4200.Models;
using System.Data.Entity;

namespace EA446115_MIS4200.DAL
{
    public class MIS4200Context : DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MIS4200Context, EA446115_MIS4200.Migrations.MISContext.Configuration>("DefaultConnection"));
        }
        public DbSet<Flyer> Flyer { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Airplane> Airplane { get; set; }
        public DbSet<FlightDetail> FlightDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}