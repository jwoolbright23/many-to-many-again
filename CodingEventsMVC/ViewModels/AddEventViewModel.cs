using System;
using System.ComponentModel.DataAnnotations;
using CodingEventsMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEventsMVC.ViewModels
{
    public class AddEventViewModel
    {
        //attributes for 15.3
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }
   
        [Required(ErrorMessage = "Please enter a description for your event.")]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        //18.3.1
        [Required(ErrorMessage ="Category is required")]
        public int CategoryId { get; set; }

        public List<SelectListItem>? Categories { get; set; }







        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }

        //18 -- no arg controller 18.3.2
        public AddEventViewModel() { }

    }
}

