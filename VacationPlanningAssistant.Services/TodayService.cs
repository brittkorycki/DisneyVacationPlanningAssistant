using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlanningAssistant.Data;
using VacationPlanningAssistant.Models;

namespace VacationPlanningAssistant.Services
{
    public class TodayService
    {
        private readonly Guid _userId;
        public TodayService(Guid userId)
        {
            _userId = userId;
        }


        public TodayService()
        {
        }

        public IEnumerable<Transport> GetTodaysTransports()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transports.AsEnumerable()
                        .Where(e => e.Departure == DateTime.Today && e.Id == _userId.ToString())
                        .Select(
                            e =>
                                new Transport
                                { 
                                    Departure = e.Departure,
                                    ReservationNumber = e.ReservationNumber
                                }
                        );

                return query.ToArray();
            }
        }   
        
        public IEnumerable<Accommodation> GetTodaysAccommodations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Accommodations.AsEnumerable()
                        .Where(e => e.CheckIn == DateTime.Today && e.Id == _userId.ToString())
                        .Select(
                            e =>
                                new Accommodation
                                {
                                    CheckIn = e.CheckIn,
                                    ReservationNumber = e.ReservationNumber
                                }
                        ) ;

                return query.ToArray();
            }
        }

        public IEnumerable<Dining> GetTodaysDinings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dinings.AsEnumerable()
                        .Where(e => e.ReservationTime == DateTime.Today && e.Id == _userId.ToString())
                        .Select(
                            e =>
                                new Dining
                                {
                                    ReservationTime = e.ReservationTime,
                                    ReservationNumber = e.ReservationNumber,
                                }
                        );

                return query.ToArray();
            }
        }
       //public Today LoadTodaysReservations()
       // {
            
       // }


    }
}
