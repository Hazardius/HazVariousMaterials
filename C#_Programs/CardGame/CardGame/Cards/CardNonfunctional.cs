namespace CardGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class CardNonfunctional : Card
    {
        // Constructors
        public CardNonfunctional() : base(Suit.Spades, CardGame.Rank.c2) { }
        public CardNonfunctional(Suit suit, Rank rank) : base(suit, rank) { }

        // Methods
        public override void function() { }
        public override void function(int _) { }
    }
}
