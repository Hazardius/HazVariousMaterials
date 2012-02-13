using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class KartaAs : KartaFunkcja
    {
        //ATRYBUTY
        public static Kolor zadany = Kolor.Pik;
        public static bool zadanie = false;
        //KONSTRUKTORY
        public KartaAs() : base(Kolor.Pik,Wartosc.kAs) { }
        public KartaAs(Kolor kol) : base(kol,Wartosc.kAs) { }

        //METODY
        public override void funkcja()
        {
            if (Gra.gracz) //CZLOWIEK
            {
                if (!zadanie) //Wyznacza zadana karte
                {
                    Program.okno.wywolajAs();
                }
                else
                {
                    List<Karta> pasujace = Gra.Human.FindAll(
                       delegate(Karta k)
                       {
                           if ((k.getKolor() == zadany)&&(!(k.czyFunkcyjna())))
                               return true;
                           return false;
                       });
                    Karta.posortuj(pasujace);
                    if (pasujace.Count() != 0) //GRACZ MA PASUJACE KARTY
                    {
                        int indeksik = Gra.Human.FindIndex(delegate(Karta k)
                        {
                            if ((k.getKolor() == zadany) && (!(k.czyFunkcyjna())))
                                return true;
                            return false;
                        });
                        Gra.Zagrane.Push(Gra.Human.ElementAt(indeksik));
                        Gra.Human.RemoveAt(indeksik);
                        Program.okno.makeInfoOkno("Zazadano od Ciebie koloru " + zadany + " za pomoca Asa. Dales "+Gra.Zagrane.Peek().getWartosc()+" "+Gra.Zagrane.Peek().getKolor()+"!", "Zadanie z Asa");
                    }
                    else //GRACZ NIE MA PASUJACYCH
                    {
                        Program.okno.makeInfoOkno("Zazadano od Ciebie koloru " + zadany + " za pomoca Asa. Nie miales pasujacej karty!", "Zadanie z Asa");
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
                    switch (losowator.Next(4))
                    {
                        case 0: KartaAs.zadany = Kolor.Pik; break;
                        case 1: KartaAs.zadany = Kolor.Karo; break;
                        case 2: KartaAs.zadany = Kolor.Trefl; break;
                        case 3: KartaAs.zadany = Kolor.Kier; break;
                    }
                    KartaAs.zadanie = true;
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
                           if ((k.getKolor() == zadany) && (!(k.czyFunkcyjna())))
                               return true;
                           return false;
                       });
                    Karta.posortuj(pasujace);
                    if (pasujace.Count() != 0) //GRACZ MA PASUJACE KARTY
                    {
                        int indeksik = Gra.Computer.FindIndex(delegate(Karta k)
                        {
                            if ((k.getKolor() == zadany) && (!(k.czyFunkcyjna())))
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
