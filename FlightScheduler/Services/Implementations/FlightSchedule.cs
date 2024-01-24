using FlightScheduler.Models;
using FlightScheduler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Services.Implementations
{
    
    internal class FlightSchedule : IFlightSchedule
    {
        private readonly IOrderManager _orderManager;

        private readonly List<Flight> _flights = new List<Flight>();
        public List<Flight> Flights => _flights;

        public ISchedulingStrategy SchedulingStrategy { get; set; }

        public FlightSchedule(ISchedulingStrategy schedulingStrategy, IOrderManager orderManager)
        {
            SchedulingStrategy = schedulingStrategy;
            _orderManager = orderManager;
        }

        public void AddFlight(int flightNumber, string departure, string arrival, int day)
        {
            _flights.Add(new Flight { FlightNumber = flightNumber, Departure = departure, Arrival = arrival, Day = day });
        }

        public void AddOrder(Order order)
        {
            foreach (var flight in _flights)
            {
                SchedulingStrategy.ScheduleOrder(flight, order);
            }
        }

        public override string ToString()
        {
            return string.Join(" ... ", _flights.Select(flight =>
                $"Flight: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}"));
        }

        public async Task LoadFlightScheduleAndOrders(IFlightSchedule flightSchedule)
        {
            try
            {
                // Load the flight schedule as per USER STORY #1
                flightSchedule.AddFlight(1, "YUL", "YYZ", 1);
                flightSchedule.AddFlight(2, "YUL", "YYC", 1);
                flightSchedule.AddFlight(3, "YUL", "YVR", 1);
                flightSchedule.AddFlight(4, "YUL", "YYZ", 2);
                flightSchedule.AddFlight(5, "YUL", "YYC", 2);
                flightSchedule.AddFlight(6, "YUL", "YVR", 2);

                // Load orders from JSON file as per USER STORY #2
                Dictionary<string, Order> orders = await _orderManager.LoadOrders("coding-assigment-orders.json");

                foreach (var order in orders)
                {
                    flightSchedule.AddOrder(order.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while trying to Load Flight ScheduleAndOrders");
            }
          
        }
    }
}
