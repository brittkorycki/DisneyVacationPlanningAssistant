using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Models
{
    public class DiningEdit
    {
        public int DiningId { get; set; }
        public string Id { get; set; }
        [Required]
        [Display(Name = "Restaurant Name")]
        public string NameOfRestaurant { get; set; }
        [Display(Name = "Park/Area")]
        public string Location { get; set; }
        [Required]
        public DateTime ReservationTime { get; set; }
        [Required]
        public int ReservationNumber { get; set; }
    }
}
