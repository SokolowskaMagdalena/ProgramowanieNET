using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ManagerZadan manager = new ManagerZadan();

        bool zakonczono = false;
        while (!zakonczono)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Dodaj zadanie");
            Console.WriteLine("2. Usuń zadanie");
            Console.WriteLine("3. Edytuj zadanie");
            Console.WriteLine("4. Oznacz zadanie jako ukończone/nieukończone");
            Console.WriteLine("5. Wyświetl zadania");
            Console.WriteLine("6. Sortuj zadania");
            Console.WriteLine("7. Zapisz listę zadań do pliku");
            Console.WriteLine("8. Wczytaj listę zadań z pliku");
            Console.WriteLine("9. Zakończ");

            Console.Write("Wybierz opcję: ");
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    DodajZadanie(manager);
                    break;
                case "2":
                    UsunZadanie(manager);
                    break;
                case "3":
                    EdytujZadanie(manager);
                    break;
                case "4":
                    OznaczZadanie(manager);
                    break;
                case "5":
                    manager.WyswietlZadania();
                    break;
                case "6":
                    SortujZadania(manager);
                    break;
                case "7":
                    ZapiszDoPliku(manager);
                    break;
                case "8":
                    WczytajZPliku(manager);
                    break;
                case "9":
                    zakonczono = true;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Wybierz ponownie.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DodajZadanie(ManagerZadan manager)
    {
        Console.Write("Podaj nazwę zadania: ");
        string nazwa = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nazwa))
        {
            Console.WriteLine("Nazwa zadania nie może być pusta.");
            return;
        }

        Console.Write("Podaj opis zadania: ");
        string opis = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(opis))
        {
            Console.WriteLine("Opis zadania nie może być pusty.");
            return;
        }

        Console.Write("Podaj datę zakończenia zadania (RRRR-MM-DD): ");
        DateTime dataZakonczenia;
        if (!DateTime.TryParse(Console.ReadLine(), out dataZakonczenia))
        {
            Console.WriteLine("Nieprawidłowy format daty. Podaj datę ponownie.");
            return;
        }

        Console.Write("Podaj priorytet zadania (liczba całkowita): ");
        int priorytet;
        if (!int.TryParse(Console.ReadLine(), out priorytet))
        {
            Console.WriteLine("Nieprawidłowy format priorytetu. Podaj priorytet ponownie.");
            return;
        }

        manager.DodajZadanie(new Zadanie(manager.IloscZadan() + 1, nazwa, opis, dataZakonczenia, false, priorytet));
        Console.WriteLine("Zadanie zostało dodane.");
    }

    static void UsunZadanie(ManagerZadan manager)
    {
        Console.Write("Podaj ID zadania do usunięcia: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Nieprawidłowy format ID. Podaj ID ponownie.");
            return;
        }

        manager.UsunZadanie(id);
    }

    static void EdytujZadanie(ManagerZadan manager)
    {
        Console.Write("Podaj ID zadania do edycji: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Nieprawidłowy format ID. Podaj ID ponownie.");
            return;
        }

        Console.WriteLine("Podaj nowe dane dla zadania:");
        DodajZadanie(manager);
        manager.UsunZadanie(id);
    }

    static void OznaczZadanie(ManagerZadan manager)
    {
        Console.Write("Podaj ID zadania do oznaczenia jako ukończone/nieukończone: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Nieprawidłowy format ID. Podaj ID ponownie.");
            return;
        }

        manager.OznaczZadanie(id);
    }

    static void SortujZadania(ManagerZadan manager)
    {
        Console.WriteLine("Wybierz kryterium sortowania:");
        Console.WriteLine("1. Według daty zakończenia");
        Console.WriteLine("2. Według nazwy");
        Console.WriteLine("3. Według priorytetu");
        Console.Write("Wybierz opcję: ");
        string opcja = Console.ReadLine();

        switch (opcja)
        {
            case "1":
                manager.SortujZadaniaPoDacie();
                break;
            case "2":
                manager.SortujZadaniaPoNazwie();
                break;
            case "3":
                manager.SortujZadaniaPoPriorytecie();
                break;
            default:
                Console.WriteLine("Nieprawidłowa opcja. Wybierz ponownie.");
                break;
        }
    }

    static void ZapiszDoPliku(ManagerZadan manager)
    {
        Console.Write("Podaj nazwę pliku do zapisu: ");
        string nazwaPliku = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nazwaPliku))
        {
            Console.WriteLine("Nazwa pliku nie może być pusta.");
            return;
        }

        manager.SerializujDoJSON(nazwaPliku);
    }

    static void WczytajZPliku(ManagerZadan manager)
    {
        Console.Write("Podaj nazwę pliku do wczytania: ");
        string nazwaPliku = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nazwaPliku))
        {
            Console.WriteLine("Nazwa pliku nie może być pusta.");
            return;
        }

        manager.DeserializujZJSON(nazwaPliku);
    }
}
