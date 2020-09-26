using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class KartaKrol : KartaFunkcja
    {
        //ATRYBUTY
        //KONSTRUKTORY
        public KartaKrol() : base(Kolor.Pik,Wartosc.kKrol) { }
        public KartaKrol(Kolor kol) : base(kol,Wartosc.kKrol) { }

        //METODY
        public override void funkcja()
        {
            if ((this.getKolor() == Kolor.Pik) || (this.getKolor() == Kolor.Kier))
                if (Gra.gracz)
                {
                    if (!(Gra.Ukryte.Count() > 5))
                    {
                        Karta.utworzStosikZostawJeden(Gra.Zagrane, Gra.Ukryte);
                    }
                    for (int i = 0; i < 5; i++)
                        Gra.Computer.Add(Gra.Ukryte.Pop());
                    Karta.posortuj(Gra.Computer);
                    Gra.CPlay();
                    Gra.gracz = true;
                }
                else
                {
                    if (!(Gra.Ukryte.Count() > 5))
                    {
                        Karta.utworzStosikZostawJeden(Gra.Zagrane, Gra.Ukryte);
                    }
                    for (int i = 0; i < 5; i++)
                        Gra.Human.Add(Gra.Ukryte.Pop());
                    Karta.posortuj(Gra.Human);
                }
        }

        public override void funkcja(int ile) { funkcja(); }

        //GET'y SET'y
    }
}
