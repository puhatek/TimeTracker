using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTracker.Models;
using TimeTracker.Repository;

namespace TimeTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ClientRepository clientRepo = new ClientRepository();

            ClientRep client = clientRepo.get("Chloe Waterfield");

            TaskRepository project = new TaskRepository();

            List<ProjectTask> model = project.get();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}