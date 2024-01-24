using FlightScheduler.Models;
using FlightScheduler.Services.Implementations;

namespace FlightScheduler.Services.Interfaces
{
    internal interface IFlightSchedule
    {
        List<Flight> Flights { get; }
        ISchedulingStrategy SchedulingStrategy { get; set; }

        void AddFlight(int flightNumber, string departure, string arrival, int day);
        void AddOrder(Order order);
        string ToString();
        Task LoadFlightScheduleAndOrders(IFlightSchedule flightSchedule);
    }
}