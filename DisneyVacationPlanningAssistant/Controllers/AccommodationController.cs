using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationPlanningAssistant.Models;
using VacationPlanningAssistant.Services;

namespace DisneyVacationPlanningAssistant.Controllers
{
    public class AccommodationController : Controller
    {
        // GET: Accommodation
        public ActionResult Index()
        {
            var service = new AccommodationService();
            var model = service.GetAccommodations();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccommodationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAccommodationService();

            if (service.CreateAccommodation(model))
            {
                TempData["SaveResult"] = "Your accommodation was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Accommodation could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAccommodationService();
            var model = svc.GetAccommodationById(id);

            return View(model);
        }

        private static AccommodationService CreateAccommodationService()
        {
            return new AccommodationService();
        }
        public ActionResult Edit(int id)
        {
            var service = CreateAccommodationService();
            var detail = service.GetAccommodationById(id);
            var model =
                new AccommodationEdit
                {
                    AccommodationId = detail.AccommodationId,
                    Name = detail.Name,
                    StreetAddress = detail.StreetAddress,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    ReservationNumber = detail.ReservationNumber,
                    CheckIn = detail.CheckIn,
                    CheckOut = detail.CheckOut
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccommodationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AccommodationId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAccommodationService();

            if (service.UpdateAccommodation(model))
            {
                TempData["SaveResult"] = "Your accommodation was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your accommodation could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAccommodationService();
            var model = svc.GetAccommodationById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAccommodation(int id)
        {
            var service = CreateAccommodationService();

            service.DeleteAccommodation(id);

            TempData["Save Result"] = "Your accommodation as deleted.";

            return RedirectToAction("Index");
        }
    }
}