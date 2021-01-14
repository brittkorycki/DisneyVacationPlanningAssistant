using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Models
{
    public class TransportListItem
    {
        public int TransportId { get; set; }
        public string Id { get; set; }

        public string Type { get; set; }

        public DateTime Departure { get; set; }
        [Display(Name = "Reservation Number")]
        public int ReservationNumber { get; set; }
    }
}
