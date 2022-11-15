using System;
namespace CodingEventsMVC.Models
{
	//18.5.3
	public class EventTag
	{
		public int EventId { get; set; }
		public Event Event { get; set; }

		public int TagId { get; set;}
		public Tag Tag { get; set; }

		//this class creates a compound key

		public EventTag()
		{
		}
	}
}

