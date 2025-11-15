using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text; 
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        // Hide the word
        public void Hide()
        {
            _isHidden = true;
        }

        // Show the word (unhide)
        public void Show()
        {
            _isHidden = false;
        }

        // Check if hidden
        public bool IsHidden()
        {
            return _isHidden;
        }

        // Return either the original text or underscores matching the number of letters.
        // We preserve non-letter characters (punctuation) in place.
        public string GetDisplayText()
        {
            if (!_isHidden)
            {
                return _text;
            }

            // Replace each letter/digit char with underscore, keep punctuation/spaces
            // Count underscores only for letters/digits; punctuation remains visible.
            var sb = new StringBuilder(_text.Length);
            foreach (char c in _text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append('_');
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        // Optionally expose the raw text if needed
        public string Text => _text;
    }
}


