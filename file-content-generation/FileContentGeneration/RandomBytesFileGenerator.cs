using System;
using System.IO;

namespace FileContentGeneration
{
    public class RandomBytesFileGenerator
    {
        public string WorkingDirectory => "Files with random bytes";

        public string FileExtension => ".bytes";

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        private byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
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