using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class AvailablePeriod
    {
        public int ID { get; set; }
        [Display(Name = "Dzień")]
        public Day Day { get; set; }
        [Display(Name = "Początek")]
        public TimeSpan Start { get; set; }
        [Display(Name = "Koniec")]
        public TimeSpan End { get; set; }
    }
}
