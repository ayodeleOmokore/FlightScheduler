using FlightScheduler.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Services.Interfaces
{
    internal interface IGenerateFlightItineraries
    {
        Task GenerateFlightItinerary(IFlightSchedule flightSchedule);
    }
}
