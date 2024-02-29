using System;
using System.IO;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class WritingToString
    {
        public static void WriteString(StringWriter stringWriter, string contentToWrite)
        {
            stringWriter.Write(contentToWrite);
        }

        public static void WriteChar(StringWriter stringWriter, char charToWrite)
        {
            stringWriter.Write(charToWrite);
        }

        public static void WriteInteger(StringWriter stringWriter, int integerToWrite)
        {
            stringWriter.Write(integerToWrite);
        }

        public static void WriteIntegerWithNewLine(StringWriter stringWriter, int integerToWrite)
        {
            stringWriter.WriteLine(integerToWrite);
        }

        public static void WriteFloat(StringWriter stringWriter, float floatToWrite)
        {
            stringWriter.Write(floatToWrite);
        }

        public static void WriteFloatWithNewLine(StringWriter stringWriter, float floatToWrite)
        {
            stringWriter.WriteLine(floatToWrite);
        }

        public static void WriteBooleansWithNewLines(StringWriter stringWriter, bool firstBoolean, bool secondBoolean, bool thirdBoolean)
        {
            stringWriter.WriteLine(firstBoolean);
            stringWriter.WriteLine(secondBoolean);
            stringWriter.Write(thirdBoolean);
        }

        public static void WriteCharBuffer(StringWriter stringWriter, char[] buffer)
        {
            stringWriter.Write(buffer, 2, 3);
        }

        public static void WriteCharBufferWithNewLines(StringWriter stringWriter, char[] buffer)
        {
            for (int i = 1; i < buffer.Length - 1; i++)
            {
                stringWriter.Write(buffer[i]);
            }

            stringWriter.Write('*');
        }
    }
}
