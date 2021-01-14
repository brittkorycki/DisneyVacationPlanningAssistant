using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationPlanningAssistant.Models;
using VacationPlanningAssistant.Services;

namespace DisneyVacationPlanningAssistant.Controllers
{
    public class DiningController : Controller
    {
        // GET: Dining
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DiningService();
            var model = service.GetDinings();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiningCreate model)
        {

            model.Id = (User.Identity.GetUserId());
            
            
            if (!ModelState.IsValid) return View(model);
                       
            var service = CreateDiningService();

            if (service.CreateDining(model))
            {
                TempData["SaveResult"] = "Your dining reservation was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Dining reservation could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = CreateDiningService();
            var model = svc.GetDiningById(id);

            return View(model);
        }

        private static DiningService CreateDiningService()
        {
            return new DiningService();
        }
        public ActionResult Edit(int id)
        {
            var service = CreateDiningService();
            var detail = service.GetDiningById(id);
            var model =
                new DiningEdit
                {
                    DiningId = detail.DiningId,
                    NameOfRestaurant = detail.NameOfRestaurant,
                    Location = detail.Location,
                    ReservationTime = detail.ReservationTime,
                    ReservationNumber = detail.ReservationNumber,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DiningEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DiningId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDiningService();

            if (service.UpdateDining(model))
            {
                TempData["SaveResult"] = "Your dining reservation was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your dining reservation could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDiningService();
            var model = svc.GetDiningById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDining(int id)
        {
            var service = CreateDiningService();

            service.DeleteDining(id);

            TempData["Save Result"] = "Your dining reservation as deleted.";

            return RedirectToAction("Index");
        }
    }
}