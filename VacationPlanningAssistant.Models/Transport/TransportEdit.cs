using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Models
{
    public class TransportEdit
    {
        public int TransportId { get; set; }
        public string Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        [Display(Name = "Reservation Number")]
        public int ReservationNumber { get; set; }
    }
}
