using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieNET
{

    public class Garaz
    {
        private string adres;
        private double pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public double Pojemnosc
        {
            get { return pojemnosc; }
            set
            {
                pojemnosc = value;
                samochody = new Samochod[(int)value];
            }
        }

        public Garaz()
        {
            adres = "nieznana";
            pojemnosc = 0;
            samochody = null;
        }

        public Garaz(string adres_, double pojemnosc_)
        {
            adres = adres_;
            pojemnosc = pojemnosc_;
            samochody = new Samochod[(int)pojemnosc_];
        }

        public Garaz(string adres, double pojemnosc, int maksymalnaLiczbaSamochodow)
        {
            this.adres = adres;
            this.pojemnosc = pojemnosc;
            this.samochody = new Samochod[maksymalnaLiczbaSamochodow];
        }
        public void WprowadzSamochod(Samochod nowySamochod)
        {
            if (liczbaSamochodow < pojemnosc)
            {
                samochody[liczbaSamochodow] = nowySamochod;
                liczbaSamochodow++;
                Console.WriteLine("Dodano samochód do garażu.");
            }
            else
            {
                Console.WriteLine("Garaż jest pełny. Nie można dodać kolejnego samochodu.");
            }
        }
        public Samochod WyprowadzSamochod()
        {
            if (liczbaSamochodow > 0)
            {
                Samochod ostatniSamochod = samochody[liczbaSamochodow - 1];
                samochody[liczbaSamochodow - 1] = null;
                liczbaSamochodow--;
                Console.WriteLine("Wyprowadzono samochód z garażu.");
                return ostatniSamochod;
            }
            else
            {
                Console.WriteLine("Garaż jest pusty. Nie ma samochodów do wyprowadzenia.");
                return null;
            }
        }
        public void WypiszInfo()
        {
            Console.WriteLine("Adres garażu: " + adres);
            Console.WriteLine("Pojemność garażu: " + pojemnosc);

            Console.WriteLine("Informacje o garażowanych samochodach:");
            for (int i = 0; i < liczbaSamochodow; i++)
            {
                Console.WriteLine("Samochód " + (i + 1) + ":");
                samochody[i].WypiszInfo();
            }
        }
    }
}
