#nullable disable

using Microsoft.EntityFrameworkCore;
using RailWayStation.Data;

namespace RailwayStation
{
    public class Program
    {   
        public static async Task Main(string[] args)
        {
            var context = new RailwayStationDbContext();

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Starting menu:");
            Console.WriteLine("Use the following commands to interact with the data base");
            Console.WriteLine("1.Print all trains");
            Console.WriteLine("2.Print all tracks");
            Console.WriteLine("3.Print all tickets");
            Console.WriteLine("4.Print all routes");
            Console.WriteLine("5.Print all employees");
            Console.WriteLine("6.Print employees by postion (given by the user)");
            Console.WriteLine("7.Print routes by departure station (given by the user)");
            Console.WriteLine("8.Print ticket info (passenger name, seat number, price) by train id (given by the user)");
            Console.WriteLine("------------------------------------------------");

            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0] != "End")
            {
                string command = input[0];

                switch (command)
                {
                    case "1":
                        var trains = await context.Trains
                            .Select(t => new
                            {
                                TrainNumber = t.TrainNumber,
                                Capacity = t.Capacity
                            })
                            .ToListAsync();

                        foreach (var item in trains)
                        {
                            Console.WriteLine($"{item.TrainNumber} - {item.Capacity}");
                        }

                        break;
                    case "2":
                        var tracks = await context.Tracks
                            .Select(t => new
                            {
                                StationName = t.StationName,
                                TrackNumber = t.TrackNumber,
                                TrainNumber = t.Train.TrainNumber
                            })
                            .ToListAsync();
                        foreach (var item in tracks)
                        {
                            Console.WriteLine($"{item.StationName} - {item.TrackNumber}: {item.TrainNumber}");
                        }

                        break;
                    case "3":
                        var tickets = await context.Tickets
                            .Select(t => new
                            {
                                PassengerName = t.PassengerName,
                                SeatNumber = t.SeatNumber,
                                Price = t.Price,
                                DepartrueStation = t.Route.DepartrueStation,
                                ArrivalStation = t.Route.ArrivalStation,
                                DepartureTime = t.Route.DepartureTime,
                                ArrivalTime = t.Route.ArrivalTime,
                                TrainNumber = t.Train.TrainNumber
                            })
                            .ToListAsync();
                        
                        foreach(var item in tickets)
                        {
                            Console.WriteLine($"{item.PassengerName} - {item.SeatNumber}: {item.Price}");
                            Console.WriteLine($"--Train information--");
                            Console.WriteLine($"{item.DepartrueStation} -> {item.ArrivalStation}");
                            Console.WriteLine($"At: {item.DepartureTime} to {item.ArrivalTime}");
                        }

                        break;
                    case "4":
                        var routes = await context.Routes
                            .Select(r => new
                            {
                                DepartrueStation = r.DepartrueStation,
                                ArrivalStation = r.ArrivalStation,
                                DepartureTime = r.DepartureTime,
                                ArrivalTime = r.ArrivalTime,
                                TrainNumber = r.Train.TrainNumber
                            })
                            .ToListAsync();

                        foreach(var item in routes)
                        {
                            Console.WriteLine($"{item.DepartrueStation} - {item.ArrivalStation} with train: {item.TrainNumber}");
                            Console.WriteLine($"At: {item.DepartureTime} to {item.ArrivalTime}");
                        }

                        break;
                    case "5":
                        var employees = await context.Employees
                            .Select(e => new
                            {
                                Name = e.Name,
                                Position = e.Position,
                                TrainNumber = e.Train.TrainNumber
                            })
                            .ToListAsync();

                        foreach(var item in employees)
                        {
                            Console.WriteLine($"{item.Name} - {item.Position} on {item.TrainNumber}");
                        }

                        break;
                    case "6":
                        string position = input[1];

                        var employeesWithPosition = await context.Employees
                            .Where(e => e.Position == position)
                            .Select(e => new
                            {
                                Name = e.Name,
                                Position = position,
                                TrainNumber = e.Train.TrainNumber
                            })
                            .ToListAsync();

                        foreach (var item in employeesWithPosition)
                        {
                            Console.WriteLine($"{item.Name} - {item.Position} on {item.TrainNumber}");
                        }

                        break;
                    case "7":
                        var station = input[1];

                        var routesWithStation = await context.Routes
                            .Where(r => r.DepartrueStation == station)
                            .Select(r => new
                            {
                                DepartrueStation = r.DepartrueStation,
                                ArrivalStation = r.ArrivalStation,
                                DepartureTime = r.DepartureTime,
                                ArrivalTime = r.ArrivalTime,
                                TrainNumber = r.Train.TrainNumber
                            })
                            .ToListAsync();

                        foreach (var item in routesWithStation)
                        {
                            Console.WriteLine($"{item.DepartrueStation} - {item.ArrivalStation} with train: {item.TrainNumber}");
                            Console.WriteLine($"At: {item.DepartureTime} to {item.ArrivalTime}");
                        }

                        break;
                    case "8":
                        int trainId = int.Parse(input[1]);

                        var ticketsForTrain = await context.Tickets
                            .Where(t => t.TrainId == trainId)
                            .Select(t => new
                            {
                                PassengerName = t.PassengerName,
                                SeatNumber = t.SeatNumber,
                                Price = t.Price,
                                DepartrueStation = t.Route.DepartrueStation,
                                ArrivalStation = t.Route.ArrivalStation,
                                DepartureTime = t.Route.DepartureTime,
                                ArrivalTime = t.Route.ArrivalTime,
                                TrainNumber = t.Train.TrainNumber
                            })
                            .ToListAsync();

                        foreach (var item in ticketsForTrain)
                        {
                            Console.WriteLine($"{item.PassengerName} - {item.SeatNumber}: {item.Price}");
                            Console.WriteLine($"--Train information--");
                            Console.WriteLine($"{item.DepartrueStation} -> {item.ArrivalStation}");
                            Console.WriteLine($"At: {item.DepartureTime} to {item.ArrivalTime}");
                        }

                        break;
                }

                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Continue using the following commands to interact with the data base");
                Console.WriteLine("1.Print all trains");
                Console.WriteLine("2.Print all tracks");
                Console.WriteLine("3.Print all tickets");
                Console.WriteLine("4.Print all routes");
                Console.WriteLine("5.Print all employees");
                Console.WriteLine("6.Print employees by postion (given by the user)");
                Console.WriteLine("7.Print routes by departure station (given by the user)");
                Console.WriteLine("8.Print ticket info (passenger name, seat number, price) by train id (given by the user)");
                Console.WriteLine("------------------------------------------------");

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }
    }
}

