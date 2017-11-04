using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Grade> Grades { get; set; }
    }
}
