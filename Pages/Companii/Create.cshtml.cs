using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Flyer1.Data;
using Flyer1.Models;

namespace Flyer1.Pages.Companii
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
            return Page();
        }

        [BindProperty]
        public Companie Companie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Companie.Add(Companie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
