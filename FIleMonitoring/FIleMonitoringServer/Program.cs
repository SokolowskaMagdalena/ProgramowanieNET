using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

class AsyncServer
{
    private const int Port = 5000;
    private const string DataDirectory = "ClientData";

    private static readonly byte[] AesKey = Encoding.UTF8.GetBytes("0123456789abcdef0123456789abcdef");
    private static readonly byte[] AesIV = Encoding.UTF8.GetBytes("abcdef0123456789");

    public static async Task StartServerAsync()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, Port);
        listener.Start();
        Console.WriteLine("Server started and waiting for connections...");

        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
            string clientIp = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            Console.WriteLine($"Client connected: {clientIp}");
            _ = HandleClientAsync(client, clientIp);
        }
    }

    private static async Task HandleClientAsync(TcpClient client, string clientIp)
    {
        string clientDataPath = Path.Combine(DataDirectory, $"{clientIp}.txt");

        using (NetworkStream stream = client.GetStream())
        {
            while (true)
            {
                byte[] dataLengthBuffer = new byte[4];
                int bytesRead = await stream.ReadAsync(dataLengthBuffer, 0, dataLengthBuffer.Length);
                if (bytesRead == 0) 
                    break;

                int dataLength = BitConverter.ToInt32(dataLengthBuffer, 0);
                byte[] buffer = new byte[dataLength];
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) 
                    break;

                string receivedData = AesEncryptionHelper.DecryptStringFromBytes_Aes(buffer, AesKey, AesIV);

                string response;
                if (!File.Exists(clientDataPath))
                {
                    SaveInitialData(clientDataPath, receivedData);
                    response = "Initial data received and saved.";
                }
                else
                {
                    response = CompareWithInitialData(clientDataPath, receivedData, out string updatedData);
                    File.WriteAllText(clientDataPath, updatedData);
                }

                byte[] encryptedResponse = AesEncryptionHelper.EncryptStringToBytes_Aes(response, AesKey, AesIV);
                byte[] responseLength = BitConverter.GetBytes(encryptedResponse.Length);

                await stream.WriteAsync(responseLength, 0, responseLength.Length);
                await stream.WriteAsync(encryptedResponse, 0, encryptedResponse.Length);
            }
        }

        client.Close();
        Console.WriteLine("Client disconnected.");
    }

    private static void SaveInitialData(string filePath, string data)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        File.WriteAllText(filePath, data);
    }

    private static string CompareWithInitialData(string filePath, string data, out string updatedData)
    {
        var initialData = File.ReadAllText(filePath);
        var initialChecksumData = new ConcurrentDictionary<string, string>();
        var newChecksumData = new ConcurrentDictionary<string, string>();

        foreach (var line in initialData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = line.Split(new[] { '|' }, 2);
            if (parts.Length == 2)
            {
                initialChecksumData[parts[0]] = parts[1].Trim();
            }
        }

        foreach (var line in data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = line.Split(new[] { '|' }, 2);
            if (parts.Length == 2)
            {
                newChecksumData[parts[0]] = parts[1].Trim();
            }
        }

        StringBuilder differences = new StringBuilder();
        StringBuilder updatedDataBuilder = new StringBuilder();

        foreach (var entry in newChecksumData)
        {
            if (initialChecksumData.TryGetValue(entry.Key, out string initialChecksum))
            {
                if (initialChecksum != entry.Value)
                {
                    differences.AppendLine($"{entry.Key}: Checksum changed.");
                    WriteToEventLog($"{entry.Key}: Checksum changed.");
                    initialChecksumData[entry.Key] = entry.Value;
                }
            }
            else
            {
                differences.AppendLine($"{entry.Key}: New file detected.");
                WriteToEventLog($"{entry.Key}: New file detected.");
                initialChecksumData[entry.Key] = entry.Value;
            }
            updatedDataBuilder.AppendLine($"{entry.Key}|{entry.Value}");
        }

        foreach (var entry in initialChecksumData)
        {
            if (!newChecksumData.ContainsKey(entry.Key))
            {
                differences.AppendLine($"{entry.Key}: File removed.");
                WriteToEventLog($"{entry.Key}: File removed.");
            }
        }

        updatedData = updatedDataBuilder.ToString();
        return differences.Length > 0 ? differences.ToString() : "No differences detected.";
    }

    private static void WriteToEventLog(string message)
    {
        EventLog.WriteEntry("Application", message, EventLogEntryType.Warning);
    }

    static async Task Main(string[] args)
    {
        await StartServerAsync();
    }
}
