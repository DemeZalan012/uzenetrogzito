using System;
using System.IO;

class Program
{
    static void Main()
    {
        string adatMappa = @"C:\c# programok\Telefonalo\bin\Adatok";
        Directory.CreateDirectory(adatMappa); // ha még nem létezik, létrehozza

        string[] mellekek = { "11", "14", "15", "16" };
        Console.WriteLine("Válasszon egy melléket:");
        Console.WriteLine("11 – titkárság");
        Console.WriteLine("14 – tanári");
        Console.WriteLine("15 – kollégium");
        Console.WriteLine("16 – könyvtár");
        Console.Write("Mellék: ");

        string mellek = Console.ReadLine();

        if (!Array.Exists(mellekek, e => e == mellek))
        {
            Console.WriteLine("Hibás mellékszám!");
            return;
        }

        Console.Write("Adja meg a nevét: ");
        string nev = Console.ReadLine();

        Console.Write("Írja be az üzenetét: ");
        string uzenet = Console.ReadLine();

        Random rnd = new Random();
        string tel = "+36" + rnd.Next(400000000, 499999999);
        string datum = DateTime.Now.ToString("yyyy. MM. dd. HH:mm:ss");

        string filePath = Path.Combine(adatMappa, $"{mellek}.txt");

        int sorszam = 1;
        if (File.Exists(filePath))
        {
            sorszam = File.ReadAllLines(filePath).Length + 1;
        }

        string sor = $"{sorszam};{nev};{uzenet};{tel};{datum}";
        File.AppendAllText(filePath, sor + Environment.NewLine);

        Console.WriteLine("\nÜzenet sikeresen rögzítve!");
        Console.WriteLine($"Fájl helye: {filePath}");
    }
}
