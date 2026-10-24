namespace FinalProject
{
    public class WeatherLog : Sighting
    {
        private string _condition;
        private double _temperatureF;
        private bool _hasHazard;

        public WeatherLog(string trailMarker, string timestamp, string observerId, 
                          string condition, double temperatureF, bool hasHazard) 
            : base(trailMarker, timestamp, observerId)
        {
            _condition = condition;
            _temperatureF = temperatureF;
            _hasHazard = hasHazard;
        }

        public override int EvaluateHazardLevel()
        {
            return _hasHazard ? 3 : 1;
        }

        public override string GetSummary()
        {
            string alertText = _hasHazard ? " (HAZARD PRESENT)" : "";
            return $"[WEATHER] {Timestamp} at Marker '{TrailMarker}': {_condition}, {_temperatureF}°F{alertText}";
        }
    }
}