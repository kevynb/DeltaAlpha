using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeltaAlpha.Models
{
    public class DeltaAlphaDbContext : DbContext
    {
        public DbSet<PledgeClass> PledgeClasses { get; set; }
        public DbSet<Brother> Brothers { get; set; }
        public DbSet<Family> Families { get; set; }
    }
}