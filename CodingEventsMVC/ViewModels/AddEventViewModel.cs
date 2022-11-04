﻿using System;
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

        //16.2
        public EventType Type { get; set; }

        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
           new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
           new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
           new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
           new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString())
        };

    }
}
