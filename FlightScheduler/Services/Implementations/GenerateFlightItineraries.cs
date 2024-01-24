using FlightScheduler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Services.Implementations
{
    internal class GenerateFlightItineraries : IGenerateFlightItineraries
    {
        public async Task GenerateFlightItinerary(IFlightSchedule flightSchedule)
        {
            Console.WriteLine("Flight Itineraries:");
            try
            {
                foreach (var flight in flightSchedule.Flights)
                {
                    Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine("| Order Id   | Destination | Flight Number | Departure | Arrival | Day |");
                    Console.WriteLine(new string('-', 60));

                    foreach (var order in flight.Orders)
                    {
                        Console.WriteLine($"| {order.Destination.PadRight(11)} | {flight.FlightNumber.ToString().PadRight(12)} | {flight.Departure.PadRight(9)} | {flight.Arrival.PadRight(7)} | {flight.Day.ToString().PadRight(4)} |");
                    }

                    Console.WriteLine(new string('-', 60));
                    Console.WriteLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while trying to Generate Flight Itinerary");
            }
        }
    }
}
