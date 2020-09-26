using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class CardJack : CardFunctional
    {
        //ATRYBUTY
        public static Rank zadana = Rank.c2;
        public static bool zadanie = false;
        //KONSTRUKTORY
        public CardJack() : base(Suit.Spades, Rank.cJack) { }
        public CardJack(Suit kol) : base(kol, Rank.cJack) { }

        //METODY
        public override void function()
        {
            if (Game.gracz) //CZLOWIEK
            {
                if (!zadanie) //Wyznacza zadana karte
                {
                    Program.window.wywolajJack();
                }
                else
                {
                    List<Card> pasujace = Game.Human.FindAll(
                       delegate(Card k)
                       {
                           if (k.Rank == zadana)
                               return true;
                           return false;
                       });
                    Card.sort(pasujace);
                    if (pasujace.Count() != 0) //GRACZ MA PASUJACE KARTY
                    {
                        int indeksik = Game.Human.FindIndex(delegate(Card k)
                        {
                            if (k.Rank == zadana)
                                return true;
                            return false;
                        });
                        Game.Zagrane.Push(Game.Human.ElementAt(indeksik));
                        Game.Human.RemoveAt(indeksik);
                        Program.window.makeInfoWindow("Zazadano od Ciebie karty " + zadana + " za pomoca Jacka. Dales ja!", "Zadanie z Jacka");
                    }
                    else //GRACZ NIE MA PASUJACYCH
                    {
                        Program.window.makeInfoWindow("Zazadano od Ciebie karty " + zadana + " za pomoca Jacka. Nie miales pasujacej!", "Zadanie z Jacka");
                    }
                    zadanie = false;
                    Game.CPlay();
                }
            }
            else //KOMPUTER
            {
                if (!zadanie) //Zagral waleta i wyznacza zadanie
                {
                    Random losowator = new Random();
                    switch (losowator.Next(8))
                    {
                        case 0: CardJack.zadana = Rank.c4; break;
                        case 1: CardJack.zadana = Rank.c5; break;
                        case 2: CardJack.zadana = Rank.c6; break;
                        case 3: CardJack.zadana = Rank.c7; break;
                        case 4: CardJack.zadana = Rank.c8; break;
                        case 5: CardJack.zadana = Rank.c9; break;
                        case 6: CardJack.zadana = Rank.c10; break;
                        case 7: CardJack.zadana = Rank.cQueen; break;
                    }
                    CardJack.zadanie = true;
                    Game.gracz = true;
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
                    this.function();
                }
                else
                {
                    List<Card> pasujace = Game.Computer.FindAll(
                       delegate(Card k)
                       {
                           if (k.Rank == zadana)
                               return true;
                           return false;
                       });
                    Card.sort(pasujace);
                    if (pasujace.Count() != 0) //GRACZ MA PASUJACE KARTY
                    {
                        int indeksik = Game.Computer.FindIndex(delegate(Card k)
                        {
                            if (k.Rank == zadana)
                                return true;
                            return false;
                        });
                        Game.Zagrane.Push(Game.Computer.ElementAt(indeksik));
                        Game.Computer.RemoveAt(indeksik);
                    }
                    zadanie = false;
                    Game.gracz = true;
                }
            }
        }

        public override void function(int ile) { function(); }

        //GET'y SET'y
    }
}
