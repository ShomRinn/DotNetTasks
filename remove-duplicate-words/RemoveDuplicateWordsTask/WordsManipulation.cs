using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RemoveDuplicateWordsTask
{
    /// <summary>
    /// Words manipulation class.
    /// </summary>
    public static class WordsManipulation
    {
        /// <summary>
        /// Removes all duplicate words from string, leaving only single (first) words entries.
        /// Case sensitivity of finding duplicates depends on the caseSensitive argument.
        /// By word we shall mean the unit that consists only of latin alphabet characters and numbers.
        /// All other characters should be considered delimiters between words.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="caseSensitive">Defines case sensitivity.</param>
        /// <exception cref="ArgumentException">If source text is null or empty.</exception>
        public static void RemoveDuplicateWords(ref string? text, bool caseSensitive)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("source text is null or empty.", nameof(text));
            }

            string space = @"\b[\w\d]+\b";
            var uniqueWord = new HashSet<string>(caseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);

            text = Regex.Replace(text, space, match =>
            {
                string word = match.Value;
                if (uniqueWord.Contains(word))
                {
                    return string.Empty;
                }

                uniqueWord.Add(word);
                return word;
            });
        }
    }
}
