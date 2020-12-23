using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Models
{
    public class TransportCreate
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        public int ReservationNumber { get; set; }

    }
}
