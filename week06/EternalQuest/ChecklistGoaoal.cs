using System;
using System.Threading;
using System.Collections.Generic;

namespace EternalQuest

{
    public class checklistGoal : Goal
    {
        private int _amountCommpleted;
        private int _target;
        private int _bonus;

        public checklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
        {
            _amountCommpleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public override int RecordEvent()
        {
            _amountCommpleted++;
            if (_amountCommpleted == _target)
            {
                //celebration and delay before awarding bonus
                Console.WriteLine("🎉Congratulations! Bonus Incoming...");
                Console.Beep();
                Thread.Sleep(2000); //Exceeding Requirements
                return _points + _bonus;
            }
            else
            {
                return _points;
            }
            
        }

        public override bool IsComplete()
        {
            return _amountCommpleted >= _target;
        }

        public override string GetDetailsString()
        {
            return $"{base.GetDetailsString()} -- Currently completed: {_amountCommpleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{_shortname}|{_description}|{_points}|{_bonus}|{_target}|{_amountCommpleted}";
        }
    }
}