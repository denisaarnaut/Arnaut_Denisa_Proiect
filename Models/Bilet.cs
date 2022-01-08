using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyer1.Models
{
    public class Bilet
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Destinatie { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public DateTime Data { get; set; }

        public int CompanieID { get; set; }
        public Companie Companie { get; set; }
        public ICollection<BiletPachet> BiletPachet { get; set; }
    }
}
