using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _unusedPrompts = new List<string>();
        private List<string> _unusedQuestions = new List<string>();

        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something selfless.",
            "Think of a time when you overcame a fear.",
            "Think of a time when you made a positive impact on someone's life.",
            "Think of a time when you achieved a personal goal.",
            "Think of a time when you showed kindness to a stranger."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn about yourself?",
            "How can you apply this experience in the future?",
            "How did you get started?",
            "What obstacles did you overcome?",
            "What strengths did you exhibit?",
            "What is your favorite thing about this experience?",
            "What did you learn about others through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectingActivity() 
            : base("Reflecting Activity", 
                  "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life..")
        {
        }

        public void Run()
        {
            DisplayStartingMessage();
            DisplayPrompt();

            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

            while (DateTime.Now < endTime)
            {
                DisplayQuestions();
            }

            DisplayEndingMessage();
        }

        private void DisplayPrompt()
        {
            Console.WriteLine("\n" + GetRandomPrompt());
            Console.WriteLine("\nPress Enter when ready to continue.");
            Console.ReadLine();
        }

        private void DisplayQuestions()
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(5);
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

        private string GetRandomQuestion()
        {
            if (_unusedQuestions.Count == 0)
            {
                _unusedQuestions = new List<string>(_questions);
            }

            Random rand = new Random();
            int index = rand.Next(_unusedQuestions.Count);
            string question = _unusedQuestions[index];
            _unusedQuestions.RemoveAt(index);
            return question;
        }
    }
}