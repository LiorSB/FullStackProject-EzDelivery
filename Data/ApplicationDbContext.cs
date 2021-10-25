using EzD.Model;
using EzD_App.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EzD_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<DeliveryGuy> DeliveryGuy { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<DeliveryProposal> DeliveryProposals { get; set; }
        public DbSet<ApprovedDelivery> ApprovedDelivery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApprovedDelivery>()
                .HasKey(ad => new { ad.DeliveryID });

            modelBuilder.Entity<DeliveryProposal>()
                .HasKey(dp => new { dp.ProposalID });

            modelBuilder.Entity<CreditCard>()
                .HasKey(table => new { table.CCNum });

            modelBuilder.Entity<User>().HasOne(user => user.IdentityUser);

            modelBuilder.Entity<User>()
                .HasMany(u => u.MyPackages).WithOne(p => p.Owner);
        }
    }
}
