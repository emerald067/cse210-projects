public class PromptGenerator
{
    private readonly List<string> _allPrompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        // EXCEEDING REQUIREMENTS: Added more prompts to enhance variety.
        "What is one small win I had today?",
        "What is something I learned today?",
        "Who made me smile today and why?",
        "What challenge did I face today and how did I handle it?",
        "What am I grateful for today?",
        "How did I help someone today?",
        "Which moment today am I most grateful for?"
    };

    private List<string> _unusedPrompts = new List<string>();
    private readonly Random _rand = new Random();

    public PromptGenerator()
    {
        ResetPromptPool();
    }

    private void ResetPromptPool()
    {
        _unusedPrompts = new List<string>(_allPrompts);
    }

    public string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
            ResetPromptPool();

        int index = _rand.Next(_unusedPrompts.Count);
        string selected = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);

        return selected;
    }
}
