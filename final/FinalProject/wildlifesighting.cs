namespace FinalProject
{
    public class WildlifeSighting : Sighting
    {
        private string _animalSpecies;
        private int _count;
        private string _conditionStatus; 

        public WildlifeSighting(string trailMarker, string timestamp, string observerId, 
                                string animalSpecies, int count, string conditionStatus) 
            : base(trailMarker, timestamp, observerId)
        {
            _animalSpecies = animalSpecies;
            _count = count;
            _conditionStatus = conditionStatus;
        }

        public override int EvaluateHazardLevel()
        {
            string speciesLower = _animalSpecies.ToLower();
            string conditionLower = _conditionStatus.ToLower();

            
            if (speciesLower.Contains("bear") || speciesLower.Contains("cougar") || 
                conditionLower.Contains("sick") || conditionLower.Contains("injured") || conditionLower.Contains("aggressive"))
            {
                return 3; 
            }

            return 1;
        }

        public override string GetSummary()
        {
            return $"[WILDLIFE] {Timestamp} at Marker '{TrailMarker}': {_count}x {_animalSpecies} | Condition: {_conditionStatus}";
        }
    }
}