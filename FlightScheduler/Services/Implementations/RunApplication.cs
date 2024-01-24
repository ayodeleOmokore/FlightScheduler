using FlightScheduler.Models;
using FlightScheduler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Services.Implementations
{
    internal class RunApplication : IRunApplication
    {
        private readonly ISchedulingStrategy _strategy;
        private readonly IFlightSchedule _flightSchedule;
        private readonly IOrderManager _orderManager;
        private readonly IGenerateFlightItineraries _generateFlightItineraries;
        public RunApplication(ISchedulingStrategy strategy
            , IFlightSchedule flightSchedule
            , IOrderManager orderManager,
IGenerateFlightItineraries generateFlightItineraries)
        {
            _strategy = strategy;
            _flightSchedule = flightSchedule;
            _orderManager = orderManager;
            _generateFlightItineraries = generateFlightItineraries;
        }
        public async Task Main()
        {

            await _flightSchedule.LoadFlightScheduleAndOrders(_flightSchedule);

            Console.WriteLine("Loaded Flight Schedule:");
            Console.WriteLine(_flightSchedule.ToString());

            Console.WriteLine("\nFlight Itineraries with Orders:");
            await _generateFlightItineraries.GenerateFlightItinerary(_flightSchedule);

            Console.ReadLine();
        }
    }
}
