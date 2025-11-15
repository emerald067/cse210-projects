using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        // Constructor: accepts a Reference and the scripture text (single string).
        // Splits on whitespace to create Word tokens.
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _random = new Random();
            _words = new List<Word>();

            // Split by whitespace; preserve punctuation as part of tokens.
            var tokens = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var t in tokens)
            {
                _words.Add(new Word(t));
            }
        }

        // Hide up to numberToHide words. Chooses from only currently visible words.
        // If fewer visible words remain than requested, hides all remaining.
        public void HideRandomWords(int numberToHide)
        {
            var visibleIndices = _words
                .Select((w, i) => new { Word = w, Index = i })
                .Where(x => !x.Word.IsHidden())
                .Select(x => x.Index)
                .ToList();

            if (visibleIndices.Count == 0)
            {
                return;
            }

            int toHide = Math.Min(numberToHide, visibleIndices.Count);

            // Shuffle visibleIndices (Fisher-Yates)
            for (int i = visibleIndices.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                int tmp = visibleIndices[i];
                visibleIndices[i] = visibleIndices[j];
                visibleIndices[j] = tmp;
            }

            for (int k = 0; k < toHide; k++)
            {
                int idx = visibleIndices[k];
                _words[idx].Hide();
            }
        }

        // Return the scripture display: reference + words joined by spaces.
        public string GetDisplayText()
        {
            var wordDisplays = _words.Select(w => w.GetDisplayText());
            return $"{_reference.GetDisplayText()}\n\n{string.Join(" ", wordDisplays)}";
        }

        // True when all words are hidden.
        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}


