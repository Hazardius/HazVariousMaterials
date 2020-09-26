using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class CardAce : CardFunctional
    {
        //ATRYBUTY
        public static Suit zadany = Suit.Spades;
        public static bool zadanie = false;
        //KONSTRUKTORY
        public CardAce() : base(Suit.Spades, Rank.cAce) { }
        public CardAce(Suit kol) : base(kol, Rank.cAce) { }

        //METODY
        public override void function()
        {
            if (Game.gracz) //CZLOWIEK
            {
                if (!zadanie) //Wyznacza zadana karte
                {
                    Program.window.wywolajAce();
                }
                else
                {
                    List<Card> pasujace = Game.Human.FindAll(
                       delegate(Card k)
                       {
                           if ((k.Suit == zadany)&&(!(k.isFunctional())))
                               return true;
                           return false;
                       });
                    Card.sort(pasujace);
                    if (pasujace.Count() != 0) //GRACZ MA PASUJACE KARTY
                    {
                        int indeksik = Game.Human.FindIndex(delegate(Card k)
                        {
                            if ((k.Suit == zadany) && (!(k.isFunctional())))
                                return true;
                            return false;
                        });
                        Game.Zagrane.Push(Game.Human.ElementAt(indeksik));
                        Game.Human.RemoveAt(indeksik);
                        Program.window.makeInfoWindow("Zazadano od Ciebie koloru " + zadany + " za pomoca Asa. Dales "+Game.Zagrane.Peek().Rank+" "+Game.Zagrane.Peek().Suit+"!", "Zadanie z Asa");
                    }
                    else //GRACZ NIE MA PASUJACYCH
                    {
                        Program.window.makeInfoWindow("Zazadano od Ciebie koloru " + zadany + " za pomoca Asa. Nie miales pasujacej karty!", "Zadanie z Asa");
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
                    switch (losowator.Next(4))
                    {
                        case 0: CardAce.zadany = Suit.Spades; break;
                        case 1: CardAce.zadany = Suit.Hearts; break;
                        case 2: CardAce.zadany = Suit.Clubs; break;
                        case 3: CardAce.zadany = Suit.Diamonds; break;
                    }
                    CardAce.zadanie = true;
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
                           if ((k.Suit == zadany) && (!(k.isFunctional())))
                               return true;
                           return false;
                       });
                    Card.sort(pasujace);
                    if (pasujace.Count() != 0) //GRACZ MA PASUJACE KARTY
                    {
                        int indeksik = Game.Computer.FindIndex(delegate(Card k)
                        {
                            if ((k.Suit == zadany) && (!(k.isFunctional())))
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
