using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlanningAssistant.Data;
using VacationPlanningAssistant.Models;
using VacationPlanningAssistant.Contracts;


namespace VacationPlanningAssistant.Services
{
    public class TransportService : ITransportService
    {
        private readonly Guid _userId;
        public TransportService(Guid userId)
        {
            _userId = userId;
        }

        public TransportService()
        {

        }

        public bool CreateTransport(TransportCreate model)
        {
            var entity =
                new Transport()
                {
                    Type = model.Type,
                    Id = model.Id,
                    Departure = model.Departure,
                    ReservationNumber = model.ReservationNumber
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transports.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<TransportListItem> GetTransports()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transports
                        .Where(e => e.TransportId == e.TransportId && e.Id == _userId.ToString())
                        .Select(
                            e =>
                                new TransportListItem
                                {
                                    TransportId = e.TransportId,
                                    Type = e.Type,
                                    Departure = e.Departure,
                                    ReservationNumber = e.ReservationNumber
                                }
                        );

                return query.ToArray();
            }
        }

        public TransportDetail GetTransportById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                
                var entity =
                    ctx
                        .Transports
                        .Single(e => e.TransportId == id);
                return
                    new TransportDetail
                    {
                        TransportId = entity.TransportId,
                        Type = entity.Type,
                        Departure = entity.Departure,
                        ReservationNumber = entity.ReservationNumber
                    };
            }
        }

        public bool UpdateTransport(TransportEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transports
                    .Single(e => e.TransportId == model.TransportId);

                entity.TransportId = model.TransportId;
                entity.Type = model.Type;
                entity.Departure = model.Departure;
                entity.ReservationNumber = model.ReservationNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransport(int transportId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Transports
                    .Single(e => e.TransportId == transportId);

                ctx.Transports.Remove(entity);


                return ctx.SaveChanges() == 1;
            }
        }
    }
}
