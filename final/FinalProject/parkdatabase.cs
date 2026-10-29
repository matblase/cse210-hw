using System;
using System.Collections.Generic;

namespace FinalProject
{
    public class ParkDatabase
    {
        private List<Sighting> _sightings;

        public ParkDatabase()
        {
            _sightings = new List<Sighting>();
        }

        public void AddSighting(Sighting sighting)
        {
            _sightings.Add(sighting);
        }

        public List<Sighting> GetAllSightings()
        {
            return _sightings;
        }

        public void DisplayAllLogs()
        {
            Console.WriteLine("\n--- ALL PARK OBSERVATION LOGS ---");
            if (_sightings.Count == 0)
            {
                Console.WriteLine("No observation records logged yet.");
                return;
            }

            foreach (Sighting s in _sightings)
            {
                Console.WriteLine(s.GetSummary());
            }
        }
    }
}