﻿public class Zadanie
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public DateTime DataZakonczenia { get; set; }
    public bool CzyWykonane { get; set; }
    public int Priorytet { get; set; }

    public Zadanie(int id, string nazwa, string opis, DateTime dataZakonczenia, bool czyWykonane, int priorytet)
    {
        Id = id;
        Nazwa = nazwa;
        Opis = opis;
        DataZakonczenia = dataZakonczenia;
        CzyWykonane = czyWykonane;
        Priorytet = priorytet;
    }

    public override string ToString()
    {
        string status = CzyWykonane ? "Wykonane" : "Nie wykonane";
        return $"ID: {Id}, Nazwa: {Nazwa}, Opis: {Opis}, Data zakończenia: {DataZakonczenia}, Status: {status}, Priorytet: {Priorytet}";
    }
}
