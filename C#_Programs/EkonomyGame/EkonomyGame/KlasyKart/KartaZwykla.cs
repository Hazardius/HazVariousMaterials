using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class KartaZwykla : Karta
    {
        //ATRYBUTY
        //KONSTRUKTORY
        public KartaZwykla() : base(Kolor.Pik,Wartosc.k2) { }
        public KartaZwykla(Kolor kol, Wartosc war) : base(kol,war) { }

        //METODY
        public override void funkcja() { }
        public override void funkcja(int ile){ }
        //GET'y SET'y
    }
}
