using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class LessonRequirement
    {
        public int ID { get; set; }
        public int Hours { get; set; }
        public Subject Subject { get; set; }
    }
}
