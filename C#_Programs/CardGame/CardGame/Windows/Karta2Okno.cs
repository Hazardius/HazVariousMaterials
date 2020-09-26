using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Card2Window : Form
    {
        private MainWindowForm father;
        private int ilosc;
        private List<Card> posiadane;
        private Rank war;

        public Card2Window()
        {
            InitializeComponent();
        }

        internal Card2Window(MainWindowForm ojciec, List<Card> lista ,int ile)
        {
            InitializeComponent();
            oneButton.Enabled = false;
            twoButton.Enabled = false;
            threeButton.Enabled = false;
            innaButton.Enabled = false;
            father = ojciec;
            posiadane = lista;
            ilosc = ile;
            war = Rank.c2;
            if (Rank.c3 == Game.Zagrane.Peek().Rank)
            {
                innaButton.Text = "Zagraj 2";
                Info.Text = "Komputer zagral 3!";
                Text = "Komputer zagral 3!";
                war = Rank.c3;
            }

            List<Card> atakujace = new List<Card>();
            for (int albert = 0; albert < ilosc; albert++)
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
            takeIt.Text = "Wez " + mnogi;
            posiadane.ElementAt(0).draw(wyb1);
            int numerbutonow=0;
            if (posiadane.ElementAt(0).Rank == war)
                numerbutonow++;
            else
                innaButton.Enabled = true;
            if(posiadane.Count()>1){
                posiadane.ElementAt(1).draw(wyb2);
                if (posiadane.ElementAt(1).Rank == war)
                    numerbutonow++;
                else
                    innaButton.Enabled = true;
                if (posiadane.Count() > 2)
                {
                    posiadane.ElementAt(2).draw(wyb3);
                    if (posiadane.ElementAt(2).Rank == war)
                        numerbutonow++;
                    else
                        innaButton.Enabled = true;
                    if (posiadane.Count() > 3)
                    {
                        posiadane.ElementAt(3).draw(wyb4);
                        innaButton.Enabled = true;
                    }
                }
            }
            switch (numerbutonow)
            {
                case 1: oneButton.Enabled = true;
                    break;
                case 2: oneButton.Enabled = true;
                    twoButton.Enabled = true;
                    break;
                case 3:
                    oneButton.Enabled = true;
                    twoButton.Enabled = true;
                    threeButton.Enabled = true;
                    break;
            }
        }

        private void Card2Window_Load(object sender, EventArgs e)
        {

        }

        private void Card2Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            Card jedna = Game.Human.Find(
                delegate(Card k)
                {
                    if (k.Rank == war)
                        return true;
                    return false;
                });
            int jednaid = Game.Human.FindIndex(
                delegate(Card k)
                {
                    if (k.Rank == war)
                        return true;
                    return false;
                });
            Game.Zagrane.Push(jedna);
            Game.Human.RemoveAt(jednaid);
            Game.gracz = true;
            Game.CPlay(new Action<int>(Game.Zagrane.Peek().function), ilosc + 1);
            father.look_cards();
            this.Close();
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            Card jedna;
            int jednaid;
            for (int i = 0; i < 2; i++)
            {
                jedna = Game.Human.Find(
                    delegate(Card k)
                    {
                        if (k.Rank == war)
                            return true;
                        return false;
                    });
                jednaid = Game.Human.FindIndex(
                    delegate(Card k)
                    {
                        if (k.Rank == war)
                            return true;
                        return false;
                    });
                Game.Zagrane.Push(jedna);
                Game.Human.RemoveAt(jednaid);
            }
            Game.gracz = true;
            Game.CPlay(new Action<int>(Game.Zagrane.Peek().function), ilosc + 1);
            father.look_cards();
            this.Close();
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            Card jedna;
            int jednaid;
            for (int i = 0; i < 3; i++)
            {
                jedna = Game.Human.Find(
                    delegate(Card k)
                    {
                        if (k.Rank == war)
                            return true;
                        return false;
                    });
                jednaid = Game.Human.FindIndex(
                    delegate(Card k)
                    {
                        if (k.Rank == war)
                            return true;
                        return false;
                    });
                Game.Zagrane.Push(jedna);
                Game.Human.RemoveAt(jednaid);
            }
            Game.gracz = true;
            Game.CPlay(new Action<int>(Game.Zagrane.Peek().function), ilosc + 1);
            father.look_cards();
            this.Close();
        }

        private void innaButton_Click(object sender, EventArgs e)
        {
            Rank temp = Rank.c2;
            if (war == Rank.c2)
                temp = Rank.c3;
            Card jedna = Game.Human.Find(
                delegate(Card k)
                {
                    if (k.Rank == temp)
                        return true;
                    return false;
                });
            int jednaid = Game.Human.FindIndex(
                delegate(Card k)
                {
                    if (k.Rank == temp)
                        return true;
                    return false;
                });
            Game.Zagrane.Push(jedna);
            Game.Human.RemoveAt(jednaid);
            Game.gracz = true;
            Game.CPlay(new Action<int>(Game.Zagrane.Peek().function), ilosc + 1);
            father.look_cards();
            this.Close();
        }

        private void takeIt_Click(object sender, EventArgs e)
        {
            List<Card> atakujace = new List<Card>();
            for (int albert = 0; albert < ilosc; albert++)
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
            father.look_cards();
            this.Close();
        }
    }
}
