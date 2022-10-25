using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberTime.Models
{
    internal class Product
    {
        public int Id { get; set; };
        public string Name { get; set; }
        public string Description { get; set; }
        public int InvAmount { get; set; }
        public string ForHairtype { get; set; }
    }
}
