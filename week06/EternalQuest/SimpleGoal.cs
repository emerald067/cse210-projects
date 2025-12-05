using System;
using System.Collections.Generic;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _iscomplete;
        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
            _iscomplete = false;
        }

        public override int RecordEvent()
        {
            if (!_iscomplete)
            {
                _iscomplete = true;
                return _points;
            }
            else
            {
                return 0; // No points if already complete
            }
        }

        public override bool IsComplete()
        {
            return _iscomplete;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal|{_shortname}|{_description}|{_points}|{_iscomplete}";
        }
    }
    
}