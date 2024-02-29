using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FileContentGeneration
{
    public class RandomCharsFileGenerator
    {
        public string WorkingDirectory => "Files with random chars";

        public string FileExtension => ".txt";

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; i++)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        private byte[] GenerateFileContent(int contentLength)
        {
            var generatedString = this.RandomString(contentLength);

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

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(this.WorkingDirectory))
            {
                Directory.CreateDirectory(this.WorkingDirectory);
            }

            File.WriteAllBytes($"{this.WorkingDirectory}//{fileName}", content);
        }
    }

}