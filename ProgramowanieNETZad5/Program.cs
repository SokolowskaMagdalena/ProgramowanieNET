
            using System;
            using System.IO;

class Program
        {
            static void Main()
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Zapisz dane do pliku binarnego");
                Console.WriteLine("2. Odczytaj dane z pliku binarnego i wyświetl na ekranie");

                int opcja;
                if (!int.TryParse(Console.ReadLine(), out opcja))
                {
                    Console.WriteLine("Podano nieprawidłową opcję.");
                    return;
                }

                switch (opcja)
                {
                    case 1:
                        ZapiszDaneDoPliku();
                        break;
                    case 2:
                        OdczytajDaneZPliku();
                        break;
                    default:
                        Console.WriteLine("Podano nieprawidłową opcję.");
                        break;
                }
            }

            static void ZapiszDaneDoPliku()
            {
                Console.WriteLine("Podaj imię:");
                string imie = Console.ReadLine();

                Console.WriteLine("Podaj wiek:");
                int wiek;
                if (!int.TryParse(Console.ReadLine(), out wiek))
                {
                    Console.WriteLine("Nieprawidłowy wiek. Zapis zakończony.");
                    return;
                }

                Console.WriteLine("Podaj adres:");
                string adres = Console.ReadLine();

                using (FileStream fs = new FileStream("dane.bin", FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Write(imie);
                        writer.Write(wiek);
                        writer.Write(adres);
                    }
                }

                Console.WriteLine("Dane zostały zapisane do pliku binarnego.");
            }

            static void OdczytajDaneZPliku()
            {
                if (!File.Exists("dane.bin"))
                {
                    Console.WriteLine("Plik z danymi nie istnieje.");
                    return;
                }

                using (FileStream fs = new FileStream("dane.bin", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        string imie = reader.ReadString();
                        int wiek = reader.ReadInt32();
                        string adres = reader.ReadString();

                        Console.WriteLine("Imię: " + imie);
                        Console.WriteLine("Wiek: " + wiek);
                        Console.WriteLine("Adres: " + adres);
                    }
                }
            }
        }
