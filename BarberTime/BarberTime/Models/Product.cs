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
    [Table("Products")]
    internal class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int InvAmount { get; set; }
        [Required]
        public string ForHairtype { get; set; }
    }
}
