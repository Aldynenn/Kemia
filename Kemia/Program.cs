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

            Console.ReadKey();
        }

        private static void HatodikFeladat(string vegyjel)
        {
            bool megvan = false;
            int i = 0;
            Kemia keresett;
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
                Console.WriteLine("\t");
            }
        }

        private static void OtodikFeladat(out string vegyjel)
        {
            vegyjel = "";
            while (!(vegyjel.Length <= 2 && vegyjel.Length >= 1 && vegyjel.All(Char.IsLetter)))
            {
                Console.Write("5. feladat: Kérek egy vegyjelet: ");
                vegyjel = Console.ReadLine();
            }
        }

        private static void NegyedikFeladat()
        {
            int okor = 0;
            foreach (var adat in adatok) if (adat.Ev.ToLower() == "ókor") okor++;
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