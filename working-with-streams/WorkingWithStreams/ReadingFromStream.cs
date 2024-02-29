using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            return streamReader.ReadToEnd();
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            return Enumerable.Range(0, int.MaxValue)
                     .Select(_ => streamReader.ReadLine())
                     .TakeWhile(line => line != null)
                     .ToArray();
        }

        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int character;
            while (!streamReader.EndOfStream)
            {
                character = streamReader.Peek();

                if (char.IsLetterOrDigit((char)character))
                {
                    stringBuilder.Append((char)streamReader.Read());
                }
                else
                {
                    break;
                }
            }

            return stringBuilder;
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
            List<char[]> result = new List<char[]>();
            string content = streamReader.ReadToEnd();

            for (int i = 0; i < content.Length; i += arraySize)
            {
                result.Add(content.Substring(i, Math.Min(arraySize, content.Length - i)).ToCharArray());
            }

            return result.ToArray();
        }
    }
}
