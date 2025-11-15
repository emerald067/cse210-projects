using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class ScriptureLibrary
    {
        private List<Scripture> _scriptures;
        private Random _random;

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>();
            _random = new Random();

            // Add scriptures directly in code
            AddScripture("Proverbs 3:5-6",
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths.");

            AddScripture("John 3:16",
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life.");

            AddScripture("Philippians 4:13",
                "I can do all things through Christ which strengtheneth me.");

            AddScripture("Moroni 10:4-5",
                "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, " +
                "in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, " +
                "with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. " +
                "And by the power of the Holy Ghost ye may know the truth of all things.");

            AddScripture("Ether 12:27",
                "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; " +
                "and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, " +
                "and have faith in me, then will I make weak things become strong unto them.");

            AddScripture("Alma 37:6",
                "Now ye may suppose that this is foolishness in me; but behold I say unto you, " +"that by small and simple things are great things brought to pass; " +
                "and small means in many instances doth confound the wise.");
        }

        // Add scripture to the library, parsing reference
        private void AddScripture(string referenceText, string text)
        {
            var reference = ParseReference(referenceText);
            var scripture = new Scripture(reference, text);
            _scriptures.Add(scripture);
        }

        // Return a random scripture
        public Scripture GetRandomScripture()
        {
            if (_scriptures.Count == 0) return null;
            int idx = _random.Next(_scriptures.Count);
            return _scriptures[idx];
        }

        // Parse reference string (handles single verse or range)
        private Reference ParseReference(string refText)
        {
            var bookAndRest = refText.Split(' ', 2);
            var book = bookAndRest[0];
            var chapterAndVerse = bookAndRest[1]; // "3:5-6" or "3:16"

            var chapterPart = chapterAndVerse.Split(':')[0];
            var versePart = chapterAndVerse.Split(':')[1];

            if (versePart.Contains('-'))
            {
                var rangeParts = versePart.Split('-');
                return new Reference(book, int.Parse(chapterPart), int.Parse(rangeParts[0]), int.Parse(rangeParts[1]));
            }
            else
            {
                return new Reference(book, int.Parse(chapterPart), int.Parse(versePart));
            }
        }
    }
}
