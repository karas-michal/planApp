using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        [Display(Name = "Dzień")] 
        public Day Day { get; set; }
        [Range(1, 24)]
        [Display(Name = "Godzina")] 
        public int Hour { get; set; }
        [Display(Name = "Przedmiot")]
        public Subject Subject { get; set; }
        [Display(Name = "Nauczyciel")]
        public Teacher Teacher { get; set; }
        [Display(Name = "Klasa")]
        public Class Class { get; set; }
        [Display(Name = "Sala")]
        public Classroom Classroom { get; set; }
        public TimeSpan HourAsTimeSpan { get { return new TimeSpan(Hour); } }
    }
}
