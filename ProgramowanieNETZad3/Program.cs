using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sciezkaDoPliku = @"C:\Users\magda\Desktop\test.txt";

        try
        {
            using (FileStream fs = new FileStream(sciezkaDoPliku, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    string zawartosc = reader.ReadToEnd();
                    Console.WriteLine("Zawartość pliku:");
                    Console.WriteLine(zawartosc);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik nie został odnaleziony.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Wystąpił błąd podczas odczytu pliku: " + ex.Message);
        }
    }
}
