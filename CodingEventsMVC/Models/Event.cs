using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsMVC.Models
{
    //created in 14.2
    public class Event
    {
        //17
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }

        //18 - creating our Foreign Key
        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }


        public List<EventTag> EventTags { get; set; }  //collection navigation


        public Event()
        {
        }

        public Event(string name, string description, string contactEmail)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
        }


        //removed EventType

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

//TODO: A -- start here  
//https://learn.microsoft.com/en-us/ef/core/change-tracking/relationship-changes?source=recommendations
//https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
//https://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx

