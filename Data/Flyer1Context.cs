using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Flyer1.Models;

namespace Flyer1.Data
{
    public class Flyer1Context : DbContext
    {
        public Flyer1Context (DbContextOptions<Flyer1Context> options)
            : base(options)
        {
        }

        public DbSet<Flyer1.Models.Bilet> Bilet { get; set; }

        public DbSet<Flyer1.Models.Companie> Companie { get; set; }

        public DbSet<Flyer1.Models.Pachet> Clasa { get; set; }
    }
}
