using System;
using CodingEventsMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

//18.5
namespace CodingEventsMVC.ViewModels
{
	public class AddEventTagViewModel
	{
        //Event elements
        public int EventId { get; set; }
        public Event Event { get; set; }

        //Tag elements
        public int TagId { get; set; }
        public List<SelectListItem> Tags { get; set; }





        public AddEventTagViewModel(Event theEvent, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            Event = theEvent;
        }

        public AddEventTagViewModel() { }
    }
}

