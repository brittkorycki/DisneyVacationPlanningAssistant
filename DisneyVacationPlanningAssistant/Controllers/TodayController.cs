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
    public class TodayController : Controller
    {
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