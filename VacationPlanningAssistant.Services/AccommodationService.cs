
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
    public class AccommodationService : IAccommodationService
    {
        private readonly Guid _userId;
        public AccommodationService(Guid userId)
        {
            _userId = userId;
        }

        public AccommodationService()
        {
        }

        public bool CreateAccommodation(AccommodationCreate model)
        {
            var entity =
                new Accommodation()
                {
                    Name = model.Name,
                    Id = model.Id,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    ReservationNumber = model.ReservationNumber,
                    CheckIn = model.CheckIn,
                    CheckOut = model.CheckOut
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Accommodations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<AccommodationListItem> GetAccommodations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Accommodations
                        .Where(e => e.AccommodationId == e.AccommodationId && e.Id == _userId.ToString())
                        .Select(
                            e =>
                                new AccommodationListItem
                                {
                                    AccommodationId = e.AccommodationId,
                                    Id = e.Id,
                                    Name = e.Name,
                                    StreetAddress = e.StreetAddress,
                                    City = e.City,
                                    State = e.State,
                                    ZipCode = e.ZipCode,
                                    ReservationNumber = e.ReservationNumber,
                                    CheckIn = e.CheckIn,
                                    CheckOut = e.CheckOut
                                }
                        );

                return query.ToArray();
            }
        }

        public AccommodationDetail GetAccommodationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accommodations
                        .Single(e => e.AccommodationId == id);
                return
                    new AccommodationDetail
                    {
                        AccommodationId = entity.AccommodationId,
                        Id  = entity.Id,
                        Name = entity.Name,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State,
                        ZipCode = entity.ZipCode,
                        ReservationNumber = entity.ReservationNumber,
                        CheckIn = entity.CheckIn,
                        CheckOut = entity.CheckOut
                    };
            }
        }

        public bool UpdateAccommodation(AccommodationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Accommodations
                    .Single(e => e.AccommodationId == model.AccommodationId);

                entity.AccommodationId = model.AccommodationId;
                entity.Name = model.Name;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.ReservationNumber = model.ReservationNumber;
                entity.CheckIn = model.CheckIn;
                entity.CheckOut = model.CheckOut;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAccommodation(int accommodationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Accommodations
                    .Single(e => e.AccommodationId == accommodationId);

                ctx.Accommodations.Remove(entity);


                return ctx.SaveChanges() == 1;
            }
        }
    }
}
