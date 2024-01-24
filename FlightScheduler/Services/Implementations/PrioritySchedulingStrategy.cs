using FlightScheduler.Models;
using FlightScheduler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Services.Implementations
{
    internal class PrioritySchedulingStrategy : ISchedulingStrategy
    {
        public void ScheduleOrder(Flight flight, Order order)
        {
            if (flight.Arrival == order.Destination && flight.Orders.Count < 20)
            {
                flight.Orders.Add(order);
                return;

            }
            // If order cannot be scheduled, print not scheduled message
            Console.WriteLine($"order: {order.Destination}, flightNumber: not scheduled");
        }
    }
}
