using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public class Activity
    {
        private string _name;
        private string _description;
        protected int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 0;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.\n");
            Console.WriteLine($"{_description}\n");
            Console.Write("How long, in seconds, would you like for your session? ");
            
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Please enter a valid number of seconds: ");
            }
            _duration = duration;

            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!!");
            ShowSpinner(3);
            Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(3);
        }

        public void ShowSpinner(int seconds)
        {
            List<string> animation = new List<string> { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(animation[i % animation.Count]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
            }
        }

        public void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}