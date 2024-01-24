using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Models
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }
        public List<Order> Orders { get; } = new List<Order>();
    }
}
