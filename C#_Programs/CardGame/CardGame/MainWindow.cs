namespace CardGame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void wylaczGreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int left = 0;
        private void rozpocznijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.newGame();
            look_cards();
        }

        public void look_cards()
        {
            KomputerKarty.Text = "Komputer posiada " + Game.Computer.Count() + " kart!";
            CenterText.Text = "Na stosiku lezy " + Game.Zagrane.Count() + " kart!";
            StackLabel.Text = "Na stosie lezy " + Game.Ukryte.Count() + " kart!";
            HumanLabel.Text = "Posiadasz " + Game.Human.Count() + " kart!";
            left = 0;
            if (Game.Zagrane.Count() > 0)
            {
                Game.Zagrane.ElementAt(0).draw(TableCard1);
                if (Game.Zagrane.Count() > 1)
                {
                    Game.Zagrane.ElementAt(1).draw(TableCard2);
                    if (Game.Zagrane.Count() > 2)
                    {
                        Game.Zagrane.ElementAt(2).draw(TableCard3);
                        if (Game.Zagrane.Count() > 3)
                        {
                            Game.Zagrane.ElementAt(3).draw(TableCard4);
                            if (Game.Zagrane.Count() > 4)
                            {
                                Game.Zagrane.ElementAt(4).draw(TableCard5);
                            }
                            else
                            {
                                TableCard5.Image = CardGame.Properties.Resources.Back;
                            }
                        }
                        else
                        {
                            TableCard4.Image = CardGame.Properties.Resources.Back;
                            TableCard5.Image = CardGame.Properties.Resources.Back;
                        }
                    }
                    else
                    {
                        TableCard3.Image = CardGame.Properties.Resources.Back;
                        TableCard4.Image = CardGame.Properties.Resources.Back;
                        TableCard5.Image = CardGame.Properties.Resources.Back;
                    }
                }
                else
                {
                    TableCard2.Image = CardGame.Properties.Resources.Back;
                    TableCard3.Image = CardGame.Properties.Resources.Back;
                    TableCard4.Image = CardGame.Properties.Resources.Back;
                    TableCard5.Image = CardGame.Properties.Resources.Back;
                }
            }
            else
            {
                TableCard1.Image = CardGame.Properties.Resources.Back;
                TableCard2.Image = CardGame.Properties.Resources.Back;
                TableCard3.Image = CardGame.Properties.Resources.Back;
                TableCard4.Image = CardGame.Properties.Resources.Back;
                TableCard5.Image = CardGame.Properties.Resources.Back;
            }
            if (Game.Human.Count() > 0)
            {
                Game.Human[left].draw(HumanCard1);
                if (Game.Human.Count() > 1)
                {
                    Game.Human[left + 1].draw(HumanCard2);
                    if (Game.Human.Count() > 2)
                    {
                        Game.Human[left + 2].draw(HumanCard3);
                        if (Game.Human.Count() > 3)
                        {
                            Game.Human[left + 3].draw(HumanCard4);
                            if (Game.Human.Count() > 4)
                            {
                                Game.Human[left + 4].draw(HumanCard5);
                            }
                            else
                            {
                                HumanCard5.Image = CardGame.Properties.Resources.Back;
                            }
                        }
                        else
                        {
                            HumanCard4.Image = CardGame.Properties.Resources.Back;
                            HumanCard5.Image = CardGame.Properties.Resources.Back;
                        }
                    }
                    else
                    {
                        HumanCard3.Image = CardGame.Properties.Resources.Back;
                        HumanCard4.Image = CardGame.Properties.Resources.Back;
                        HumanCard5.Image = CardGame.Properties.Resources.Back;
                    }
                }
                else
                {
                    HumanCard2.Image = CardGame.Properties.Resources.Back;
                    HumanCard3.Image = CardGame.Properties.Resources.Back;
                    HumanCard4.Image = CardGame.Properties.Resources.Back;
                    HumanCard5.Image = CardGame.Properties.Resources.Back;
                }
            }
            else
            {
                HumanCard1.Image = CardGame.Properties.Resources.Back;
                HumanCard2.Image = CardGame.Properties.Resources.Back;
                HumanCard3.Image = CardGame.Properties.Resources.Back;
                HumanCard4.Image = CardGame.Properties.Resources.Back;
                HumanCard5.Image = CardGame.Properties.Resources.Back;
            }
        }

        private void CardsLeft_Click(object sender, EventArgs e)
        {
            if (!Game.Rozgrywka)
                return;
            HumanChoose1.Checked = false;
            Game.Human[left].Selected = false;
            if (Game.Human.Count() > 1)
            {
                HumanChoose2.Checked = false;
                Game.Human[left + 1].Selected = false;
                if (Game.Human.Count() > 2)
                {
                    HumanChoose3.Checked = false;
                    Game.Human[left + 2].Selected = false;
                    if (Game.Human.Count() > 3)
                    {
                        HumanChoose4.Checked = false;
                        Game.Human[left + 3].Selected = false;
                        if (Game.Human.Count() > 4)
                        {
                            HumanChoose5.Checked = false;
                            Game.Human[left + 4].Selected = false;
                        }
                    }
                }
            }
            if (left != 0)
            {
                left--;
                Game.Human[left].draw(HumanCard1);
                Game.Human[left + 1].draw(HumanCard2);
                Game.Human[left + 2].draw(HumanCard3);
                Game.Human[left + 3].draw(HumanCard4);
                Game.Human[left + 4].draw(HumanCard5);
            }
        }

        private void CardsRight_Click(object sender, EventArgs e)
        {
            if (!Game.Rozgrywka)
                return;

            HumanChoose1.Checked = false;
            Game.Human[left].Selected = false;
            if (Game.Human.Count() > 1)
            {
                HumanChoose2.Checked = false;
                Game.Human[left + 1].Selected = false;
                if (Game.Human.Count() > 2)
                {
                    HumanChoose3.Checked = false;
                    Game.Human[left + 2].Selected = false;
                    if (Game.Human.Count() > 3)
                    {
                        HumanChoose4.Checked = false;
                        Game.Human[left + 3].Selected = false;
                        if (Game.Human.Count() > 4)
                        {
                            HumanChoose5.Checked = false;
                            Game.Human[left + 4].Selected = false;
                        }
                    }
                }
            }

            if (left + 5 < Game.Human.Count())
            {
                left++;
                Game.Human[left].draw(HumanCard1);
                Game.Human[left + 1].draw(HumanCard2);
                Game.Human[left + 2].draw(HumanCard3);
                Game.Human[left + 3].draw(HumanCard4);
                Game.Human[left + 4].draw(HumanCard5);
            }
        }

        private void HumanCard1_Click(object sender, EventArgs e)
        {
            if (!Game.Rozgrywka)
            {
                HumanChoose1.Checked = false;
                return;
            }
            if (Game.Human[left].Selected)
            {
                Game.Human[left].Selected = false;
                HumanChoose1.Checked = false;
            }
            else
            {
                Game.Human[left].Selected = true;
                HumanChoose1.Checked = true;
            }
        }

        private void HumanChoose1_Click(object sender, EventArgs e)
        {
            HumanCard1_Click(sender, e);
        }

        private void HumanCard2_Click(object sender, EventArgs e)
        {
            if (!Game.Rozgrywka)
            {
                HumanChoose2.Checked = false;
                return;
            }
            if (Game.Human.Count() > left + 1)
                if (Game.Human[left + 1].Selected)
                {
                    Game.Human[left + 1].Selected = false;
                    HumanChoose2.Checked = false;
                }
                else
                {
                    Game.Human[left + 1].Selected = true;
                    HumanChoose2.Checked = true;
                }
            else
                HumanChoose2.Checked = false;
        }

        private void HumanChoose2_Click(object sender, EventArgs e)
        {
            HumanCard2_Click(sender, e);
        }

        private void HumanCard3_Click(object sender, EventArgs e)
        {
            if (!Game.Rozgrywka)
            {
                HumanChoose3.Checked = false;
                return;
            }
            if (Game.Human.Count() > left + 2)
                if (Game.Human[left + 2].Selected)
                {
                    Game.Human[left + 2].Selected = false;
                    HumanChoose3.Checked = false;
                }
                else
                {
                    Game.Human[left + 2].Selected = true;
                    HumanChoose3.Checked = true;
                }
            else
                HumanChoose3.Checked = false;
        }

        private void HumanCard4_Click(object sender, EventArgs e)
        {

            if (!Game.Rozgrywka)
            {
                HumanChoose4.Checked = false;
                return;
            }
            if (Game.Human.Count() > left + 3)
                if (Game.Human[left + 3].Selected)
                {
                    Game.Human[left + 3].Selected = false;
                    HumanChoose4.Checked = false;
                }
                else
                {
                    Game.Human[left + 3].Selected = true;
                    HumanChoose4.Checked = true;
                }
            else
                HumanChoose4.Checked = false;
        }

        private void HumanCard5_Click(object sender, EventArgs e)
        {
            if (!Game.Rozgrywka)
            {
                HumanChoose5.Checked = false;
                return;
            }
            if (Game.Human.Count() > left + 4)
                if (Game.Human[left + 4].Selected)
                {
                    Game.Human[left + 4].Selected = false;
                    HumanChoose5.Checked = false;
                }
                else
                {
                    Game.Human[left + 4].Selected = true;
                    HumanChoose5.Checked = true;
                }
            else
                HumanChoose5.Checked = false;
        }

        private void HumanChoose3_Click(object sender, EventArgs e)
        {
            HumanCard3_Click(sender, e);
        }

        private void HumanChoose4_Click(object sender, EventArgs e)
        {
            HumanCard4_Click(sender, e);
        }

        private void HumanChoose5_Click(object sender, EventArgs e)
        {
            HumanCard5_Click(sender, e);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!Game.Rozgrywka)
                return;

            if (((Game.Human.Count() == 0) || (Game.Computer.Count() == 0)) && (Game.Rozgrywka))
            {
                //Wywolanie okienka "Wygrales/Przegrales".
                bool kto = (Game.Human.Count() == 0);
                Enabled = false;
                WinLose x = new WinLose(this, kto);
                x.ShowDialog();
                Game.CleanGame();
                return;
            }

            //ODZNACZENIE ZNACZKOW
            HumanChoose1.Checked = false;
            HumanChoose2.Checked = false;
            HumanChoose3.Checked = false;
            HumanChoose4.Checked = false;
            HumanChoose5.Checked = false;

            int ile_zaznaczonych = 0;
            List<Card> grane = new List<Card>();
            int techno = 5;
            if (Game.Human.Count() < 5)
                techno = Game.Human.Count();

            //SKOPIOWANIE ZAZNACZONYCH DO grane
            for (int i = techno - 1; i >= 0; i--)
            {
                if (Game.Human[left + i].Selected)
                {
                    ile_zaznaczonych++;
                    grane.Add(Game.Human[left + i]);
                    grane.Last().Selected = false;
                    Game.Human.RemoveAt(left + i);
                }
            }
            bool blad = false;
            //SPRAWDZENIE, CZY ILOSC ZAZNACZONYCH JEST POPRAWNA
            if ((ile_zaznaczonych <= 4) && (ile_zaznaczonych > 0))
            {
                for (int a = 0; a < ile_zaznaczonych; a++)
                {
                    for (int b = a + 1; b < ile_zaznaczonych; b++)
                        if (!(grane[a].Rank == grane[b].Rank))
                        {
                            blad = true;
                            break;
                        }
                }
                //JESLI WSZYSTKIE SA TEJ SAMEJ WARTOSCI
                if (!blad)
                {
                    Rank kladziona = grane.First().Rank;
                    if (grane.First().canPlaceOnTopOf(Game.Zagrane.Peek()))
                    {
                        Game.HPlay(grane);
                        Game.gracz = true;
                    }
                    else
                    {
                        for (int licznik = ile_zaznaczonych - 1; licznik >= 0; licznik--)
                        {
                            Game.Human.Add(grane[licznik]);
                            grane.RemoveAt(licznik);
                        }
                        Card.sort(Game.Human);
                    }
                }
                else
                {
                    for (int licznik = ile_zaznaczonych - 1; licznik >= 0; licznik--)
                    {
                        Game.Human.Add(grane[licznik]);
                        grane.RemoveAt(licznik);
                    }
                    Card.sort(Game.Human);
                }
            }
            else
            {
                for (int licznik = ile_zaznaczonych - 1; licznik >= 0; licznik--)
                {
                    Game.Human.Add(grane[licznik]);
                    grane.RemoveAt(licznik);
                }
                Card.sort(Game.Human);
            }
            left = 0;
            look_cards();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 x = new AboutBox1();
            x.ShowDialog();
        }

        private void takeButton_Click(object sender, EventArgs e)
        {
            if (!Game.Rozgrywka)
                return;

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
            this.Enabled = false;
            Dobranie x = new Dobranie(this, dodana);
            x.ShowDialog();
        }

        internal void wywolajCard2(List<Card> lista, int ile)
        {
            this.Enabled = false;
            Card2Window x = new Card2Window(this, lista, ile);
            x.ShowDialog();
        }

        internal void wywolajJack()
        {
            this.Enabled = false;
            JackWindow x = new JackWindow(this);
            x.ShowDialog();
        }

        internal void wywolajAce()
        {
            this.Enabled = false;
            AceWindow x = new AceWindow(this);
            x.ShowDialog();
        }

        internal void makeInfoWindow(string wiadomosc, string krotka)
        {
            this.Enabled = false;
            InfoWindow x = new InfoWindow(this, wiadomosc, krotka);
            x.ShowDialog();
        }
    }
}
