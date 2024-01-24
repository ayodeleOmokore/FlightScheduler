using FlightScheduler.Models;
using FlightScheduler.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Services.Implementations
{
    internal class OrderManager : IOrderManager
    {
        public async Task<Dictionary<string, Order>> LoadOrders(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return new Dictionary<string, Order>();
            }

        }
    }
}
