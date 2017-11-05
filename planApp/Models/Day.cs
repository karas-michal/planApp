using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public enum Day
    {
        [Display(Name = "Poniedziałek")]
        MONDAY,
        [Display(Name = "Wtorek")]
        TUESDAY,
        [Display(Name = "Środa")]
        WEDNESDAY,
        [Display(Name = "Czwartek")]
        THURSDAY,
        [Display(Name = "Piątek")]
        FRIDAY,
        [Display(Name = "Sobota")]
        SATURDAY,
        [Display(Name = "Niedziela")]
        SUNDAY
    }
}
