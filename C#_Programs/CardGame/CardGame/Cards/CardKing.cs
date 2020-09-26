namespace CardGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class CardKing : CardFunctional
    {
        // Constructors
        public CardKing() : base(Suit.Spades, Rank.cKing) { }
        public CardKing(Suit suit) : base(suit, Rank.cKing) { }

        // Methods
        public override void function()
        {
            if ((this.Suit == Suit.Spades) || (this.Suit == Suit.Diamonds))
                if (Game.gracz)
                {
                    if (!(Game.Ukryte.Count() > 5))
                    {
                        Card.utworzStosikZostawJeden(Game.Zagrane, Game.Ukryte);
                    }
                    for (int i = 0; i < 5; i++)
                        Game.Computer.Add(Game.Ukryte.Pop());
                    Card.sort(Game.Computer);
                    Game.CPlay();
                    Game.gracz = true;
                }
                else
                {
                    if (!(Game.Ukryte.Count() > 5))
                    {
                        Card.utworzStosikZostawJeden(Game.Zagrane, Game.Ukryte);
                    }
                    for (int i = 0; i < 5; i++)
                        Game.Human.Add(Game.Ukryte.Pop());
                    Card.sort(Game.Human);
                }
        }

        public override void function(int _) { function(); }
    }
}
