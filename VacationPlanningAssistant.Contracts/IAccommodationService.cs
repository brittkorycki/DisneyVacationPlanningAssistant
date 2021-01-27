using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlanningAssistant.Models;

namespace VacationPlanningAssistant.Contracts
{
    public interface IAccommodationService
    {
        bool CreateAccommodation(AccommodationCreate model);
        IEnumerable<AccommodationListItem> GetAccommodations();
        AccommodationDetail GetAccommodationById(int id);
        bool UpdateAccommodation(AccommodationEdit model);
        bool DeleteAccommodation(int accommodationId);
    }
}
