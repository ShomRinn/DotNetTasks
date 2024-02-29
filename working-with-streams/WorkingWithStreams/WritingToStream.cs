using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace WorkingWithStreams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            while (!streamReader.EndOfStream)
            {
                int value = streamReader.Read();
                outputWriter.Write(value.ToString(CultureInfo.InvariantCulture));
            }
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            int character;

            while ((character = streamReader.Read()) >= 0)
            {
                outputWriter.Write((char)character);
            }

            outputWriter.Flush();
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            int value;
            while ((value = contentReader.Read()) >= 0)
            {
                string hexString = value.ToString("X2", CultureInfo.InvariantCulture);
                outputWriter.Write(hexString);
            }
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            int lineNumber = 1;
            string line;

            while ((line = contentReader.ReadLine()) != null)
            {
                string formattedLine = $"{lineNumber:D3} {line}";
                outputWriter.WriteLine(formattedLine);
                lineNumber++;
            }

            outputWriter.Flush();
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            HashSet<string> wordsToRemove = ReadWordsFromStreamReader(wordsReader);
            Regex wordRegex = new Regex(@"\b(\w+)\b");

            while (contentReader.Peek() >= 0)
            {
                string line = contentReader.ReadLine();
                string updatedLine = RemoveWordsFromLine(line, wordsToRemove, wordRegex);
                outputWriter.Write(updatedLine);
            }

            outputWriter.Flush();
        }

        private static HashSet<string> ReadWordsFromStreamReader(StreamReader wordsReader)
        {
            HashSet<string> words = new HashSet<string>();

            while (wordsReader.Peek() >= 0)
            {
                string word = wordsReader.ReadLine();
                words.Add(word);
            }

            return words;
        }

        private static string RemoveWordsFromLine(string line, HashSet<string> wordsToRemove, Regex wordRegex)
        {
            MatchEvaluator evaluator = match =>
            {
                string word = match.Groups[1].Value;
                return wordsToRemove.Contains(word) ? string.Empty : word;
            };

            string updatedLine = wordRegex.Replace(line, evaluator);

            return updatedLine;
        }
    }
}
