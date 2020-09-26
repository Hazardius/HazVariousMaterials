using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Card2 : CardFunctional
    {
        //ATRYBUTY
        //KONSTRUKTORY
        public Card2() : base(Suit.Spades, Rank.c2) { }
        public Card2(Suit kol) : base(kol, Rank.c2) { }

        //METODY
        public override void function()
        {
        }

        public override void function(int ile){
            if (Game.gracz) //KOMPUTER
            {
                Card pot2 = Game.Computer.Find(
                    delegate(Card k)
                    {
                        if ((k.Rank == Rank.c2)||((k.Rank == Rank.c3)&&(k.Suit == Suit)))
                            return true;
                        return false;
                    });
                int i = Game.Computer.FindIndex(
                    delegate(Card k){
                        if ((k.Rank == Rank.c2) || ((k.Rank == Rank.c3) && (k.Suit == Suit)))
                            return true;
                        return false;
                    });
                if (pot2 != null)
                {
                    int ilosc = ile + 1;
                    Game.Zagrane.Push(Game.Computer.ElementAt(i));
                    Game.Computer.RemoveAt(i);
                    Game.gracz = false;
                    Game.CPlay(new Action<int>(Game.Zagrane.Peek().function), ilosc);
                    Game.gracz = true;
                }
                else
                {
                    List<Card> atakujace = new List<Card>();
                    for (int albert = 0; albert < ile; albert++)
                    {
                        atakujace.Add(Game.Zagrane.ElementAt(albert));
                    }
                    int mnogi = atakujace.FindAll(delegate(Card k)
                    {
                        if (k.Rank == Rank.c2)
                            return true;
                        return false;
                    }).Count() * 2;
                    mnogi = mnogi + atakujace.FindAll(delegate(Card k)
                    {
                        if (k.Rank == Rank.c3)
                            return true;
                        return false;
                    }).Count() * 3;
                    if (!(Game.Ukryte.Count() > mnogi))
                    {
                        Card.utworzStosikZostawJeden(Game.Zagrane, Game.Ukryte);
                    }
                    for (int om = 0; om < mnogi; om++)
                    {
                        Game.Computer.Add(Game.Ukryte.Pop());
                        Card.sort(Game.Computer);
                    }
                    Game.CPlay();
                    Game.gracz = true;
                }
            }
            else //CZLOWIEK
            {
                List<Card> pot2 = Game.Human.FindAll(
                    delegate(Card k)
                    {
                        if ((k.Rank == Rank.c2)||((k.Rank == Rank.c3)&&(k.Suit == Suit)))
                            return true;
                        return false;
                    });
                Card.sort(pot2);
                if (pot2.Count() != 0) //GRACZ MA 2'ke
                {
                    Game.gracz = true;
                    Program.window.wywolajCard2(pot2, ile);
                    Game.gracz = false;
                }
                else
                {
                    List<Card> atakujace = new List<Card>();
                    for (int albert = 0; albert <ile; albert++)
                    {
                        atakujace.Add(Game.Zagrane.ElementAt(albert));
                    }
                    int mnogi = atakujace.FindAll(delegate(Card k)
                    {
                        if (k.Rank == Rank.c2)
                            return true;
                        return false;
                    }).Count() * 2;
                    mnogi = mnogi + atakujace.FindAll(delegate(Card k)
                    {
                        if (k.Rank == Rank.c3)
                            return true;
                        return false;
                    }).Count() * 3;

                    if (!(Game.Ukryte.Count() > mnogi))
                    {
                        Card.utworzStosikZostawJeden(Game.Zagrane, Game.Ukryte);
                    }
                    for (int om = 0; om < mnogi; om++)
                    {
                        Game.Human.Add(Game.Ukryte.Pop());
                    }
                    Card.sort(Game.Human);
                    Program.window.makeInfoWindow("Zaatakowala Ciebie 2. Niestety nie mogles sie obronic! Zyskujesz "+mnogi+" kart!", "Atak 2!");
                }
            }
        }

        //GET'y SET'y
    }
}
