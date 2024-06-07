using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            WypiszPomoc();
            return;
        }

        string tryb = args[0];
        string sciezkaPliku = "";
        string sciezkaKlucza = "";

        for (int i = 1; i < args.Length; i++)
        {
            if (args[i] == "-file" && i + 1 < args.Length)
            {
                sciezkaPliku = args[i + 1];
                i++;
            }
            else if (args[i] == "-key" && i + 1 < args.Length)
            {
                sciezkaKlucza = args[i + 1];
                i++;
            }
        }

        if (string.IsNullOrEmpty(sciezkaPliku) || string.IsNullOrEmpty(sciezkaKlucza))
        {
            Console.WriteLine("Nie podano ścieżki pliku lub klucza.");
            WypiszPomoc();
            return;
        }

        try
        {
            switch (tryb)
            {
                case "-e":
                    SzyfrujPlik(sciezkaPliku, sciezkaKlucza);
                    break;
                case "-d":
                    DeszyfrujPlik(sciezkaPliku, sciezkaKlucza);
                    break;
                default:
                    Console.WriteLine("Nieznany tryb.");
                    WypiszPomoc();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static void WypiszPomoc()
    {
        Console.WriteLine("Użycie:");
        Console.WriteLine("  -e -file <ścieżka do pliku> -key <ścieżka do klucza>  Szyfrowanie pliku");
        Console.WriteLine("  -d -file <ścieżka do pliku> -key <ścieżka do klucza>  Deszyfrowanie pliku");
    }

    static void SzyfrujPlik(string sciezkaPliku, string sciezkaKlucza)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
        {
            string kluczPrywatny = rsa.ToXmlString(true);
            File.WriteAllText(sciezkaKlucza, kluczPrywatny);

            byte[] dane = File.ReadAllBytes(sciezkaPliku);
            byte[] zaszyfrowaneDane = rsa.Encrypt(dane, true);

            File.WriteAllBytes(sciezkaPliku + ".encrypted", zaszyfrowaneDane);
            Console.WriteLine("Plik został zaszyfrowany.");
        }
    }

    static void DeszyfrujPlik(string sciezkaPliku, string sciezkaKlucza)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
        {
            string kluczPrywatny = File.ReadAllText(sciezkaKlucza);
            rsa.FromXmlString(kluczPrywatny);

            byte[] zaszyfrowaneDane = File.ReadAllBytes(sciezkaPliku);
            byte[] odszyfrowaneDane = rsa.Decrypt(zaszyfrowaneDane, true);

            File.WriteAllBytes(sciezkaPliku.Replace(".encrypted", ".decrypted"), odszyfrowaneDane);
            Console.WriteLine("Plik został odszyfrowany.");
        }
    }
}
