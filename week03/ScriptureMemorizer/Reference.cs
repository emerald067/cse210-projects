using System;

namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int _endVerse; // 0 if not a range

        // Constructor for single verse (e.g., "John 3:16")
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = 0;
        }

        // Constructor for verse range (e.g., "Proverbs 3:5-6")
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        // Returns the reference as a display string.
        public string GetDisplayText()
        {
            if (_endVerse > 0)
            {
                return $"{_book} {_chapter}:{_verse}-{_endVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_verse}";
            }
        }

        // Optional getters (if needed)
        public string Book => _book;
        public int Chapter => _chapter;
        public int Verse => _verse;
        public int EndVerse => _endVerse;
    }
}



