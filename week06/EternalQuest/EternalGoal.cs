using System;
using System.Collections.Generic;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            // Eternal goals are never complete, so always award points
            return _points;
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal|{_shortname}|{_description}|{_points}";
        }
    }
}