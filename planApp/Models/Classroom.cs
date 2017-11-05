using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class Classroom
    {
        public int ID { get; set; }
        [Range(1, int.MaxValue)]
        [Display(Name = "Numer sali")]
        public int Number { get; set; }
    }
}
