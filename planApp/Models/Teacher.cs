using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
	public class Teacher
	{
		public Teacher()
		{
			Subjects = new List<Subject>();
			Availability = new List<AvailablePeriod>();
		}
		public int ID { get; set; }
		[Display(Name = "Imię")]
		public string FirstName { get; set; }
		[Display(Name = "Nazwisko")]
		public string LastName { get; set; }
		[Display(Name = "Przedmioty")]
		public virtual List<Subject> Subjects { get; set; }
		[Display(Name = "Dostępność")]
		public virtual List<AvailablePeriod> Availability { get; set; }
	}
}
