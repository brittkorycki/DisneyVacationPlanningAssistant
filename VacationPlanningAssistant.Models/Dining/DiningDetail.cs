using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Models
{
    public class DiningDetail
    {
        public int DiningId { get; set; }
        public string Id { get; set; }
        [Display(Name = "Restaurant Name")]
        public string NameOfRestaurant { get; set; }
        [Display(Name = "Park/Area")]
        public string Location { get; set; }
        public DateTime ReservationTime { get; set; }
        public int ReservationNumber { get; set; }
    }
}
