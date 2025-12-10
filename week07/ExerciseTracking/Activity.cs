using System;
using System.Collections.Generic;


namespace ExerciseTracking
{
    public abstract class Activity
    {
        private string _date;
        private int _minutes;

        public Activity(string date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        protected int GetMinutes()
        {
            return _minutes;
        }

        public abstract double GetDistance(); // miles
        public abstract double GetSpeed();    // mph
        public abstract double GetPace();     // min per mile

        public virtual string GetSummary()
        {
            return $"{_date} {GetType().Name} ({_minutes} min) - " +
                   $"Distance {GetDistance():0.0} miles, " +
                   $"Speed {GetSpeed():0.0} mph, " +
                   $"Pace {GetPace():0.0} min per mile";
        }
    }
}
