global using NUnit.Framework;

using System;
using System.IO;
using FileContentGeneration.Solution;


namespace FileContentGenerationTests
{
    public class FileGeneratorTests
    {
        [Test]
        public void TestRandomBytesFileGenerator()
        {
            // Arrange
            var fileGenerator = new RandomBytesFileGenerator();
            var filesCount = 5;
            var contentLength = 1024;

            // Act
            fileGenerator.GenerateFiles(filesCount, contentLength);

            // Assert
            var dirInfo = new DirectoryInfo(fileGenerator.WorkingDirectory);
            Assert.That(dirInfo.GetFiles().Length, Is.EqualTo(filesCount));
        }

        [Test]
        public void TestRandomCharsFileGenerator()
        {
            // Arrange
            var fileGenerator = new RandomCharsFileGenerator();
            var filesCount = 5;
            var contentLength = 1024;

            // Act
            fileGenerator.GenerateFiles(filesCount, contentLength);

            // Assert
            var dirInfo = new DirectoryInfo(fileGenerator.WorkingDirectory);
            Assert.That(dirInfo.GetFiles().Length, Is.EqualTo(filesCount));
        }

        [Test]
        public void TestFileContentLength()
        {
            // Arrange
            var fileGenerator = new RandomCharsFileGenerator();
            var filesCount = 1;
            var contentLength = 1024;

            // Act
            fileGenerator.GenerateFiles(filesCount, contentLength);

            // Assert
            var dirInfo = new DirectoryInfo(fileGenerator.WorkingDirectory);
            var firstFile = dirInfo.GetFiles()[0];
            var fileContent = File.ReadAllBytes(firstFile.FullName);
            Assert.That(fileContent.Length / sizeof(char), Is.EqualTo(contentLength));
        }

        [TearDown]
        public void Cleanup()
        {
            // Remove generated directories and files after each test
            var byteGenerator = new RandomBytesFileGenerator();
            if (Directory.Exists(byteGenerator.WorkingDirectory))
            {
                Directory.Delete(byteGenerator.WorkingDirectory, true);
            }

            var charGenerator = new RandomCharsFileGenerator();
            if (Directory.Exists(charGenerator.WorkingDirectory))
            {
                Directory.Delete(charGenerator.WorkingDirectory, true);
            }
        }
    }
}
