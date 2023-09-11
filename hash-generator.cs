using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace fileEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read configurations from app.config (assuming it's configured correctly)
            string inputPath = ConfigurationManager.AppSettings["inputPath"];
            string hashMode = ConfigurationManager.AppSettings["hashMode"];
            string outputDirectory = ConfigurationManager.AppSettings["outputDirectory"];

            // Validate inputPath
            if (string.IsNullOrEmpty(inputPath) || !File.Exists(inputPath))
            {
                Console.WriteLine("Invalid inputPath. Make sure it points to an existing file.");
                return;
            }

            // Validate outputDirectory and create it if it doesn't exist
            if (string.IsNullOrEmpty(outputDirectory) || !Directory.Exists(outputDirectory))
            {
                Console.WriteLine("Invalid outputDirectory. Creating the directory...");
                Directory.CreateDirectory(outputDirectory);
            }

            // Calculate the hash
            string hash = CalculateHash(inputPath, hashMode);

            // Display the hash
            Console.WriteLine($"Hash ({hashMode}): {hash}");

            // Example: Save the hash to a text file in the output directory
            string outputPath = Path.Combine(outputDirectory, "hash.txt");
            File.WriteAllText(outputPath, hash);
            Console.WriteLine($"Hash saved to: {outputPath}");
        }

        static string CalculateHash(string filePath, string hashMode)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                HashAlgorithm hashAlgorithm;

                switch (hashMode.ToLower())
                {
                    case "md5":
                        hashAlgorithm = MD5.Create();
                        break;
                    case "sha1":
                        hashAlgorithm = SHA1.Create();
                        break;
                    case "sha256":
                        hashAlgorithm = SHA256.Create();
                        break;
                    case "sha512":
                        hashAlgorithm = SHA512.Create();
                        break;
                    default:
                        throw new ArgumentException("Invalid hashMode specified.");
                }

                byte[] hashBytes = hashAlgorithm.ComputeHash(stream);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Format each byte as a two-digit hexadecimal number
                }

                return sb.ToString();
            }
        }
    }
}
