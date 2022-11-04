using System;
using CodingEventsDemo.Data;
using CodingEventsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsMVC.Controllers
{
    public class EventsController : Controller
    {
        //14.2 - changed dictionary to list
        static private List<Event> Events = new List<Event>();

        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/Events");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }


        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event editingEvent = EventData.GetById(eventId);
            ViewBag.eventToEdit = editingEvent;
            ViewBag.title = "Edit Event: " + editingEvent.Name + "(id = " + editingEvent.Id + ")";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event editingEvent = EventData.GetById(eventId);
            editingEvent.Name = name;
            editingEvent.Description = description;
            return Redirect("/Events");
        }

    }
}

