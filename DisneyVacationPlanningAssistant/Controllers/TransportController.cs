using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationPlanningAssistant.Contracts;
using VacationPlanningAssistant.Models;
using VacationPlanningAssistant.Services;

namespace DisneyVacationPlanningAssistant.Controllers
{
    public class TransportController : Controller
    {
        private readonly ITransportService _transportService;

        public TransportController (ITransportService transportService)
        {
            _transportService = transportService;
        }
        // GET: Transport
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransportService(userId);
            var model = service.GetTransports();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransportCreate model)
        {

            model.Id = (User.Identity.GetUserId());

            if (!ModelState.IsValid) return View(model);

            var service = CreateTransportService();

            if (service.CreateTransport(model))
            {
                TempData["SaveResult"] = "Your means of transportation was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Means of transportation could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {

            var svc = CreateTransportService();
            var model = svc.GetTransportById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateTransportService();
            var detail = service.GetTransportById(id);
            var model =
                new TransportEdit
                {
                    TransportId = detail.TransportId,
                    Type = detail.Type,
                    Departure = detail.Departure,
                    ReservationNumber = detail.ReservationNumber
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransportEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TransportId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTransportService();

            if (service.UpdateTransport(model))
            {
                TempData["SaveResult"] = "Your transportation was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your transportation could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTransportService();
            var model = svc.GetTransportById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTransport(int id)
        {
            var service = CreateTransportService();

            service.DeleteTransport(id);

            TempData["Save Result"] = "Your transportation was deleted.";

            return RedirectToAction("Index");
        }
        private TransportService CreateTransportService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransportService(userId);
            return service;
        }
    }
}