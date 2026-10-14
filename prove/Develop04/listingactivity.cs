using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts;
        private Random _random;

        public ListingActivity() : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _random = new Random();

            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public void Run()
        {
            DisplayStartingMessage();

            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine("\nList as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.WriteLine();

            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }

            Console.WriteLine($"You listed {items.Count} items!");
            DisplayEndingMessage();
        }
    }
}