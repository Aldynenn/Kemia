using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
    class Kemia
    {
        private string ev;

        public string Ev
        {
            get { return ev; }
            set { ev = value; }
        }

        private string elem;

        public string Elem
        {
            get { return elem; }
            set { elem = value; }
        }

        private string vegyjel;

        public string Vegyjel
        {
            get { return vegyjel; }
            set { vegyjel = value; }
        }

        private int rendszam;

        public int Rendszam
        {
            get { return rendszam; }
            set { rendszam = value; }
        }

        private string felfedezo;

        public string Felfedezo
        {
            get { return felfedezo; }
            set { felfedezo = value; }
        }

        public Kemia(string row)
        {
            List<string> temp = row.Split(';').ToList();
            string ev = temp[0];
            string elem = temp[1];
            string vegyjel = temp[2];
            int rendszam = Convert.ToInt32(temp[3]);
            string felfedezo = temp[4];
            Ev = ev;
            Elem = elem;
            Vegyjel = vegyjel;
            Rendszam = rendszam;
            Felfedezo = felfedezo;
        }

        public override string ToString()
        {
            return $"| {Ev} | {Elem} | {Vegyjel} | {Rendszam} | {Felfedezo} |";
        }
    }
}
