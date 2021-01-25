using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlanningAssistant.Models
{
    public class AccommodationDetail
    {
        public int AccommodationId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Use official two (2) letter state abbreviation")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name = "Reservation Number")]
        public int ReservationNumber { get; set; }
        [Display(Name = "Check-In")]
        public DateTime CheckIn { get; set; }
        [Display(Name = "Check-Out")]
        public DateTime CheckOut { get; set; }
    }
}
