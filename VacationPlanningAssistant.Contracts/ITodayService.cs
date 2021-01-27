using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlanningAssistant.Data;

namespace VacationPlanningAssistant.Contracts
{
    public interface ITodayService
    {
        IEnumerable<Transport> GetTodaysTransports();
        IEnumerable<Accommodation> GetTodaysAccommodations();
        IEnumerable<Dining> GetTodaysDinings();
    }
}
