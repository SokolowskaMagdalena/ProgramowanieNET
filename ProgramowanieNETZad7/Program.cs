using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string nazwaPlikuZrodlowego = "plik_zrodlowy.txt";
        string nazwaPlikuDocelowego = "plik_docelowy.txt";
        int wielkoscPlikuMB = 300;
        GenerujPlik(nazwaPlikuZrodlowego, wielkoscPlikuMB);

        TestujKopiowanie(nazwaPlikuZrodlowego, nazwaPlikuDocelowego);
    }

    static void GenerujPlik(string nazwaPliku, int wielkoscMB)
    {
        Console.WriteLine($"Generowanie pliku {nazwaPliku} o wielkości {wielkoscMB} MB...");
        byte[] dane = new byte[wielkoscMB * 1024 * 1024];
        Random rand = new Random();
        rand.NextBytes(dane);

        File.WriteAllBytes(nazwaPliku, dane);
        Console.WriteLine($"Plik {nazwaPliku} został wygenerowany.");
    }

    static void TestujKopiowanie(string nazwaPlikuZrodlowego, string nazwaPlikuDocelowego)
    {
        Console.WriteLine("Testowanie wydajności kopiowania plików...");

        Stopwatch stoper = new Stopwatch();

        stoper.Restart();
        File.Copy(nazwaPlikuZrodlowego, nazwaPlikuDocelowego, true);
        stoper.Stop();
        Console.WriteLine($"File.Copy: {stoper.ElapsedMilliseconds} ms");

        stoper.Restart();
        KopiujZaPomocaFileStream(nazwaPlikuZrodlowego, nazwaPlikuDocelowego);
        stoper.Stop();
        Console.WriteLine($"FileStream: {stoper.ElapsedMilliseconds} ms");

        stoper.Restart();
        KopiujZaPomocaBufferedStream(nazwaPlikuZrodlowego, nazwaPlikuDocelowego);
        stoper.Stop();
        Console.WriteLine($"BufferedStream: {stoper.ElapsedMilliseconds} ms");
    }

    static void KopiujZaPomocaFileStream(string zrodlo, string cel)
    {
        using (FileStream fsZrodlowy = new FileStream(zrodlo, FileMode.Open, FileAccess.Read))
        {
            using (FileStream fsDocelowy = new FileStream(cel, FileMode.Create, FileAccess.Write))
            {
                byte[] bufor = new byte[64 * 1024];
                int bytesRead;

                while ((bytesRead = fsZrodlowy.Read(bufor, 0, bufor.Length)) > 0)
                {
                    fsDocelowy.Write(bufor, 0, bytesRead);
                }
            }
        }
    }

    static void KopiujZaPomocaBufferedStream(string zrodlo, string cel)
    {
        using (FileStream fsZrodlowy = new FileStream(zrodlo, FileMode.Open, FileAccess.Read))
        {
            using (FileStream fsDocelowy = new FileStream(cel, FileMode.Create, FileAccess.Write))
            {
                using (BufferedStream bsZrodlowy = new BufferedStream(fsZrodlowy))
                {
                    using (BufferedStream bsDocelowy = new BufferedStream(fsDocelowy))
                    {
                        byte[] bufor = new byte[64 * 1024];
                        int bytesRead;

                        while ((bytesRead = bsZrodlowy.Read(bufor, 0, bufor.Length)) > 0)
                        {
                            bsDocelowy.Write(bufor, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}
