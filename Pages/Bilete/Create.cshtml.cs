using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Flyer1.Data;
using Flyer1.Models;

namespace Flyer1.Pages.Bilete
{
    public class CreateModel : PageModel
    {
        private readonly Flyer1.Data.Flyer1Context _context;

        public CreateModel(Flyer1.Data.Flyer1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CompanieID"] = new SelectList(_context.Set<Companie>(), "ID", "Nume_Companie");
            return Page();
        }

        [BindProperty]
        public Bilet Bilet { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bilet.Add(Bilet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
