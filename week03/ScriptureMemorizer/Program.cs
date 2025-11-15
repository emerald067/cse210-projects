// Exceeding feature implemented:
// - Instead of a single scripture, the program uses a ScriptureLibrary class that stores multiple scriptures in-code.
// - Each time the program runs, it randomly selects a scripture for the user to memorize.
// - This exceeds the core requirement of using only one scripture and adds variety to the memorization practice.
// - Scriptures are included directly in the code, so no external files are needed.

using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the in-code scripture library
            ScriptureLibrary library = new ScriptureLibrary();
            Scripture scripture = library.GetRandomScripture();

            if (scripture == null)
            {
                Console.WriteLine("No scriptures found.");
                return;
            }

            Random random = new Random();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide more words, or type \"quit\" and press Enter to exit.");

                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Trim().ToLower() == "quit")
                {
                    break;
                }

                if (scripture.IsCompletelyHidden())
                {
                    break;
                }

                // Randomize number of words to hide each step (1-3)
                int wordsToHide = random.Next(1, 4);
                scripture.HideRandomWords(wordsToHide);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden. Press Enter to finish.");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
