using System;
using System.Collections.Generic;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _shortname;
        protected string _description;
        protected int _points;

        public Goal(string name, string description, int points)
        {
            _shortname = name;
            _description = description;
            _points = points;
        }

        // Returns the points earned by recording the event
        public abstract int RecordEvent();
        
        // Returns whether the goal is complete
        public abstract bool IsComplete();
        
        // Returns a string representation of the goal's details
        public virtual string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_shortname} ({_description})";
        }

        
    // Returns a string representation for saving/loading
        public abstract string GetStringRepresentation(); 
    }
}