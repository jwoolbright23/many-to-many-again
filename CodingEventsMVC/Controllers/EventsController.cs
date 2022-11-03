using System;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsMVC.Controllers
{
    //13.6.3.1 
    public class EventsController : Controller
    {
        //13.10 - convert list to dictionary
        //static private List<string> Events = new List<string>();

        static private Dictionary<string, string> Events = new Dictionary<string, string>();

        //13.6.3.2
        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            //13.6.3.3
            //Comment these out -- NewEvent method replaces this
            //Events.Add("Code With Pride");
            //Events.Add("Strange Loop");
            //Events.Add("Code & Coffee");

            //13.6.3.4
            ViewBag.events = Events;

            return View();

        }

        //13.6.4
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name, string desc)
        {
            Events.Add(name, desc);
            return Redirect("/Events");
        }
    }
}

