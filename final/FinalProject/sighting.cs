

namespace FinalProject
{
    public abstract class Sighting
    {
        private string _trailMarker;
        private string _timestamp;
        private string _observerId;

        public string TrailMarker => _trailMarker;
        public string Timestamp => _timestamp;
        public string ObserverId => _observerId;

        public Sighting(string trailMarker, string timestamp, string observerId)
        {
            _trailMarker = trailMarker;
            _timestamp = timestamp;
            _observerId = observerId;
        }

        public abstract int EvaluateHazardLevel();
        public abstract string GetSummary();
    }
}