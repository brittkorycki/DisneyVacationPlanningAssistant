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
        public string Name { get; set; }
        public DateTime CheckIn { get; set; }
        public int AccomodationReservationNumber { get; set; }
        public string NameOfRestaurant { get; set; }
        public DateTime ReservationTime { get; set; }
        public int DiningReservationNumber { get; set; }
    }
}
