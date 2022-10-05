using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberTime.Models
{
    public class CreateAccount
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public string Email { get; set; }

        public string Wachtwoord { get; set; }    

        public string TelefoonNummer { get; set; }


    }
}
