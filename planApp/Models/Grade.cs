using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class Grade
    {
        public int ID { get; set; }
        [Range(1, 6)]
        [Display(Name = "Ocena")]
        public int Value { get; set; }
        [Display(Name = "Przedmiot")]
        public Subject Subject { get; set; }
    }
}
