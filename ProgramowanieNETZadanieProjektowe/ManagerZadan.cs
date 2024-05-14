using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

class ManagerZadan
{
    private List<Zadanie> listaZadan;

    public ManagerZadan()
    {
        listaZadan = new List<Zadanie>();
    }

    public void DodajZadanie(Zadanie zadanie)
    {
        listaZadan.Add(zadanie);
    }

    public void UsunZadanie(int id)
    {
        Zadanie zadanie = listaZadan.Find(z => z.Id == id);
        if (zadanie != null)
        {
            listaZadan.Remove(zadanie);
            Console.WriteLine($"Zadanie o ID {id} zostało usunięte.");
        }
        else
        {
            Console.WriteLine($"Zadanie o ID {id} nie istnieje.");
        }
    }

    public void WyswietlZadania()
    {
        if (listaZadan.Count == 0)
        {
            Console.WriteLine("Brak zadań do wyświetlenia.");
            return;
        }

        Console.WriteLine("Lista zadań:");
        foreach (var zadanie in listaZadan)
        {
            Console.WriteLine(zadanie);
        }
    }

    public void SerializujDoJSON(string nazwaPliku)
    {
        string json = JsonConvert.SerializeObject(listaZadan, Formatting.Indented);
        File.WriteAllText(nazwaPliku, json);
        Console.WriteLine($"Lista zadań została zserializowana do pliku: {nazwaPliku}");
    }

    public void DeserializujZJSON(string nazwaPliku)
    {
        if (!File.Exists(nazwaPliku))
        {
            Console.WriteLine($"Plik {nazwaPliku} nie istnieje.");
            return;
        }

        string json = File.ReadAllText(nazwaPliku);
        listaZadan = JsonConvert.DeserializeObject<List<Zadanie>>(json);
        Console.WriteLine($"Lista zadań została zdeserializowana z pliku: {nazwaPliku}");
    }
}
