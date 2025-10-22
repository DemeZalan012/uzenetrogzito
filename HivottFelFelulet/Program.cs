using System;
using System.IO;

class Program
{
    static void Main()
    {
        string adatMappa = @"C:\c# programok\Telefonalo\bin\Adatok";
        Directory.CreateDirectory(adatMappa);

        while (true)
        {
            Console.WriteLine("\nÜzenetek megtekintése:");
            Console.WriteLine("11 – titkárság");
            Console.WriteLine("14 – tanári");
            Console.WriteLine("15 – kollégium");
            Console.WriteLine("16 – könyvtár");
            Console.WriteLine(" 1 – összes");
            Console.WriteLine(" 0 – kilépés");
            Console.Write("Válasszon menüpontot: ");

            string valasz = Console.ReadLine();

            if (valasz == "0")
                break;

            if (valasz == "1")
            {
                foreach (string file in Directory.GetFiles(adatMappa, "*.txt"))
                {
                    string mellek = Path.GetFileNameWithoutExtension(file);
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"{mellek} - mellék");
                    Console.WriteLine("--------------------------------------");

                    string[] sorok = File.ReadAllLines(file);
                    foreach (string s in sorok)
                        Console.WriteLine(s);

                    File.WriteAllText(file, string.Empty);
                }
            }
            else
            {
                string filePath = Path.Combine(adatMappa, $"{valasz}.txt");

                if (File.Exists(filePath))
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"{valasz} - mellék");
                    Console.WriteLine("--------------------------------------");

                    string[] sorok = File.ReadAllLines(filePath);
                    foreach (string s in sorok)
                        Console.WriteLine(s);

                    File.WriteAllText(filePath, string.Empty);
                }
                else
                {
                    Console.WriteLine("Nincs ilyen fájl vagy üzenet.");
                }
            }
        }

        Console.WriteLine("Kilépés...");
    }
}
