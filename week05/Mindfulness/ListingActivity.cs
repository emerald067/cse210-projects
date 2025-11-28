using System;
using System.Collections.Generic;

namespace Mindfulness
{

    public class ListingActivity : Activity
    {
        private List<string> _unusedPrompts = new List<string>();
        private int _count;
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?",
            "What are things you are grateful for today?",
            "What are some of your favorite memories?",
            "When have you felt the HolyGhost this week?",
            "When have you felt the HolyGhost this month?"
        };

        public ListingActivity() 
            : base("Listing Activity", 
                  "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine("\n" + GetRandomPrompt());
            Console.WriteLine("You may begin in:");
            ShowCountDown(5);

            _count = 0;
            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                Console.ReadLine();
                _count++;
            }

            Console.WriteLine($"\nYou listed {_count} items.");
            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            if (_unusedPrompts.Count == 0)
            {
                _unusedPrompts = new List<string>(_prompts);
            }
            Random rand = new Random();
            int index = rand.Next(_unusedPrompts.Count);
            string prompt = _unusedPrompts[index];
            _unusedPrompts.RemoveAt(index);
            return prompt;
        }
    }
}
