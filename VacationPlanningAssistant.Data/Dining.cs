using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Data
{
    public class Dining
    {
        [Key]
        public int DiningId { get; set; }
        [Required]
        [Display(Name = "Restaurant Name")]
        public string NameOfRestaurant { get; set; }
        [Display(Name = "Park/Area")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Reservation Time")]
        public DateTime ReservationTime { get; set; }
        [Required]
        [Display(Name = "Reservation Name")]
        public int ReservationNumber { get; set; }
    }
}
