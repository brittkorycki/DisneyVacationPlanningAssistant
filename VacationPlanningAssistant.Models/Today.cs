using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Models
{
    public class Today
    {
        public DateTime Departure { get; set; }
        public int TransportReservationNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public int AccomodationReservationNumber { get; set; }
        public DateTime ReservationTime { get; set; }
        public int DiningReservationNumber { get; set; }
    }
}
