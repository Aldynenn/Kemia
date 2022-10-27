using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Kemia
{
    class Program
    {
        static List<Kemia> adatok = new List<Kemia>();

        static void Main(string[] args)
        {
            AdatokBeolvasasa();
            HarmadikFeladat();
            NegyedikFeladat();
            string vegyjel = "";
            OtodikFeladat(out vegyjel);
            HatodikFeladat(vegyjel);
            HetedikFeladat();
            NyolcadikFeladat();

            Console.ReadKey();
        }

        private static void NyolcadikFeladat()
        {
            Console.WriteLine("8. feladat: Statisztika");
            var lekerdezes = (from adat in adatok
                             group adat by adat.Ev).ToList(); ;
            foreach (var sor in lekerdezes)
            {
                int ev;
                if (int.TryParse(sor.Key, out ev) && sor.Sum(x => 1) > 3)
                {
                    Console.WriteLine($"\t{ev}: {sor.Sum(x => 1)} db");
                }
            }
        }

        private static void HetedikFeladat()
        {
            int kulonbseg = 0;
            for (int i = 0; i < adatok.Count - 1; i++)
            {
                int ev1, ev2;
                if (int.TryParse(adatok[i].Ev, out ev1) && int.TryParse(adatok[i + 1].Ev, out ev2))
                {
                    kulonbseg = kulonbseg < Math.Abs(ev1 - ev2) ? Math.Abs(ev1 - ev2) : kulonbseg;
                }
            }
            Console.WriteLine($"7. feladat: {kulonbseg} év volt a leghosszabb időszak két elem felfedezése között.");
        }

        private static void HatodikFeladat(string vegyjel)
        {
            bool megvan = false;
            int i = 0;
            Kemia keresett = new Kemia();
            while (!megvan && i < adatok.Count)
            {
                if (adatok[i].Vegyjel.ToLower() == vegyjel.ToLower())
                {
                    megvan = true;
                    keresett = adatok[i];
                }
                i++;
            }
            if (megvan)
            {
                Console.WriteLine($"6. feladat: Keresés\n" +
                    $"\tAz elem vegyjele: {keresett.Vegyjel}\n" +
                    $"\tAz elem neve: {keresett.Elem}\n" +
                    $"\tRendszáma: {keresett.Rendszam}\n" +
                    $"\tFelfedezés éve: {keresett.Ev}\n" +
                    $"\tFelfedező: {keresett.Felfedezo}");
            }
        }

        private static void OtodikFeladat(out string vegyjel)
        {
            vegyjel = "";
            while (!HelyesVegyjel(vegyjel))
            {
                Console.Write("5. feladat: Kérek egy vegyjelet: ");
                vegyjel = Console.ReadLine();
            }
        }

        private static bool HelyesVegyjel(string vegyjel)
        {
            if (vegyjel.Length == 1 || vegyjel.Length == 2)
            {
                bool megfelelo = true;
                foreach (char c in vegyjel.ToLower())
                {
                    int charValue = Convert.ToInt32(c);
                    if (!(97 <= charValue && charValue <= 122))
                    {
                        megfelelo = false;
                    }
                }
                return megfelelo;
            }
            else
            {
                return false;
            }
        }

        private static void NegyedikFeladat()
        {
            int okor = 0;
            foreach (Kemia adat in adatok) if (adat.Ev.ToLower() == "ókor") okor++;
            Console.WriteLine($"4. feladat: Felfedezések száma az ókorban: {okor}");
        }

        private static void HarmadikFeladat()
        {
            Console.WriteLine($"3. feladat: Elemek száma: {adatok.Count}");
        }

        private static void AdatokBeolvasasa()
        {
            using (StreamReader sr = new StreamReader("felfedezesek.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    adatok.Add(new Kemia(sr.ReadLine()));
                }
            }

            /*
            foreach (var a in adatok)
            {
                Console.WriteLine(a.ToString());
            }
            */
        }
    }
}