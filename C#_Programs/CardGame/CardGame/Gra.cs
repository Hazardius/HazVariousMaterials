using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    class Gra
    {
        public static List<Karta> Talia;
        public static Stack<Karta> Ukryte;
        public static Stack<Karta> Zagrane;
        public static List<Karta> Human;
        public static List<Karta> Computer;
        public static bool Rozgrywka=false;
        public static bool gracz = true;

        public static void newGame()
        {
            Talia = new List<Karta>();
            Ukryte = new Stack<Karta>();
            Zagrane = new Stack<Karta>();
            Human = new List<Karta>();
            Computer = new List<Karta>();
            Karta.makeTalia(Talia);
            Karta.utworzStosik(Talia, Ukryte);
            Karta.rozdaj(Ukryte, Human, Computer, Zagrane);
            Karta.posortuj(Human);
            Karta.posortuj(Computer);
            Rozgrywka = true;
        }

        public static void CleanGame()
        {
            Talia.Clear();
            Ukryte.Clear();
            Zagrane.Clear();
            Human.Clear();
            Computer.Clear();
            Rozgrywka = false;
            gracz = true;
            Program.okno.look_cards();
        }

        public static void HPlay(List<Karta> wybrane)
        {
            gracz = true;
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
            int ilosc = wybrane.Count();
            for (int prz = ilosc - 1; prz >= 0; prz--)
            {
                Zagrane.Push(wybrane.ElementAt(prz));
            }
            bool okok=false;
            if (Zagrane.Peek().czyFunkcyjna())
                okok=true;
            CPlay(new Action<int>(Zagrane.Peek().funkcja),ilosc);
            if (!okok)
                CPlay();
            gracz = true;
        }

        public static void CPlay()
        {
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
            bool juzPo = true;
            for (int i = 0; i < Computer.Count(); i++)
            {
                if (Computer.ElementAt(i).czyMoznaPolozycNa(Zagrane.Peek()))
                {
                    int ilosc = 1;
                    Zagrane.Push(Computer.ElementAt(i));
                    Computer.RemoveAt(i);
                    juzPo = false;
                    gracz = false;
                    Zagrane.Peek().funkcja(ilosc);
                    gracz = true;
                    break;
                }
            }
            if (juzPo)
            {
                Karta dodana;
                if (Gra.Ukryte.Count() > 1)
                {
                    dodana = Gra.Ukryte.Pop();
                }
                else
                {
                    dodana = Gra.Ukryte.Pop();
                    Karta.utworzStosikZostawJeden(Gra.Zagrane, Gra.Ukryte);
                }
                if (dodana.czyMoznaPolozycNa(Zagrane.Peek()))
                {
                    int ilosc = 1;
                    Zagrane.Push(dodana);
                    gracz = true;
                    Zagrane.Peek().funkcja(ilosc);
                }
                else
                {
                    Computer.Add(dodana);
                    Karta.posortuj(Computer);
                }
            }
        }

        public static void CPlay(Action<int> funkcja, int ile)
        {
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
            funkcja(ile);
        }
    }
}
