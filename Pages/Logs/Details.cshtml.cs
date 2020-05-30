using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoCatalog.Data;
using AutoCatalog.Models;

namespace AutoCatalog.Pages.Logs
{
    public class DetailsModel : PageModel
    {
        private readonly AutoCatalog.Data.AutoCatalogContext _context;

        public DetailsModel(AutoCatalog.Data.AutoCatalogContext context)
        {
            _context = context;
        }

        public Log Log { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Log = await _context.Log.FirstOrDefaultAsync(m => m.ID == id);

            if (Log == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
