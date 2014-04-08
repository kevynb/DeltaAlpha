using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DeltaAlpha.Persistence;

namespace DeltaAlpha.Models
{
    public class DeltaAlphaDbContext : DbContext
    {
        public DeltaAlphaDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<PledgeClass> PledgeClasses { get; set; }
        public DbSet<Brother> Brothers { get; set; }
        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DeltaAlphaDbContext, Configuration>());
        }
    }
}