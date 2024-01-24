using FlightScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Services.Interfaces
{
    internal interface IOrderManager
    {
        Task<Dictionary<string, Order>> LoadOrders(string filePath);
    }
}
