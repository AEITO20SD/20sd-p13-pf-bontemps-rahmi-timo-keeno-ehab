using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;
using System.ComponentModel.DataAnnotations;

namespace BarberTime.Models
{
    [Table("Populaire_kapsels")]
    public class KapselLike
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }

        [Required]
        public int CreateAccountId { get; set; }

        [Required]
        public int KapselsId { get; set; }
    }
}
