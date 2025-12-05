/*
EXCEEDING REQUIREMENTS:
- Added timed delays using Thread.Sleep() to simulate a game-like experience.
- Program waits before displaying congratulations and bonus rewards.
- Added player levels based on score progression.
- Added celebration messages and countdown effects.
- Added a sound(beep) when a checklict goal is completed.
*/

using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
