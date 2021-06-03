using DOTZ.Desafio.DAL.Interface.EntitieMappers;
using DOTZ.Desafio.DAL.Interface.Entities;
using Microsoft.EntityFrameworkCore;

namespace DOTZ.Desafio.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discharge> Discharges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Location>(new LocationMap().Configure);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
            modelBuilder.Entity<Discharge>(new DischargeMap().Configure);
        }

    }
}

