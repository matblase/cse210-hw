using System;

namespace FinalProject
{
    class Program
    {
        static RangerProfile LoginScreen()
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("    NATIONAL PARK SERVICE FIELD SYSTEM        ");
            Console.WriteLine("==============================================");
            Console.WriteLine("Please sign in to log observations.\n");

            Console.Write("Enter Ranger Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Badge Number (for example, R-402): ");
            string badge = Console.ReadLine();

            Console.Write("Enter Assigned Zone (for example, North Ridge, Valley): ");
            string zone = Console.ReadLine();

            RangerProfile ranger = new RangerProfile(name, badge, zone);
            Console.WriteLine($"\n[LOGIN SUCCESSFUL] Welcome, {ranger.GetProfileSummary()}\n");
            return ranger;
        }

        static void Main(string[] args)
        {
            ParkDatabase db = new ParkDatabase();
            SafetyAlertSystem alertSystem = new SafetyAlertSystem();
            Trail activeTrail = new Trail("Pine Crest Loop", 4.5, "Moderate");

            RangerProfile activeRanger = LoginScreen();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine($" Active Ranger: {activeRanger.Name} (Badge #{activeRanger.BadgeNumber})");
                Console.WriteLine($" Active Trail:  {activeTrail.GetTrailInfo()}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1. Add Botanical Record");
                Console.WriteLine("2. Add Wildlife Sighting");
                Console.WriteLine("3. Add Weather Log");
                Console.WriteLine("4. View All Sightings");
                Console.WriteLine("5. Run Safety Alert Check");
                Console.WriteLine("6. Switch Ranger / Log Out");
                Console.WriteLine("7. Exit Application");
                Console.Write("Enter choice (1-7): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Trail Marker (for example, Marker 4): ");
                        string botMarker = Console.ReadLine();
                        Console.Write("Enter Plant/Tree Species: ");
                        string species = Console.ReadLine();
                        
                        Console.Write("Is this species invasive? (yes/no): ");
                        bool isInvasive = Console.ReadLine().Trim().ToLower().StartsWith("y");

                        Console.Write("Enter Health Status (for example, Healthy, Diseased, Wilting): ");
                        string health = Console.ReadLine();

                        db.AddSighting(new BotanicalRecord(botMarker, DateTime.Now.ToShortTimeString(), activeRanger.BadgeNumber, species, isInvasive, health));
                        Console.WriteLine("Botanical record saved!");
                        break;

                    case "2":
                        Console.Write("Enter Trail Marker (for example, Marker 12): ");
                        string wildMarker = Console.ReadLine();
                        
                        Console.Write("Enter Animal Species (for example, Bear, Deer, Elk): ");
                        string animal = Console.ReadLine();

                        Console.Write("Enter Animal Count: ");
                        int.TryParse(Console.ReadLine(), out int count);
                        if (count <= 0) count = 1;

                        Console.WriteLine("Select Observed Condition:");
                        Console.WriteLine(" 1. Normal / Healthy");
                        Console.WriteLine(" 2. Sick / Injured");
                        Console.WriteLine(" 3. Aggressive / Dangerous");
                        Console.Write("Enter choice (1-3): ");
                        
                        string condChoice = Console.ReadLine();
                        string condition = condChoice switch
                        {
                            "2" => "Sick/Injured",
                            "3" => "Aggressive",
                            _ => "Normal/Healthy"
                        };

                        db.AddSighting(new WildlifeSighting(wildMarker, DateTime.Now.ToShortTimeString(), activeRanger.BadgeNumber, animal, count, condition));
                        Console.WriteLine("Wildlife sighting saved!");
                        break;

                    case "3":
                        Console.Write("Enter Trail Marker (for example, Trailhead): ");
                        string wxMarker = Console.ReadLine();

                        Console.Write("Enter Weather Condition (for example, Sunny, Fog, Flash Flood): ");
                        string wxCondition = Console.ReadLine();

                        Console.Write("Enter Temperature (°F): ");
                        double.TryParse(Console.ReadLine(), out double tempF);

                        Console.Write("Is there an active safety hazard? (yes/no): ");
                        bool isHazard = Console.ReadLine().Trim().ToLower().StartsWith("y");

                        db.AddSighting(new WeatherLog(wxMarker, DateTime.Now.ToShortTimeString(), activeRanger.BadgeNumber, wxCondition, tempF, isHazard));
                        Console.WriteLine("Weather log saved!");
                        break;

                    case "4":
                        db.DisplayAllLogs();
                        break;

                    case "5":
                        alertSystem.CheckForAlerts(db);
                        break;

                    case "6":
                        Console.WriteLine("\nLogging out current ranger...");
                        activeRanger = LoginScreen();
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine("Exiting Park Observation System. Stay safe!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}