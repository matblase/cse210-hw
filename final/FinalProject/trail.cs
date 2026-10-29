namespace FinalProject
{
    public class Trail
    {
        private string _name;
        private double _distanceMiles;
        private string _difficulty;

        public string Name => _name;

        public Trail(string name, double distanceMiles, string difficulty)
        {
            _name = name;
            _distanceMiles = distanceMiles;
            _difficulty = difficulty;
        }

        public string GetTrailInfo()
        {
            return $"{_name} ({_distanceMiles} miles, {_difficulty} difficulty)";
        }
    }
}