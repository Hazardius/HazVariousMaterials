namespace CardGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    abstract class Card
    {
        // Attributes
        private Suit suit;
        public Suit Suit { get => suit; set => suit = value; }
        private Rank rank;
        public Rank Rank { get => rank; set => rank = value; }
        private bool selected;
        public bool Selected { get => selected; set => selected = value; }

        // Constructors
        public Card() { }
        public Card(Suit suit, Rank rank) { this.suit = suit; this.rank = rank; selected = false; }

        // Methods
        public abstract void function();
        public abstract void function(int parameter);

        public bool canPlaceOnTopOf(Card targetedCard){
            if (rank == CardGame.Rank.cQueen)
                return true;
            if (targetedCard.rank == CardGame.Rank.cQueen)
                return true;
            if (targetedCard.rank == this.rank)
                return true;
            if (targetedCard.suit == this.suit)
                return true;
            return false;
        }

        public bool isFunctional()
        {
            Rank[] wartoscTab = { CardGame.Rank.c2, CardGame.Rank.c3, CardGame.Rank.cJack, CardGame.Rank.cKing, CardGame.Rank.cAce };
            foreach (Rank icek in wartoscTab)
            {
                if (rank == icek) return true;
            }
            return false;
        }

        public static void createDeck(List<Card> container)
        {
            Suit[] kolorTab = { Suit.Spades, Suit.Diamonds, Suit.Clubs, Suit.Hearts };
            Rank[] wartoscTab = { CardGame.Rank.c4, CardGame.Rank.c5, CardGame.Rank.c6, CardGame.Rank.c7, CardGame.Rank.c8, CardGame.Rank.c9, CardGame.Rank.c10, CardGame.Rank.cQueen };
            foreach (Suit itko in kolorTab)
            {
                foreach (Rank itwa in wartoscTab)
                {
                    container.Add(new CardNonfunctional(itko, itwa));
                }
                {
                    container.Add(new Card2(itko));
                    container.Add(new Card3(itko));
                    container.Add(new CardJack(itko));
                    container.Add(new CardKing(itko));
                    container.Add(new CardAce(itko));
                }
            }
        }

        public static void utworzStosik(List<Card> container, Stack<Card> shuffled)
        {
            Random generator = new Random();
            int max = container.Count();
            for (int i = max; i > 0; i--)
            {
                int number = generator.Next(i);
                shuffled.Push(container[number]);
                container.RemoveAt(number);
            }
        }

        public static void utworzStosikZostawJeden(Stack<Card> kontener, Stack<Card> stosik)
        {
            Random generator = new Random();
            int max = kontener.Count();
            Card przechowac = kontener.Pop();
            Card[] tablica = new Card[max-1];
            kontener.CopyTo(tablica, 0);
            List<Card> lista = tablica.ToList();
            for (int i = max-1; i > 0; i--)
            {
                int numerek = generator.Next(i);
                stosik.Push(lista[numerek]);
                lista.RemoveAt(numerek);
            }
            kontener.Clear();
            kontener.Push(przechowac);
        }

        public static void rozdaj(Stack<Card> stosik, List<Card> Human, List<Card> Computer, Stack<Card> table)
        {
            for (int i = 0; i < 5; i++)
            {
                Human.Add(stosik.Pop());
                Computer.Add(stosik.Pop());
            }
            int j = 0;
            Stack<Card> temporary = new Stack<Card>();
            while (stosik.Peek().isFunctional())
            {
                temporary.Push(stosik.Pop());
                j++;
            }
            table.Push(stosik.Pop());
            while (j != 0)
            {
                stosik.Push(temporary.Pop());
                j--;
            }
        }

        public static void sort(List<Card> list)
        {
            list.Sort((x, y) => x.rank.CompareTo(y.rank));
        }

        public void draw(System.Windows.Forms.PictureBox target)
        {
            target.Image = CardGame.Properties.Resources.Back;
            switch (rank) {
                case CardGame.Rank.cAce :
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.SpadesAce; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.HeartsAce; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.ClubsAce; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.DiamondsAce; break;
                    } break;
                case CardGame.Rank.c2 :
                    switch(suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades2; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts2; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs2; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds2; break;
                    } break;
                case CardGame.Rank.c3:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades3; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts3; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs3; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds3; break;
                    } break;
                case CardGame.Rank.c4:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades4; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts4; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs4; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds4; break;
                    } break;
                case CardGame.Rank.c5:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades5; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts5; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs5; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds5; break;
                    } break;
                case CardGame.Rank.c6:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades6; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts6; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs6; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds6; break;
                    } break;
                case CardGame.Rank.c7:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades7; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts7; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs7; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds7; break;
                    } break;
                case CardGame.Rank.c8:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades8; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts8; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs8; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds8; break;
                    } break;
                case CardGame.Rank.c9:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades9; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts9; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs9; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds9; break;
                    } break;
                case CardGame.Rank.c10:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.Spades10; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.Hearts10; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.Clubs10; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.Diamonds10; break;
                    } break;
                case CardGame.Rank.cJack:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.SpadesJack; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.HeartsJack; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.ClubsJack; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.DiamondsJack; break;
                    } break;
                case CardGame.Rank.cQueen:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.SpadesQueen; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.HeartsQueen; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.ClubsQueen; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.DiamondsQueen; break;
                    } break;
                case CardGame.Rank.cKing:
                    switch (suit)
                    {
                        case Suit.Spades: target.Image = CardGame.Properties.Resources.SpadesKing; break;
                        case Suit.Hearts: target.Image = CardGame.Properties.Resources.HeartsKing; break;
                        case Suit.Clubs: target.Image = CardGame.Properties.Resources.ClubsKing; break;
                        case Suit.Diamonds: target.Image = CardGame.Properties.Resources.DiamondsKing; break;
                    } break;
            }
        }
    }
}
