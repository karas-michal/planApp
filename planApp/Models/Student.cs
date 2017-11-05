using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class Student
    {
        public Student()
        {
            Grades = new List<Grade>();
        }
        public int ID { get; set; }
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Oceny")]
        public virtual List<Grade> Grades { get; set; }
    }
}
