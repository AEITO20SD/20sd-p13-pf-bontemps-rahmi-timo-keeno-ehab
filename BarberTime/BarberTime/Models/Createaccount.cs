using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace BarberTime.Models
{
    [Table("createAccount")]
    public class Createaccount
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Naam { get; set; }

        [MaxLength(250)]
        [Required]
        public string Email { get; set; }

        [MaxLength(250)]
        [Required]
        public string Wachtwoord { get; set; }

        public string TelefoonNummer { get; set; }


    }
}
