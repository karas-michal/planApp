using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class LessonRequirement
    {
        public int ID { get; set; }
        [Range(1, 9)]
        [Display(Name = "Godziny")]
        public int Hours { get; set; }
        [Display(Name = "Przedmiot")]
        public Subject Subject { get; set; }
    }
}
