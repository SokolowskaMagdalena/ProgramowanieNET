using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj nazwę pliku źródłowego:");
        string nazwaPlikuZrodlowego = Console.ReadLine();

        Console.WriteLine("Podaj nazwę pliku docelowego:");
        string nazwaPlikuDocelowego = Console.ReadLine();

        try
        {
            if (!File.Exists(nazwaPlikuZrodlowego))
            {
                Console.WriteLine("Plik źródłowy nie istnieje.");
                return;
            }

            using (FileStream fsZrodlowy = new FileStream(nazwaPlikuZrodlowego, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsDocelowy = new FileStream(nazwaPlikuDocelowego, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    while ((bytesRead = fsZrodlowy.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsDocelowy.Write(buffer, 0, bytesRead);
                    }
                }
            }

            Console.WriteLine("Kopiowanie zakończone pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas kopiowania pliku: " + ex.Message);
        }
    }
}
