using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class AvailablePeriod
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public TimeSpan Period { get; set; }
    }
}
