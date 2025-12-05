// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            int choice = -1;

            while (choice != 6)
            {
                Console.Clear();
                DisplayPlayerInfo();
                ShowMenu();

                Console.Write("\nSelect a choice: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        RecordEvent();
                        break;
                    case 4:
                        SaveGoals();
                        break;
                    case 5:
                        LoadGoals();
                        break;
                    case 6:
                        Console.WriteLine("Quitting... Goodbye!");
                        Thread.Sleep(600);
                        break;
                    default:
                        Console.WriteLine("Unknown option. Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine($"Level: {GetLevel()}");
        }

        private string GetLevel()
        {
            if (_score >= 2000) return "Level 3 🏆";
            if (_score >= 1000) return "Level 2 ⭐";
            return "Level 1 🌱";
        }

        public void CreateGoal()
        {
            Console.Clear();
            Console.WriteLine("Create a new goal:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choose type: ");
            string t = Console.ReadLine();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            int points = ReadIntFromConsole("Enter points for completing (integer): ");

            if (t == "1")
            {
                var g = new SimpleGoal(name, desc, points);
                _goals.Add(g);
                Console.WriteLine("SimpleGoal created!");
            }
            else if (t == "2")
            {
                var g = new EternalGoal(name, desc, points);
                _goals.Add(g);
                Console.WriteLine("EternalGoal created!");
            }
            else if (t == "3")
            {
                int target = ReadIntFromConsole("Enter target number of times to complete: ");
                int bonus = ReadIntFromConsole("Enter bonus points for finishing the target: ");
                var g = new checklistGoal(name, desc, points, target, bonus);
                _goals.Add(g);
                Console.WriteLine("ChecklistGoal created!");
            }
            else
            {
                Console.WriteLine("Unknown type. No goal created.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public void ListGoalDetails()
        {
            Console.Clear();
            Console.WriteLine("Goals:");
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
            }
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
                }
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        public void RecordEvent()
        {
            Console.Clear();
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record. Create a goal first. Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Which goal did you complete?");
            for (int i = 0; i < _goals.Count; i++)
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");

            int index = ReadIntFromConsole("Enter number of goal: ") - 1;
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal selection. Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            Console.Write("\nRecording event");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300); // ⏳ Exceeding requirement
                Console.Write(".");
            }

            Console.WriteLine();

            int pointsEarned = _goals[index].RecordEvent();

            Console.WriteLine("\nCalculating rewards");
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }
            Console.WriteLine();
            Thread.Sleep(600);

            _score += pointsEarned;

            if (pointsEarned > 0)
            {
                Console.WriteLine($"\n🎉 Congratulations! You earned {pointsEarned} points!");
            }
            else
            {
                Console.WriteLine("\nNo points awarded (goal may already be completed).");
            }

            Console.WriteLine($"Total Score: {_score}    {GetLevel()}");
            if (_score % 500 == 0 && _score > 0)
            {
                Console.WriteLine("Nice! You've reached a milestone — keep going!");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        public void SaveGoals()
        {
            Console.Write("Enter filename to save to (example: savefile.txt): ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    // Save score on first line
                    sw.WriteLine(_score);
                    // Then save each goal using its string representation
                    foreach (var g in _goals)
                    {
                        sw.WriteLine(g.GetStringRepresentation());
                    }
                }
                Console.WriteLine($"Saved to {filename} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public void LoadGoals()
        {
            Console.Write("Enter filename to load (example: savefile.txt): ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File doesn't exist. Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length == 0)
                {
                    Console.WriteLine("File empty. Press Enter to continue...");
                    Console.ReadLine();
                    return;
                }

                // First line should be score
                int fileScore = 0;
                if (int.TryParse(lines[0], out fileScore))
                {
                    _score = fileScore;
                }
                else
                {
                    Console.WriteLine("Warning: first line of file not a valid score; keeping current score.");
                }

                // Clear current goals and recreate
                _goals.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');

                    string type = parts[0];

                    if (type == "SimpleGoal")
                    {
                        // SimpleGoal|name|description|points|isComplete
                        string name = parts[1];
                        string desc = parts[2];
                        int pts = int.Parse(parts[3]);
                        bool isComplete = bool.Parse(parts[4]);
                        var g = new SimpleGoal(name, desc, pts);
                        if (isComplete)
                        {
                            // Simulate completion to set internal flag.
                            g.RecordEvent();
                        }
                        _goals.Add(g);
                    }
                    else if (type == "EternalGoal")
                    {
                        // EternalGoal|name|description|points
                        string name = parts[1];
                        string desc = parts[2];
                        int pts = int.Parse(parts[3]);
                        var g = new EternalGoal(name, desc, pts);
                        _goals.Add(g);
                    }
                    else if (type == "ChecklistGoal")
                    {
                        // ChecklistGoal|name|description|points|bonus|target|amountCompleted
                        string name = parts[1];
                        string desc = parts[2];
                        int pts = int.Parse(parts[3]);
                        int bonus = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int amountCompleted = int.Parse(parts[6]);

                        var cg = new checklistGoal(name, desc, pts, target, bonus);
                        // Simulate amountCompleted times to restore internal counter (we don't adjust _score)
                        for (int k = 0; k < amountCompleted; k++)
                        {
                            cg.RecordEvent();
                        }
                        _goals.Add(cg);
                    }
                }

                Console.WriteLine($"Loaded {filename} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        // Helper to read integers safely
        private int ReadIntFromConsole(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (int.TryParse(s, out int v)) return v;
                Console.WriteLine("Please enter a valid integer.");
            }
        }
    }
}
