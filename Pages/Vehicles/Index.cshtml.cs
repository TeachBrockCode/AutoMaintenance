using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCatalog.Data;
using AutoCatalog.Models;

namespace AutoCatalog.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly AutoCatalog.Data.AutoCatalogContext _context;

        public IndexModel(AutoCatalog.Data.AutoCatalogContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get;set; }

        public async Task OnGetAsync()
        {
            Vehicle = await _context.Vehicle.ToListAsync();
        }
    }
}
