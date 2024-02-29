#pragma warning disable CS8604
#pragma warning disable CS8600
#pragma warning disable CA1307

using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Streams
{
    /// <summary>
    /// Class for training streams and operations with it.
    /// </summary>
    public static class StreamsExtension
    {
        /// <summary>
        /// Implements the logic of byte copying the contents of the source text file using class FileStream as a backing store stream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int ByteCopyWithFileStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bytesCopied = 0;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
        using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[1024];

            int bytesRead;
            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destinationStream.Write(buffer, 0, bytesRead);
                bytesCopied += bytesRead;
            }
        }

            return bytesCopied;
        }

        /// <summary>
        /// Implements the logic of byte copying the contents of the source text file using MemoryStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int ByteCopyWithMemoryStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            byte[] sourceBytes = File.ReadAllBytes(sourcePath);

            byte[] destinationBytes;
            using (MemoryStream memoryStream = new MemoryStream(sourceBytes))
            {
                destinationBytes = memoryStream.ToArray();
            }

            File.WriteAllBytes(destinationPath, destinationBytes);

            return destinationBytes.Length;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using FileStream buffer.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithFileStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bufferSize = 1024 * 1024;
            byte[] buffer = new byte[bufferSize];
            int totalBytes = 0;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                    totalBytes += bytesRead;
                }
            }

            return totalBytes;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using MemoryStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithMemoryStream(string? sourcePath, string? destinationPath)
        {
            byte[] buffer;
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[sourceStream.Length];
                sourceStream.Read(buffer, 0, buffer.Length);
            }

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] readBuffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = memoryStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                    {
                        destinationStream.Write(readBuffer, 0, bytesRead);
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using FileStream and class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithBufferedStreamForFileStream(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bufferSize = 4096; // 4KB buffer. Adjust this value based on your specific requirements.
            int totalBytes = 0;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedSourceStream = new BufferedStream(sourceStream, bufferSize))
            using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            using (BufferedStream bufferedDestinationStream = new BufferedStream(destinationStream, bufferSize))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;
                while ((bytesRead = bufferedSourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bufferedDestinationStream.Write(buffer, 0, bytesRead);
                    totalBytes += bytesRead;
                }
            }

            return totalBytes;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using MemoryStream and class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithBufferedStreamForMemoryStream(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            byte[] sourceBytes;
            using (FileStream fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                sourceBytes = new byte[fs.Length];
                fs.Read(sourceBytes, 0, sourceBytes.Length);
            }

            int totalBytes = 0;
            byte[] destinationBytes;
            using (MemoryStream sourceStream = new MemoryStream(sourceBytes))
            using (BufferedStream bufferedSourceStream = new BufferedStream(sourceStream))
            using (MemoryStream destinationStream = new MemoryStream())
            using (BufferedStream bufferedDestinationStream = new BufferedStream(destinationStream))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = bufferedSourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bufferedDestinationStream.Write(buffer, 0, bytesRead);
                    totalBytes += bytesRead;
                }

                bufferedDestinationStream.Flush();
                destinationBytes = destinationStream.ToArray();
            }

            using (FileStream fs = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(destinationBytes, 0, destinationBytes.Length);
            }

            return totalBytes;
        }

        /// <summary>
        /// Implements the logic of block copying from provided link.
        /// </summary>
        /// <param name="link">URI specified as string from which to copy.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>Number of copied bytes.</returns>
        public static int DownloadByBlock(string? link, string? destinationPath)
        {
            int totalBytes = 0;
            using (WebClient client = new WebClient())
            {
                using (Stream dataStream = client.OpenRead(link))
                {
                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] dataBuffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = dataStream.Read(dataBuffer, 0, dataBuffer.Length)) > 0)
                        {
                            fileStream.Write(dataBuffer, 0, bytesRead);
                            totalBytes += bytesRead;
                        }
                    }
                }
            }

            return totalBytes;
        }

        /// <summary>
        /// Implements the logic of line-by-line copying of the contents of the source text file
        /// using FileStream and classes-adapters  StreamReader/StreamWriter.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded lines.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file are null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int LineCopy(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int lineCount = 0;

            using (StreamReader input = new StreamReader(sourcePath, Encoding.UTF8))
            using (StreamWriter output = new StreamWriter(destinationPath, false, Encoding.UTF8))
            {
                string? current = input.ReadLine();

                do
                {
                    if (current != null)
                    {
                        string? next = input.ReadLine();

                        if (next != null)
                        {
                            output.WriteLine(current);
                            lineCount++;
                            current = next;
                        }
                        else
                        {
                            output.Write(current);
                            lineCount++;
                            current = null;
                        }
                    }
                }
                while (current != null);
            }

            return lineCount;
        }

        /// <summary>
        /// Reads file content encoded with non Unicode encoding.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="encoding">Encoding name.</param>
        /// <returns>Uncoding file content.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or encoding string is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static string ReadEncodedText(string? sourcePath, string? encoding)
        {
            InputValidation(sourcePath);

            try
            {
                Encoding enc = Encoding.GetEncoding(encoding);
                using (StreamReader reader = new StreamReader(sourcePath, enc))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid encoding", nameof(encoding));
            }
        }

        /// <summary>
        /// Returns decompressed stream from file.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="method">Method used for compression (none, deflate, gzip).</param>
        /// <returns>Output stream.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static Stream DecompressStream(string? sourcePath, DecompressionMethods? method)
        {
            InputValidation(sourcePath);

            FileStream sourceFileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);

            switch (method)
            {
                case DecompressionMethods.None: return sourceFileStream;
                case DecompressionMethods.GZip: return new GZipStream(sourceFileStream, CompressionMode.Decompress);
                case DecompressionMethods.Deflate: return new DeflateStream(sourceFileStream, CompressionMode.Decompress);
                case DecompressionMethods.Brotli: return new BrotliStream(sourceFileStream, CompressionMode.Decompress);
                default: throw new ArgumentException("Unsupported decompression method", nameof(method));
            }
        }

        /// <summary>
        /// Calculates hash of stream using specified algorithm.
        /// </summary>
        /// <param name="stream">Source stream.</param>
        /// <param name="hashAlgorithmName">
        ///     Hash algorithm ("MD5","SHA1","SHA256" and other supported by .NET).
        /// </param>
        /// <returns>Hash.</returns>
        public static string CalculateHash(this Stream? stream, string? hashAlgorithmName)
        {
            using HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashAlgorithmName);

            if (hashAlgorithm == null)
            {
                throw new ArgumentException($"Unsupported hash algorithm: {hashAlgorithmName}", nameof(hashAlgorithmName));
            }

            byte[] hash = hashAlgorithm.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToUpperInvariant();
        }

        private static void InputValidation(string? sourcePath, string? destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} cannot be null or empty or whitespace.", nameof(sourcePath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }

            if (string.IsNullOrWhiteSpace(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} cannot be null or empty or whitespace", nameof(destinationPath));
            }
        }

        private static void InputValidation(string? sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} cannot be null or empty or whitespace.", nameof(sourcePath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }
        }
    }
}
