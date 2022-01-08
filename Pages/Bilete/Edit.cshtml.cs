using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flyer1.Data;
using Flyer1.Models;

namespace Flyer1.Pages.Bilete
{
    public class EditModel : PageModel
    {
        private readonly Flyer1.Data.Flyer1Context _context;

        public EditModel(Flyer1.Data.Flyer1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Bilet Bilet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bilet = await _context.Bilet.FirstOrDefaultAsync(m => m.ID == id);

            if (Bilet == null)
            {
                return NotFound();
            }
            ViewData["CompanierID"] = new SelectList(_context.Set<Companie>(), "ID", "Nume_Companie");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bilet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiletExists(Bilet.ID))
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

        private bool BiletExists(int id)
        {
            return _context.Bilet.Any(e => e.ID == id);
        }
    }
}
