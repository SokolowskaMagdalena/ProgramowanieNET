using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        PerformanceCounter licznikuUzycieProcesora = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter licznikUzyciePamieci = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        PerformanceCounter licznikUzycieDysku = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
        PerformanceCounter licznikPamiecDostepna = new PerformanceCounter("Memory", "Available MBytes");

        float limitUzyciaProcesora = 80;
        float limitUzyciaPamieci = 150;
        float limitUzyciaDysku = 80;
        float limitPamiecDostepna = 1024;

        while (true)
        {
            float uzycieProcesora = licznikuUzycieProcesora.NextValue();
            float uzyciePamieci = licznikUzyciePamieci.NextValue();
            float uzycieDysku = licznikUzycieDysku.NextValue();
            float pamiecDostepna = licznikPamiecDostepna.NextValue();

            Console.Clear();
            Console.WriteLine($"Użycie procesora: {uzycieProcesora}%");
            Console.WriteLine($"Użycie pamięci RAM: {uzyciePamieci}%");
            Console.WriteLine($"Użycie dysku: {uzycieDysku}%");
            Console.WriteLine($"Dostępna pamięć RAM: {pamiecDostepna} MB");

            if (uzycieProcesora > limitUzyciaProcesora)
                EventLog.WriteEntry("Application", "Użycie procesora przekroczyło limit", EventLogEntryType.Warning);

            if (uzyciePamieci > limitUzyciaPamieci)
                EventLog.WriteEntry("Application", "Użycie pamięci RAM przekroczyło limit", EventLogEntryType.Warning);

            if (uzycieDysku > limitUzyciaDysku)
                EventLog.WriteEntry("Application", "Użycie dysku przekroczyło limit", EventLogEntryType.Warning);

            if (pamiecDostepna < limitPamiecDostepna)
                EventLog.WriteEntry("Application", "Dostępna pamięć RAM jest poniżej limitu", EventLogEntryType.Warning);

            Thread.Sleep(1000);
        }
    }
}
