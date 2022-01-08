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

namespace Flyer1.Pages.Pachete
{
    public class EditModel : PageModel
    {
        private readonly Flyer1.Data.Flyer1Context _context;

        public EditModel(Flyer1.Data.Flyer1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Pachet Pachet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pachet = await _context.Clasa.FirstOrDefaultAsync(m => m.ID == id);

            if (Pachet == null)
            {
                return NotFound();
            }
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

            _context.Attach(Pachet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PachetExists(Pachet.ID))
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

        private bool PachetExists(int id)
        {
            return _context.Clasa.Any(e => e.ID == id);
        }
    }
}
