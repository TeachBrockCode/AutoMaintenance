using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoCatalog.Data;
using AutoCatalog.Models;

namespace AutoCatalog.Pages.Logs
{
    public class CreateModel : PageModel
    {
        private readonly AutoCatalog.Data.AutoCatalogContext _context;

        public CreateModel(AutoCatalog.Data.AutoCatalogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VehicleID"] = new SelectList(_context.Vehicle.OrderBy(a => a.Model), "ID", "Model");
            return Page();
        }

        [BindProperty]
        public Log Log { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Log.Add(Log);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
