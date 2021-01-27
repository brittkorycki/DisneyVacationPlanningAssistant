using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VacationPlanningAssistant.Models;
using VacationPlanningAssistant.Services;
using VacationPlanningAssistant.Contracts;

namespace DisneyVacationPlanningAssistant.Controllers
{
    public class TodayController : Controller
    {
        private readonly ITodayService _todayService;

        public TodayController(ITodayService todayService)
        {
            _todayService = todayService;
        }
        // GET: Today
        public ActionResult Today()
        {
        var userId = Guid.Parse(User.Identity.GetUserId());
        var service = new TodayService(userId);

            ViewData["Transports"] = service.GetTodaysTransports();
            ViewData["Accommodations"] = service.GetTodaysAccommodations();
            ViewData["Dinings"] = service.GetTodaysDinings();

            return View();

        }

    
    }
}