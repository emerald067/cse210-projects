using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verse range (Proverbs 3:5-6)
            var reference = new Reference("Proverbs", 3, 5, 6);
            var text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                       "In all thy ways acknowledge him, and he shall direct thy paths.";

            var scripture = new Scripture(reference, text);

            // Number of words to hide each step. 
            const int wordsToHideEachStep = 3;

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

                // If scripture already completely hidden, end (final display already shown)
                if (scripture.IsCompletelyHidden())
                {
                    break;
                }

                scripture.HideRandomWords(wordsToHideEachStep);

                // After hiding, if scripture is now completely hidden, show final and exit loop on next iteration.
                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden. Press Enter to finish.");
                    Console.ReadLine();
                    break;
                }
            }

            // Program ends
        }
    }
}



