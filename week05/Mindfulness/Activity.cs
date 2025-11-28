using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mindfulness
{
    public class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string GetName()
        {
            return _name;
        }
        public string GetDescription()
        {
            return _description;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine ($"---{_name}---");
            Console.WriteLine(_description);
            Console.Write("\nEnter the duration in seconds: ");
            _duration = int.Parse(Console.ReadLine());
            Console.WriteLine("\nPrepare to begin...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!");
            Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
            ShowSpinner(3);
        }

        protected int GetDuration()
        {
            return _duration;
        }

        public void ShowSpinner(int seconds)
        {
            List<string> animation = new List<string> {"|", "/", "-", "\\"};
            DateTime endTime = DateTime.Now.AddSeconds(10);
            int i = 0;
            while (DateTime.Now < endTime)
            {
                
                Console.Write(animation[i % animation.Count]);
                System.Threading.Thread.Sleep(1000);
                Console.Write("\b \b");
                i++;
            }
            return ;
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                System.Threading.Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}



