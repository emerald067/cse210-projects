// EXCEEDING REQUIREMENTS:
// 1. Added a "Mood" field to each journal entry.
// 2. Enhanced PromptGenerator to avoid repeating prompts until all have been used.
// These features make the journaling experience more helpful and realistic.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    // Write a new entry
                    string prompt = generator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine() ?? "";

                    Console.Write("How are you feeling today? ");
                    string mood = Console.ReadLine() ?? "";

                    string dateText = DateTime.Now.ToShortDateString();

                    Entry e = new Entry
                    {
                        _date = dateText,
                        _promptText = prompt,
                        _entryText = response,
                        _mood = mood
                    };

                    journal.AddEntry(e);
                    Console.WriteLine("Entry added.");
                    break;

                case "2":
                    // Display
                    journal.DisplayAll();
                    break;

                case "3":
                    // Load
                    Console.Write("Enter filename to load: ");
                    {
                        string filename = Console.ReadLine() ?? "";
                        try
                        {
                            journal.LoadFromFile(filename);
                            Console.WriteLine($"Loaded {journal.Count} entries from '{filename}'.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not load file: {ex.Message}");
                        }
                    }
                    break;

                case "4":
                    // Save
                    Console.Write("Enter filename to save: ");
                    {
                        string filename = Console.ReadLine() ?? "";
                        try
                        {
                            journal.SaveToFile(filename);
                            Console.WriteLine($"Journal saved to '{filename}'.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not save file: {ex.Message}");
                        }
                    }
                    break;

                case "5":
                    // Quit
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Please enter a valid option (1–5).");
                    break;
            }
        }
    }
}
