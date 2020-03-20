using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace utca
{
    class Program
    {
        static List<Kerites> Hazak = new List<Kerites>();
        static void Main(string[] args)
        {
            Beolvas();
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Az eladott telkek száma: {Hazak.Count}");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("3. feladat:");
            if (Hazak[Hazak.Count-1].Oldal=="0")
            {
                Console.WriteLine("A páros oldalon adták el az utolsó telket.");
            }
            else
            {
                Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");
            }
            Console.WriteLine($"Az utolsó telek házszáma: {Hazak[Hazak.Count-1].Hazszam}");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("4. feladat:");
            List<Kerites> paratlanok = Hazak.FindAll(x => x.Oldal == "1").ToList();
            for (int i = 0; i < paratlanok.Count-1; i++)
            {
                if (paratlanok[i].Festes.Equals(paratlanok[i + 1].Festes) && paratlanok[i].Festes != '#' && paratlanok[i].Festes != ':')
                {
                    Console.WriteLine($"A szomszédossal egyezik a színe: {paratlanok[i].Hazszam}");
                }
            }
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("5. feladat:");
            Console.Write("Adjon meg egy házszámot! ");
            int hazszam = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"A kerítés színe / állapota: {Hazak.Find(x=>x.Hazszam==hazszam).Festes}");
            char balszomszed = Hazak.Find(x => x.Hazszam == hazszam - 2).Festes;
            char jobbszomszed = Hazak.Find(x => x.Hazszam == hazszam + 2).Festes;
            Random r = new Random();
            char ujszin = '\0'; //a karakter alapvető értéke
            do
            {
                ujszin = (char)('A' + r.Next('Z' - 'A')); //ezt nem értem mit jelent
            } while (ujszin.Equals(balszomszed) || ujszin.Equals(jobbszomszed));
            Console.WriteLine($"Egy lehetséges festési szín: {ujszin}");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("6. feladat: fájlbaírás");
            Feladat06();
            Console.WriteLine();
            Console.WriteLine("Program vége!");
            Console.ReadKey();
        }

        static void Beolvas()
        {
            string forras = @"S:\+ Iskola elrendezni +\01 Karanten feladat - Kerites\kerites.txt";
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] s = sr.ReadLine().Split();
                        Hazak.Add(new Kerites(s[0], int.Parse(s[1]), Convert.ToChar(s[2])));
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        static void Feladat06()
        {
            using (StreamWriter sw = new StreamWriter("utcakep.txt"))
            {
                string elsosor = string.Empty;
                foreach (Kerites item in Hazak.FindAll(x => x.Oldal == "1"))
                {
                    elsosor += new String(item.Festes, item.Szelesseg);
                }
                sw.WriteLine(elsosor);
                string masodiksor = string.Empty;
                foreach (Kerites item in Hazak.FindAll(x => x.Oldal == "1"))
                {
                    masodiksor += item.Hazszam.ToString().PadRight(item.Szelesseg, ' '); //mit jelent a PadRight?
                }
                sw.WriteLine(elsosor);
            }
        }
    }
}
