using System;

namespace FinalProject
{
    public class SafetyAlertSystem
    {
        public void CheckForAlerts(ParkDatabase db)
        {
            Console.WriteLine("\n--- SAFETY ALERT SYSTEM CHECK ---");
            bool alertTriggered = false;

            foreach (Sighting sighting in db.GetAllSightings())
            {
                
                if (sighting.EvaluateHazardLevel() >= 3)
                {
                    Console.WriteLine($"[ALERT WARNING] High hazard detected at '{sighting.TrailMarker}' by Ranger ID {sighting.ObserverId}!");
                    Console.WriteLine($"  Details: {sighting.GetSummary()}");
                    alertTriggered = true;
                }
            }

            if (!alertTriggered)
            {
                Console.WriteLine("No active safety hazards detected on trail.");
            }
        }
    }
}