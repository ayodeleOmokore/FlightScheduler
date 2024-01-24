using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace FlightScheduler.Models
{
    public class Order
    {
        [JsonProperty("destination")]
        public string Destination { get; set; }
    }
}
