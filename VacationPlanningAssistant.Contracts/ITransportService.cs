using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlanningAssistant.Models;

namespace VacationPlanningAssistant.Contracts
{
    public interface ITransportService
    {
        bool CreateTransport(TransportCreate model);
        IEnumerable<TransportListItem> GetTransports();
        TransportDetail GetTransportById(int id);
        bool UpdateTransport(TransportEdit model);
        bool DeleteTransport(int transportId);
    }
}
