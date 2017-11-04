using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class Class
    {
        public Class()
        {
            Students = new List<Student>();
            Requirements = new List<LessonRequirement>();
        }
        public int ID { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<LessonRequirement> Requirements { get; set; }
    }
}
