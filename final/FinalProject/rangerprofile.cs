namespace FinalProject
{
    public class RangerProfile
    {
        private string _name;
        private string _badgeNumber;
        private string _assignedZone;

        public string Name => _name;
        public string BadgeNumber => _badgeNumber;
        public string AssignedZone => _assignedZone;

        public RangerProfile(string name, string badgeNumber, string assignedZone)
        {
            _name = name;
            _badgeNumber = badgeNumber;
            _assignedZone = assignedZone;
        }

        public string GetProfileSummary()
        {
            return $"Ranger {_name} (Badge #{_badgeNumber}) - Zone: {_assignedZone}";
        }
    }
}