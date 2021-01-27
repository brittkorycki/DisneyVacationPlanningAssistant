using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlanningAssistant.Models;


namespace VacationPlanningAssistant.Contracts
{
    public interface IDiningService
    {
        bool CreateDining(DiningCreate model);
        IEnumerable<DiningListItem> GetDinings();
        DiningDetail GetDiningById(int id);
        bool UpdateDining(DiningEdit model);
        bool DeleteDining(int diningId);
    }
}
