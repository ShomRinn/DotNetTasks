﻿using System;
using System.Linq;
using System.Text;

namespace FileContentGeneration.Solution
{
    public class RandomCharsFileGenerator : FileGenerator
    {
        public override string WorkingDirectory => "Files with random chars";

        public override string FileExtension => ".txt";

        public override byte[] GenerateFileContent(int contentLength)
        {
            var generatedString = RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        private string RandomString(int size)
        {
            var random = new Random();

            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
        }
    }
}
