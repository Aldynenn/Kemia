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

            Console.ReadKey();
        }

        private static void NegyedikFeladat()
        {

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