using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    abstract class CardFunctional : Card
    {
        //ATRYBUTY
        //KONSTRUKTORY
        public CardFunctional() : base(Suit.Spades, Rank.c2) { }
        public CardFunctional(Suit kol, Rank war) : base(kol,war) { }

        //METODY
        public abstract override void function();
        public abstract override void function(int ile);
        //GET'y SET'y
    }
}
