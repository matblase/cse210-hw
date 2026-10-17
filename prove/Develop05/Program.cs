using System;

/*
 * EXCEEDING REQUIREMENTS / CREATIVITY REPORT:

 * 
 * When saving or loading goal data to/from a text file, a custom timer-based 
 * spinner animation plays for 2 seconds to enhance the user experience
 */

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}