using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Transfer.DataAccess.Concrate.Configuration;
using Transfer.Entity;

namespace Transfer.DataAccess.Concrate
{
    public class TransferContext : DbContext
    {
        public TransferContext()
        {

        }
        public TransferContext(DbContextOptions<TransferContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<DropOffPoint> MyProperty { get; set; }
        public DbSet<ExtraServices> ExtraServices { get; set; }
        public DbSet<GenericData> GenericData { get; set; }
        public DbSet<PickUpPoint> PickUpPoint { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Vehicle>().Property(x => x.ProviderId).HasValueGenerator<GuidGenarator>();
            modelBuilder.Entity<Vehicle>().Property(x => x.Date).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.PickUpPoint);
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.DropOffPoint);
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.GenericData);
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.ExtraServices);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
