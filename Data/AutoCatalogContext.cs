using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoCatalog.Models;

namespace AutoCatalog.Data
{
    public class AutoCatalogContext : DbContext
    {
        public AutoCatalogContext (DbContextOptions<AutoCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<AutoCatalog.Models.Vehicle> Vehicle { get; set; }

        public DbSet<AutoCatalog.Models.Log> Log { get; set; }
    }
}
