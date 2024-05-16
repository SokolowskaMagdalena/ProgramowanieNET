using Newtonsoft.Json;

public class ManagerZadan
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
        string json = JsonConvert.SerializeObject(listaZadan, Newtonsoft.Json.Formatting.Indented);
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

    public int IloscZadan()
    {
        return listaZadan.Count;
    }

    public void OznaczZadanie(int id)
    {
        Zadanie zadanie = listaZadan.Find(z => z.Id == id);
        if (zadanie != null)
        {
            zadanie.CzyWykonane = !zadanie.CzyWykonane;
            Console.WriteLine($"Zadanie o ID {id} zmieniło status na: {(zadanie.CzyWykonane ? "Wykonane" : "Nie wykonane")}");
        }
        else
        {
            Console.WriteLine($"Zadanie o ID {id} nie istnieje.");
        }
    }

    public void SortujZadaniaPoDacie()
    {
        listaZadan.Sort((z1, z2) => z1.DataZakonczenia.CompareTo(z2.DataZakonczenia));
        Console.WriteLine("Lista zadań została posortowana według daty zakończenia.");
    }

    public void SortujZadaniaPoNazwie()
    {
        listaZadan.Sort((z1, z2) => z1.Nazwa.CompareTo(z2.Nazwa));
        Console.WriteLine("Lista zadań została posortowana według nazwy.");
    }

    public void SortujZadaniaPoPriorytecie()
    {
        listaZadan.Sort((z1, z2) => z1.Priorytet.CompareTo(z2.Priorytet));
        Console.WriteLine("Lista zadań została posortowana według priorytetu.");
    }
}
