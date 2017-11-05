using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public Day Day { get; set; }
        public int Hour { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public Classroom Classroom { get; set; }
    }
}
