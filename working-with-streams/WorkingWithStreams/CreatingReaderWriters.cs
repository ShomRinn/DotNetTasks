using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace WorkingWithStreams
{
    public static class CreatingReaderWriters
    {
        public static StringReader CreateStringReader(string str)
        {
            return new StringReader(str);
        }

        public static StringWriter CreateStringWriter()
        {
            return new StringWriter();
        }

        public static StringWriter CreateStringWriterThatWritesToStringBuilder(StringBuilder stringBuilder)
        {
            return new StringWriter(stringBuilder);
        }

        public static StringWriter CreateStringWriterThatWritesCultureSpecificData(CultureInfo cultureInfo)
        {
            return new StringWriter(cultureInfo);
        }

        public static StreamReader CreateStreamReaderFromStream(Stream stream)
        {
            return new StreamReader(stream);
        }

        public static StreamWriter CreateStreamWriterToStream(Stream stream)
        {
            return new StreamWriter(stream);
        }
    }
}
