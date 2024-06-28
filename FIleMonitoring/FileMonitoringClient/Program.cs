using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

class AsyncClient
{
    private const int Port = 5000;
    private const string ServerIp = "127.0.0.1";
    private const string DirectoryPath = @"C:\Windows\System32";

    private static readonly byte[] AesKey = Encoding.UTF8.GetBytes("0123456789abcdef0123456789abcdef");
    private static readonly byte[] AesIV = Encoding.UTF8.GetBytes("abcdef0123456789");

    public static async Task StartClientAsync()
    {
        TcpClient client = new TcpClient();
        await client.ConnectAsync(ServerIp, Port);
        Console.WriteLine("Connected to the server.");

        using (NetworkStream stream = client.GetStream())
        {
            while (true)
            {
                Console.WriteLine("Generating checksum data...");
                string checksumData = await GenerateChecksumDataAsync();

                byte[] encryptedData = AesEncryptionHelper.EncryptStringToBytes_Aes(checksumData, AesKey, AesIV);
                byte[] dataLength = BitConverter.GetBytes(encryptedData.Length);
                await stream.WriteAsync(dataLength, 0, dataLength.Length);
                await stream.WriteAsync(encryptedData, 0, encryptedData.Length);

                byte[] lengthBuffer = new byte[4];
                int bytesRead = await stream.ReadAsync(lengthBuffer, 0, lengthBuffer.Length);
                if (bytesRead == 0) 
                    break;

                int responseLength = BitConverter.ToInt32(lengthBuffer, 0);
                byte[] responseBuffer = new byte[responseLength];
                bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
                if (bytesRead == 0) 
                    break;

                string response = AesEncryptionHelper.DecryptStringFromBytes_Aes(responseBuffer, AesKey, AesIV);
                Console.WriteLine($"Server response: {response}");

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        client.Close();
        Console.WriteLine("Client disconnected.");
    }

    private static async Task<string> GenerateChecksumDataAsync()
    {
        var checksumResults = new ConcurrentBag<string>();

        var tasks = new List<Task>();

        foreach (var file in GetFiles(DirectoryPath))
        {
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    string checksum = CalculateChecksum(file);
                    checksumResults.Add($"{file}|{checksum}");
                }
                catch (Exception) { }
            }));
        }

        await Task.WhenAll(tasks);

        StringBuilder result = new StringBuilder();
        foreach (var checksum in checksumResults)
        {
            result.AppendLine(checksum);
        }

        return result.ToString();
    }

    private static IEnumerable<string> GetFiles(string path)
    {
        var files = new List<string>();
        var directories = new Stack<string>();

        directories.Push(path);

        while (directories.Count > 0)
        {
            var currentDir = directories.Pop();
            try
            {
                files.AddRange(Directory.GetFiles(currentDir));

                foreach (var subDir in Directory.GetDirectories(currentDir))
                {
                    directories.Push(subDir);
                }
            }
            catch (Exception) { }
        }

        return files;
    }

    private static string CalculateChecksum(string filePath)
    {
        using (FileStream stream = File.OpenRead(filePath))
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(stream);
                StringBuilder hashString = new StringBuilder(64);
                foreach (byte b in hash)
                {
                    hashString.Append(b.ToString("x2"));
                }
                return hashString.ToString();
            }
        }
    }

    static async Task Main(string[] args)
    {
        await StartClientAsync();
    }
}
