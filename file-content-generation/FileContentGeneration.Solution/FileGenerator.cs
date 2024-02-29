using System;
using System.IO;

namespace FileContentGeneration.Solution
{
    public abstract class FileGenerator
    {
        public abstract string WorkingDirectory { get; }

        public abstract string FileExtension { get; }

        public abstract byte[] GenerateFileContent(int contentLength);

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; i++)
            {
                var generatedFileContent = GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                WriteBytesToFile(generatedFileName, generatedFileContent);
            }
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
