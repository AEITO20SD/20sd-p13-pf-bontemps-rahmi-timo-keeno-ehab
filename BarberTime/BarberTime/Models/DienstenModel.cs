using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;

namespace BarberTime.Models
{
    public class DienstenModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Length { get; set; }

        [MaxLength(250)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }
    }
}
