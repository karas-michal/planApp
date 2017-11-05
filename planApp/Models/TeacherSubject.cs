using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
	public class TeacherSubject
	{
		public int TeacherID { get; set; }
		public int SubjectID { get; set; }
		public Teacher Teacher { get; set; }
		public Subject Subject { get; set; }
	}
}
