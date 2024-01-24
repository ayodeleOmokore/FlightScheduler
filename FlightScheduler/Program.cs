//using System;
//using System.Collections.Generic;
//using System.Linq;

//// Single Responsibility Principle
//class Program
//{
//    //static void Main()
//    //{
//    //    IFlightScheduler flightScheduler = new FlightScheduler();
//    //    flightScheduler.Run();
//    //}
//}

using FlightScheduler.Services.Implementations;
using FlightScheduler.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddSingleton<IFlightSchedule, FlightSchedule>();
        services.AddSingleton<IOrderManager, OrderManager>();
        services.AddSingleton<ISchedulingStrategy, PrioritySchedulingStrategy>();
        services.AddSingleton<IGenerateFlightItineraries, GenerateFlightItineraries>();

        services.AddSingleton<IRunApplication, RunApplication>();

    }).Build();
var app = _host.Services.GetRequiredService<IRunApplication>();
await app.Main();










