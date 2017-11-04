using System;
using System.Collections.Generic;
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
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public virtual List<Subject> Subjects { get; set; }
		public virtual List<AvailablePeriod> Availability { get; set; }
	}
}
