using System;
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
    public class IndexModel : PageModel
    {
        private readonly Flyer1.Data.Flyer1Context _context;

        public IndexModel(Flyer1.Data.Flyer1Context context)
        {
            _context = context;
        }

        public IList<Companie> Companie { get;set; }

        public async Task OnGetAsync()
        {
            Companie = await _context.Companie.ToListAsync();
        }
    }
}
