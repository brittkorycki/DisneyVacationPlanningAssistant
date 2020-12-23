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
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Use official two (2) letter state abbreviation")]
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int ReservationNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
