using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Game
    {
        public static List<Card> Talia;
        public static Stack<Card> Ukryte;
        public static Stack<Card> Zagrane;
        public static List<Card> Human;
        public static List<Card> Computer;
        public static bool Rozgrywka=false;
        public static bool gracz = true;

        public static void newGame()
        {
            Talia = new List<Card>();
            Ukryte = new Stack<Card>();
            Zagrane = new Stack<Card>();
            Human = new List<Card>();
            Computer = new List<Card>();
            Card.createDeck(Talia);
            Card.utworzStosik(Talia, Ukryte);
            Card.rozdaj(Ukryte, Human, Computer, Zagrane);
            Card.sort(Human);
            Card.sort(Computer);
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
            Program.window.look_cards();
        }

        public static void HPlay(List<Card> wybrane)
        {
            gracz = true;
            if (((Game.Human.Count() == 0) || (Game.Computer.Count() == 0)) && (Game.Rozgrywka))
            {
                //Wywolanie okienka "Wygrales/Przegrales".
                bool kto = (Game.Human.Count() == 0);
                Program.window.Enabled = false;
                WinLose x = new WinLose(Program.window, kto);
                x.ShowDialog();
                Game.CleanGame();
                return;
            }
            int ilosc = wybrane.Count();
            for (int prz = ilosc - 1; prz >= 0; prz--)
            {
                Zagrane.Push(wybrane.ElementAt(prz));
            }
            bool okok=false;
            if (Zagrane.Peek().isFunctional())
                okok=true;
            CPlay(new Action<int>(Zagrane.Peek().function),ilosc);
            if (!okok)
                CPlay();
            gracz = true;
        }

        public static void CPlay()
        {
            if (((Game.Human.Count() == 0) || (Game.Computer.Count() == 0)) && (Game.Rozgrywka))
            {
                //Wywolanie okienka "Wygrales/Przegrales".
                bool kto = (Game.Human.Count() == 0);
                Program.window.Enabled = false;
                WinLose x = new WinLose(Program.window, kto);
                x.ShowDialog();
                Game.CleanGame();
                return;
            }
            bool juzPo = true;
            for (int i = 0; i < Computer.Count(); i++)
            {
                if (Computer.ElementAt(i).canPlaceOnTopOf(Zagrane.Peek()))
                {
                    int ilosc = 1;
                    Zagrane.Push(Computer.ElementAt(i));
                    Computer.RemoveAt(i);
                    juzPo = false;
                    gracz = false;
                    Zagrane.Peek().function(ilosc);
                    gracz = true;
                    break;
                }
            }
            if (juzPo)
            {
                Card dodana;
                if (Game.Ukryte.Count() > 1)
                {
                    dodana = Game.Ukryte.Pop();
                }
                else
                {
                    dodana = Game.Ukryte.Pop();
                    Card.utworzStosikZostawJeden(Game.Zagrane, Game.Ukryte);
                }
                if (dodana.canPlaceOnTopOf(Zagrane.Peek()))
                {
                    int ilosc = 1;
                    Zagrane.Push(dodana);
                    gracz = true;
                    Zagrane.Peek().function(ilosc);
                }
                else
                {
                    Computer.Add(dodana);
                    Card.sort(Computer);
                }
            }
        }

        public static void CPlay(Action<int> funkcja, int ile)
        {
            if (((Game.Human.Count() == 0) || (Game.Computer.Count() == 0)) && (Game.Rozgrywka))
            {
                //Wywolanie okienka "Wygrales/Przegrales".
                bool kto = (Game.Human.Count() == 0);
                Program.window.Enabled = false;
                WinLose x = new WinLose(Program.window, kto);
                x.ShowDialog();
                Game.CleanGame();
                return;
            }
            funkcja(ile);
        }
    }
}
