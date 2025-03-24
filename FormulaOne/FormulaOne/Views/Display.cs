#nullable disable

using FormulaOne.Controllers;

namespace FormulaOne.Views
{
    public class Display
    {
        private readonly TeamController teamController = new();
        private readonly DriverController driverController = new();

        public async Task ShowMenuAsync()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Welcome to the Formula One fan command board :D");
            Console.WriteLine("Use the following commands to interact with the interface:");
            Console.WriteLine("-> GetTeams");
            Console.WriteLine("-> GetTeamById <id>");
            Console.WriteLine("-> GetTeamsByCountry <country>");
            Console.WriteLine("-> GetOldestTeam");
            Console.WriteLine("-> GetDrivers");
            Console.WriteLine("-> GetDriverById <id>");
            Console.WriteLine("-> GetDriversByName <lastName>");
            Console.WriteLine("-> GetDriversByNationality <nationality>");
            Console.WriteLine("--------------------------------------------------");

            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "End")
            {
                var command = input[1];

                if (command == "GetTeams")
                {
                    var teams = await teamController.GetAllTeamsAsync();

                    foreach (var item in teams)
                    {
                        Console.WriteLine($"{item.Name} - {item.Country}: {item.FoundationYear}");
                    }
                }
                else if (command == "GetTeamById")
                {
                    int id = int.Parse(input[1]);

                    var team = await teamController.GetTeamByIdAsync(id);

                    Console.WriteLine($"{team.Name} - {team.Country}: {team.FoundationYear}");
                }
                else if (command == "GetTeamsByCountry")
                {
                    var country = input[1];

                    var teams = await teamController.GetTeamsByCountryAsync(country);

                    foreach (var item in teams)
                    {
                        Console.WriteLine($"{item.Name} - {item.Country}: {item.FoundationYear}");
                    }
                }
                else if (command == "GetOldestTeam")
                {
                    var team = await teamController.GetOldestTeamAsync();

                    Console.WriteLine($"{team.Name} - {team.Country}: {team.FoundationYear}");
                }
                else if (command == "GetDrivers")
                {
                    var drivers = await driverController.GetAllDriversAsync();

                    foreach (var item in drivers)
                    {
                        Console.WriteLine($"{item.FullName} - {item.Nationality}: Born on {item.BirthDate}");
                        Console.WriteLine($"Team {item.TeamName}");
                    }
                }
                else if (command == "GetDriverById")
                {
                    int id = int.Parse(input[1]);

                    var driver = await driverController.GetDriverByIdAsync(id);

                    Console.WriteLine($"{driver.FullName} - {driver.Nationality}: Born on {driver.BirthDate}");
                    Console.WriteLine($"Team {driver.TeamName}");
                }
                else if (command == "GetDriversByName")
                {
                    var lastName = input[1];

                    var drivers = await driverController.GetDriversByLastNameAsync(lastName);

                    foreach (var item in drivers)
                    {
                        Console.WriteLine($"{item.FullName} - {item.Nationality}: Born on {item.BirthDate}");
                        Console.WriteLine($"Team {item.TeamName}");
                    }
                }
                else if (command == "GetDriversByNationality")
                {
                    var nationality = input[1];

                    var drivers = await driverController.GetDriversByNationalityAsync(nationality);

                    foreach (var item in drivers)
                    {
                        Console.WriteLine($"{item.FullName} - {item.Nationality}: Born on {item.BirthDate}");
                        Console.WriteLine($"Team {item.TeamName}");
                    }
                }

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("To continue use the following commands to interact with the interface:");
                Console.WriteLine("-> GetTeams");
                Console.WriteLine("-> GetTeamById <id>");
                Console.WriteLine("-> GetTeamsByCountry <country>");
                Console.WriteLine("-> GetOldestTeam");
                Console.WriteLine("-> GetDrivers");
                Console.WriteLine("-> GetDriverById <id>");
                Console.WriteLine("-> GetDriversByName <lastName>");
                Console.WriteLine("-> GetDriversByNationality <nationality>");
                Console.WriteLine("-> End");
                Console.WriteLine("--------------------------------------------------");

                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
        }
    }
}
