using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class KartaWalet : KartaFunkcja
    {
        //ATRYBUTY
        public static Wartosc zadana = Wartosc.k2;
        public static bool zadanie = false;
        //KONSTRUKTORY
        public KartaWalet() : base(Kolor.Pik,Wartosc.kWalet) { }
        public KartaWalet(Kolor kol) : base(kol,Wartosc.kWalet) { }

        //METODY
        public override void funkcja()
        {
            if (Gra.gracz) //CZLOWIEK
            {
                if (!zadanie) //Wyznacza zadana karte
                {
                    Program.okno.wywolajWalet();
                }
                else
                {
                    List<Karta> pasujace = Gra.Human.FindAll(
                       delegate(Karta k)
                       {
                           if (k.getWartosc() == zadana)
                               return true;
                           return false;
                       });
                    Karta.posortuj(pasujace);
                    if (pasujace.Count() != 0) //GRACZ MA PASUJACE KARTY
                    {
                        int indeksik = Gra.Human.FindIndex(delegate(Karta k)
                        {
                            if (k.getWartosc() == zadana)
                                return true;
                            return false;
                        });
                        Gra.Zagrane.Push(Gra.Human.ElementAt(indeksik));
                        Gra.Human.RemoveAt(indeksik);
                        Program.okno.makeInfoOkno("Zazadano od Ciebie karty " + zadana + " za pomoca Waleta. Dales ja!", "Zadanie z Waleta");
                    }
                    else //GRACZ NIE MA PASUJACYCH
                    {
                        Program.okno.makeInfoOkno("Zazadano od Ciebie karty " + zadana + " za pomoca Waleta. Nie miales pasujacej!", "Zadanie z Waleta");
                    }
                    zadanie = false;
                    Gra.CPlay();
                }
            }
            else //KOMPUTER
            {
                if (!zadanie) //Zagral waleta i wyznacza zadanie
                {
                    Random losowator = new Random();
                    switch (losowator.Next(8))
                    {
                        case 0: KartaWalet.zadana = Wartosc.k4; break;
                        case 1: KartaWalet.zadana = Wartosc.k5; break;
                        case 2: KartaWalet.zadana = Wartosc.k6; break;
                        case 3: KartaWalet.zadana = Wartosc.k7; break;
                        case 4: KartaWalet.zadana = Wartosc.k8; break;
                        case 5: KartaWalet.zadana = Wartosc.k9; break;
                        case 6: KartaWalet.zadana = Wartosc.k10; break;
                        case 7: KartaWalet.zadana = Wartosc.kDama; break;
                    }
                    KartaWalet.zadanie = true;
                    Gra.gracz = true;
                    if (((Gra.Human.Count() == 0) || (Gra.Computer.Count() == 0)) && (Gra.Rozgrywka))
                    {
                        //Wywolanie okienka "Wygrales/Przegrales".
                        bool kto = (Gra.Human.Count() == 0);
                        Program.okno.Enabled = false;
                        WinLose x = new WinLose(Program.okno, kto);
                        x.ShowDialog();
                        Gra.CleanGame();
                        return;
                    }
                    this.funkcja();
                }
                else
                {
                    List<Karta> pasujace = Gra.Computer.FindAll(
                       delegate(Karta k)
                       {
                           if (k.getWartosc() == zadana)
                               return true;
                           return false;
                       });
                    Karta.posortuj(pasujace);
                    if (pasujace.Count() != 0) //GRACZ MA PASUJACE KARTY
                    {
                        int indeksik = Gra.Computer.FindIndex(delegate(Karta k)
                        {
                            if (k.getWartosc() == zadana)
                                return true;
                            return false;
                        });
                        Gra.Zagrane.Push(Gra.Computer.ElementAt(indeksik));
                        Gra.Computer.RemoveAt(indeksik);
                    }
                    zadanie = false;
                    Gra.gracz = true;
                }
            }
        }

        public override void funkcja(int ile) { funkcja(); }

        //GET'y SET'y
    }
}
