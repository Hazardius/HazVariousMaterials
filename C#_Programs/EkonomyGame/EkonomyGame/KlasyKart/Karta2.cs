using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class Karta2 : KartaFunkcja
    {
        //ATRYBUTY
        //KONSTRUKTORY
        public Karta2() : base(Kolor.Pik,Wartosc.k2) { }
        public Karta2(Kolor kol) : base(kol,Wartosc.k2) { }

        //METODY
        public override void funkcja()
        {
        }

        public override void funkcja(int ile){
            if (Gra.gracz) //KOMPUTER
            {
                Karta pot2 = Gra.Computer.Find(
                    delegate(Karta k)
                    {
                        if ((k.getWartosc() == Wartosc.k2)||((k.getWartosc() == Wartosc.k3)&&(k.getKolor()==getKolor())))
                            return true;
                        return false;
                    });
                int i = Gra.Computer.FindIndex(
                    delegate(Karta k){
                        if ((k.getWartosc() == Wartosc.k2) || ((k.getWartosc() == Wartosc.k3) && (k.getKolor() == getKolor())))
                            return true;
                        return false;
                    });
                if (pot2 != null)
                {
                    int ilosc = ile + 1;
                    Gra.Zagrane.Push(Gra.Computer.ElementAt(i));
                    Gra.Computer.RemoveAt(i);
                    Gra.gracz = false;
                    Gra.CPlay(new Action<int>(Gra.Zagrane.Peek().funkcja), ilosc);
                    Gra.gracz = true;
                }
                else
                {
                    List<Karta> atakujace = new List<Karta>();
                    for (int albert = 0; albert < ile; albert++)
                    {
                        atakujace.Add(Gra.Zagrane.ElementAt(albert));
                    }
                    int mnogi = atakujace.FindAll(delegate(Karta k)
                    {
                        if (k.getWartosc() == Wartosc.k2)
                            return true;
                        return false;
                    }).Count() * 2;
                    mnogi = mnogi + atakujace.FindAll(delegate(Karta k)
                    {
                        if (k.getWartosc() == Wartosc.k3)
                            return true;
                        return false;
                    }).Count() * 3;
                    if (!(Gra.Ukryte.Count() > mnogi))
                    {
                        Karta.utworzStosikZostawJeden(Gra.Zagrane, Gra.Ukryte);
                    }
                    for (int om = 0; om < mnogi; om++)
                    {
                        Gra.Computer.Add(Gra.Ukryte.Pop());
                        Karta.posortuj(Gra.Computer);
                    }
                    Gra.CPlay();
                    Gra.gracz = true;
                }
            }
            else //CZLOWIEK
            {
                List<Karta> pot2 = Gra.Human.FindAll(
                    delegate(Karta k)
                    {
                        if ((k.getWartosc() == Wartosc.k2)||((k.getWartosc() == Wartosc.k3)&&(k.getKolor() == getKolor())))
                            return true;
                        return false;
                    });
                Karta.posortuj(pot2);
                if (pot2.Count() != 0) //GRACZ MA 2'ke
                {
                    Gra.gracz = true;
                    Program.okno.wywolajKarta2(pot2, ile);
                    Gra.gracz = false;
                }
                else
                {
                    List<Karta> atakujace = new List<Karta>();
                    for (int albert = 0; albert <ile; albert++)
                    {
                        atakujace.Add(Gra.Zagrane.ElementAt(albert));
                    }
                    int mnogi = atakujace.FindAll(delegate(Karta k)
                    {
                        if (k.getWartosc() == Wartosc.k2)
                            return true;
                        return false;
                    }).Count() * 2;
                    mnogi = mnogi + atakujace.FindAll(delegate(Karta k)
                    {
                        if (k.getWartosc() == Wartosc.k3)
                            return true;
                        return false;
                    }).Count() * 3;

                    if (!(Gra.Ukryte.Count() > mnogi))
                    {
                        Karta.utworzStosikZostawJeden(Gra.Zagrane, Gra.Ukryte);
                    }
                    for (int om = 0; om < mnogi; om++)
                    {
                        Gra.Human.Add(Gra.Ukryte.Pop());
                    }
                    Karta.posortuj(Gra.Human);
                    Program.okno.makeInfoOkno("Zaatakowala Ciebie 2. Niestety nie mogles sie obronic! Zyskujesz "+mnogi+" kart!", "Atak 2!");
                }
            }
        }

        //GET'y SET'y
    }
}
