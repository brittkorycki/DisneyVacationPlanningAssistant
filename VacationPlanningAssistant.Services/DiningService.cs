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
    public class DiningService : IDiningService
    {
        private readonly Guid _userId;
      

        public DiningService(Guid userId)
        {
            _userId = userId;
        }
        public DiningService()
        {
        }


        public bool CreateDining(DiningCreate model)
        {
            var entity =
                new Dining()
                {
                    Id = model.Id,
                    NameOfRestaurant = model.NameOfRestaurant,
                    Location = model.Location,
                    ReservationTime = model.ReservationTime,
                    ReservationNumber = model.ReservationNumber,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dinings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<DiningListItem> GetDinings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dinings
                        .Where(e => e.DiningId == e.DiningId && e.Id == _userId.ToString())
                        .Select(
                            e =>
                                new DiningListItem
                                {
                                    DiningId = e.DiningId,
                                    Id = e.Id,
                                    NameOfRestaurant = e.NameOfRestaurant,
                                    Location = e.Location,
                                    ReservationTime = e.ReservationTime,
                                    ReservationNumber = e.ReservationNumber,
                                }
                        );

                return query.ToArray();
            }
        }

        public DiningDetail GetDiningById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dinings
                        .Single(e => e.DiningId == id);
                return
                    new DiningDetail
                    {
                        DiningId = entity.DiningId,
                        Id = entity.Id,
                        NameOfRestaurant = entity.NameOfRestaurant,
                        Location = entity.Location,
                        ReservationTime = entity.ReservationTime,
                        ReservationNumber = entity.ReservationNumber,
                    };
            }
        }

        public bool UpdateDining(DiningEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dinings
                    .Single(e => e.DiningId == model.DiningId);

                entity.DiningId = model.DiningId;
                entity.NameOfRestaurant = model.NameOfRestaurant;
                entity.Location = model.Location;
                entity.ReservationTime = model.ReservationTime;
                entity.ReservationNumber = model.ReservationNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDining(int diningId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Dinings
                    .Single(e => e.DiningId == diningId);

                ctx.Dinings.Remove(entity);


                return ctx.SaveChanges() == 1;
            }
        }
    }
}
