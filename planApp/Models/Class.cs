using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(1, 6)]
        [Display(Name = "Rok")]
        public int Year { get; set; }
        [MaxLength(1)]
        [Display(Name = "Litera")]
        public string Letter { get; set; }
        [Display(Name = "Uczniowie")]
        public List<Student> Students { get; set; }
        [Display(Name = "Wymagania")]
        public List<LessonRequirement> Requirements { get; set; }
    }
}
