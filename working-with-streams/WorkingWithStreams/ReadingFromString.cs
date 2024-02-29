using System;
using System.IO;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromString
    {
        public static string ReadAllStreamContent(StringReader stringReader)
        {
            return stringReader.ReadToEnd();
        }

        public static string ReadCurrentLine(StringReader stringReader)
        {
            return stringReader.ReadLine();
        }

        public static bool ReadNextCharacter(StringReader stringReader, out char currentChar)
        {
            int result = stringReader.Read();
            if (result != -1)
            {
                currentChar = (char)result;
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static bool PeekNextCharacter(StringReader stringReader, out char currentChar)
        {
            int result = stringReader.Peek();
            if (result != -1)
            {
                currentChar = (char)result;
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static char[] ReadCharactersToBuffer(StringReader stringReader, int count)
        {
            char[] buffer = new char[count];
            stringReader.ReadBlock(buffer, 0, count);
            return buffer;
        }
    }
}
