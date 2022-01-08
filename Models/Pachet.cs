using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flyer1.Models
{
    public class Pachet
    {
        public int ID { get; set; }
        public string Nume_Pachet { get; set; }
        public ICollection<BiletPachet> BiletPachet  { get; set; }
    }
}
