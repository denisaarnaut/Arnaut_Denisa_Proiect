using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flyer1.Models
{
    public class BiletPachet
    {
        public int ID { get; set; }
        public int BiletID { get; set; }
        public Bilet Bilet { get; set; }
        public int PachetID { get; set; }

        public Pachet Pachet { get; set; }
    }
}
