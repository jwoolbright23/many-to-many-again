using System;
using CodingEventsDemo.Data;
using CodingEventsMVC.Models;
using CodingEventsMVC.ViewModels;
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
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);

        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        //[Route("/Events/Add")]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    //15.3
                    ContactEmail = addEventViewModel.ContactEmail,
                    //16.2
                    Type = addEventViewModel.Type
                };
                EventData.Add(newEvent);
                return Redirect("/Events");
            }
            return View(addEventViewModel);   
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

        //14.5 Exercises 
        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            Event editingEvent = EventData.GetById(eventId);
            ViewBag.eventToEdit = editingEvent;
            ViewBag.title = "Edit Event: " + editingEvent.Name + "(id = " + editingEvent.Id + ")";
            return View();
        }

        //14.5 Exercises
        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description, string contactEmail)
        {
            Event editingEvent = EventData.GetById(eventId);
            editingEvent.Name = name;
            editingEvent.Description = description;
            //15.3
            editingEvent.ContactEmail = contactEmail;
            return Redirect("/Events");
        }

    }
}

