using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberTime.Models.Agenda
{
    [Table("Reservation")]
    public class Reservation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }
    }
}
