using System;
using CodingEventsMVC.Data;
using CodingEventsMVC.Models;
using CodingEventsMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsMVC.Controllers
{
	public class TagController : Controller
	{
		private EventDbContext context;

		public TagController(EventDbContext dbContext)
		{
			context = dbContext;
		}

		//GET: /<controller>/
		public IActionResult Index()
		{
			List<Tag> tags = context.Tags.ToList();
			return View(tags);
		}

		public IActionResult Add()
		{
			Tag tag = new Tag();
			return View(tag);
		}

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Tags.Add(tag);
                context.SaveChanges();
                return Redirect("/Tag/");
            }

            return View("Add", tag);
        }

		public IActionResult AddEvent(int id)
		{
			//SYNTAX CHANGE 18.5.4
			//source: https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-7.0#synchronous-action


			Event theEvent = context.Events.Find(id);
			List<Tag> possibleTags = context.Tags.ToList();

			AddEventTagViewModel addEventTagViewModel = new AddEventTagViewModel(theEvent, possibleTags);

			return View(addEventTagViewModel);
		}

		//18.5.4
		[HttpPost]
		public IActionResult AddEvent(AddEventTagViewModel addEventTagViewModel)
		{
			if (ModelState.IsValid)
			{
				int eventId = addEventTagViewModel.EventId;
				int tagId = addEventTagViewModel.TagId;

				List<EventTag> eventTags = context.EventTags
					//.Where(et => et.EventId == eventId)
					//.Where(et => et.TagId == tagId)
					.ToList();

				if (eventTags.Count == 0)
				{
					EventTag eventTag = new EventTag
					{
						EventId = eventId,
						TagId = tagId
					};
					context.EventTags.Add(eventTag);
					context.SaveChanges();
			}

			return Redirect("/Events/Detail/" + eventId);
			}
			return View(addEventTagViewModel);
		}

		public IActionResult Detail(int id)
		{
			List<EventTag> eventTags = context.EventTags
				.Where(et => et.TagId == id)
				.Include(et => et.Event)
				.Include(et => et.Tag)
				.ToList();

			return View(eventTags);
		}
	}
}


