namespace FinalProject
{
    public class BotanicalRecord : Sighting
    {
        private string _plantSpecies;
        private bool _isInvasive;
        private string _healthStatus;

        public BotanicalRecord(string trailMarker, string timestamp, string observerId, 
                               string plantSpecies, bool isInvasive, string healthStatus) 
            : base(trailMarker, timestamp, observerId)
        {
            _plantSpecies = plantSpecies;
            _isInvasive = isInvasive;
            _healthStatus = healthStatus;
        }

        public override int EvaluateHazardLevel()
        {
            // Invasive plants flag environmental hazards for park management
            return _isInvasive ? 2 : 1;
        }

        public override string GetSummary()
        {
            string invasiveTag = _isInvasive ? "Invasive" : "Native";
            return $"[BOTANICAL] {Timestamp} at '{TrailMarker}': {_plantSpecies} ({invasiveTag}, Health: {_healthStatus})";
        }
    }
}