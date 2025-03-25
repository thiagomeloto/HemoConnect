using HemoConnect.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Infrastructure.Persistence
{
    public class HemoConnectDbContext : DbContext
    {
        public HemoConnectDbContext(DbContextOptions<HemoConnectDbContext> options) : base(options) { }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<Donation> Donation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "HemoConnectCS",
                    b => b.MigrationsAssembly("HemoConnect.Infrastructure") //Define onde as migrações serão salvas
                );
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DonorConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new BloodStockConfiguration());
            modelBuilder.ApplyConfiguration(new DonationConfiguration());
        }
    }
}
