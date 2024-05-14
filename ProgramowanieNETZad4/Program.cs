using System;
using System.IO;


static void Main()
{
    string sciezkaDoPliku = @"C:\Users\magda\Desktop\test.txt";

    try
    {
        using (StreamReader reader = new StreamReader(sciezkaDoPliku))
        {
            string linia;

            while ((linia = reader.ReadLine()) != null)
            {
                for (int i = linia.Length - 1; i >= 0; i--)
                {
                    Console.Write(linia[i]);
                }
                Console.WriteLine();
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
