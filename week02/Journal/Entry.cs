using System;
public class Entry
{
    // Create the member variable for the date.
    public string _date = "";

    // Create the member variable for the prompt text.
    public string _promptText = "";

    // Create the member variable for the entry text.
    public string _entryText = "";

    // Create the member variable for the mood.
    public string _mood = "";

    // Create the Display method.
    public void Display()
    {
        System.Console.WriteLine($"Date: {_date}");
        System.Console.WriteLine($"Prompt: {_promptText}");
        System.Console.WriteLine($"Mood: {_mood}");
        System.Console.WriteLine($"Entry: {_entryText}");
        System.Console.WriteLine(new string('-', 40));
    }

    // use a separator unlikely to be in the text
    private const string SEP = "~|~";
    public string Serialize()
    {
        return $"{_date}{SEP}{_promptText}{SEP}{_entryText}{SEP}{_mood}";
    }

    public static Entry Deserialize(string line)
    {
        string[] parts = line.Split(SEP);
        // Handle short/odd lines gracefully.
        string date = parts.Length > 0 ? parts[0] : "";
        string prompt = parts.Length > 1 ? parts[1] : "";
        string mood = parts.Length > 3 ? parts[3] : "";
        string text = parts.Length > 2 ? parts[2] : "";

        return new Entry { _date = date, _promptText = prompt, _entryText = text, _mood = mood };
    }
}