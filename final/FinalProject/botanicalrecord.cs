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
            return _isInvasive ? 2 : 1;
        }

        public override string GetSummary()
        {
            string status = _isInvasive ? "Invasive" : "Native";
            return $"[BOTANICAL] {Timestamp} at Marker '{TrailMarker}': {_plantSpecies} ({status}, Health: {_healthStatus})";
        }
    }
}