using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsMVC.Models
{
	public class Tag
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="Name is required")]
		[StringLength(50, MinimumLength =3, ErrorMessage ="Tag must be between 3-50 characters.")]
		public string Name { get; set; }

		public Tag(string name)
		{
			Name = name;
		}

		public Tag()
		{
		}
	}
}

