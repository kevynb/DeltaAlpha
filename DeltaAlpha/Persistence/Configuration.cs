using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using DeltaAlpha.Models;

namespace DeltaAlpha.Persistence
{
    public class Configuration : DbMigrationsConfiguration<DeltaAlphaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
    }
}