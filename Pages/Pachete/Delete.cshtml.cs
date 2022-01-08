using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Flyer1.Data;
using Flyer1.Models;

namespace Flyer1.Pages.Pachete
{
    public class DeleteModel : PageModel
    {
        private readonly Flyer1.Data.Flyer1Context _context;

        public DeleteModel(Flyer1.Data.Flyer1Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pachet = await _context.Clasa.FindAsync(id);

            if (Pachet != null)
            {
                _context.Clasa.Remove(Pachet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
