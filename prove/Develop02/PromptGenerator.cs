using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was a small act of kindness I witnessed or received today?",
        "What was something unexpected that made me smile or laugh today?",
        "What is one lesson I learned today that I want to remember tomorrow?",
        "Who did I help today, or who helped me when I needed it?",
        "What was a challenge I faced today, and how did I handle it?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}