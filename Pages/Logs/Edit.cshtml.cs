using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoCatalog.Data;
using AutoCatalog.Models;

namespace AutoCatalog.Pages.Logs
{
    public class EditModel : PageModel
    {
        private readonly AutoCatalog.Data.AutoCatalogContext _context;

        public EditModel(AutoCatalog.Data.AutoCatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Log).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogExists(Log.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LogExists(int id)
        {
            return _context.Log.Any(e => e.ID == id);
        }
    }
}
