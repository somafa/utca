using System;
using System.Collections.Generic;
using System.Text;

namespace utca
{
    class Kerites
    {
        public string oldal;
        public int szelesseg;
        public char festes;
        static int paros = 2;
        static int paratlan = 1;
        public int hazszam;

        public string Oldal { get => oldal; set => oldal = value; }
        public int Szelesseg { get => szelesseg; set => szelesseg = value; }
        public char Festes { get => festes; set => festes = value; }
        public int Hazszam { get => hazszam; set => hazszam = value; }

        public Kerites(string oldal,int szelesseg, char festes)
        {
            this.oldal = oldal;
            this.szelesseg = szelesseg;
            this.festes = festes;
            if (oldal=="0")
            {
                this.hazszam = paros;
                paros = paros + 2;
            }
            else
            {
                this.hazszam = paratlan;
                paratlan = paratlan + 2;
            }
        }
    }
}
