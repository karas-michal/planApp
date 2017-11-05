using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
	public class Subject
	{
		public int ID { get; set; }
		[Display(Name = "Przedmiot")]
		public string Name { get; set; }
	}
}
