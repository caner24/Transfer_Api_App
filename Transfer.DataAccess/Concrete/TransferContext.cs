using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Transfer.DataAccess.Concrete.Configuration;
using Transfer.Entity;

namespace Transfer.DataAccess.Concrete
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
        public DbSet<ExtraServices> ExtraServices { get; set; }
        public DbSet<GenericData> GenericData { get; set; } 
        public DbSet<PointBase> PointBase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
<<<<<<< HEAD:Transfer.DataAccess/Concrate/TransferContext.cs
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
=======

            modelBuilder.Entity<Vehicle>().Property(x => x.ProviderId).HasValueGenerator<GuidGenerator>();
            modelBuilder.Entity<Vehicle>().Property(x => x.Date).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.PickUpPoint);
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.DropOffPoint);
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.GenericData);
            modelBuilder.Entity<Vehicle>().OwnsOne(x => x.ExtraServices);
>>>>>>> 93142dee3406f2448a5d4b5d691f3cd5d7ec5b69:Transfer.DataAccess/Concrete/TransferContext.cs
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:transferdb.database.windows.net,1433;Initial Catalog=transferdb;Persist Security Info=False;User ID=demouser;Password=123456-Sa;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
