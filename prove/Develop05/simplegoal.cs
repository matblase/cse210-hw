namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false) 
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            _isComplete = true;
            return GetPoints();
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_isComplete}";
        }
    }
}