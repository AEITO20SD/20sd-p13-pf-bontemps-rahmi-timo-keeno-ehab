using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;
using System.ComponentModel.DataAnnotations;

namespace BarberTime.Models
{
    [Table("Populaire_kapsels")]
    public class PopulairHaircut
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Naam { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public Uri Afbeelding { get; set; }

    }
}
