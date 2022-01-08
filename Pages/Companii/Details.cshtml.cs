﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Flyer1.Data;
using Flyer1.Models;

namespace Flyer1.Pages.Companii
{
    public class DetailsModel : PageModel
    {
        private readonly Flyer1.Data.Flyer1Context _context;

        public DetailsModel(Flyer1.Data.Flyer1Context context)
        {
            _context = context;
        }

        public Companie Companie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Companie = await _context.Companie.FirstOrDefaultAsync(m => m.ID == id);

            if (Companie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
