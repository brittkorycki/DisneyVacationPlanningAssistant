using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Models
{
    public class TransportDetail
    {
        public int TransportId { get; set; }
        public string Type { get; set; }
        public DateTime Departure { get; set; }
        public int ReservationNumber { get; set; }
    }
}
