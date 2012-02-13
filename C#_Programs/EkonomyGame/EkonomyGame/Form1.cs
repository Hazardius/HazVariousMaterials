using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Makao
{
    public partial class MakaoForm : Form
    {
        public MakaoForm()
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
            Gra.newGame();
            look_cards();
        }

        public void look_cards()
        {
            KomputerKarty.Text = "Komputer posiada "+Gra.Computer.Count()+" kart!";
            CenterText.Text = "Na stosiku lezy " + Gra.Zagrane.Count() + " kart!";
            StackLabel.Text = "Na stosie lezy " + Gra.Ukryte.Count() + " kart!";
            HumanLabel.Text = "Posiadasz " + Gra.Human.Count() + " kart!";
            left = 0;
            if (Gra.Zagrane.Count() > 0)
            {
                Gra.Zagrane.ElementAt(0).rysuj(TableCard1);
                if (Gra.Zagrane.Count() > 1)
                {
                    Gra.Zagrane.ElementAt(1).rysuj(TableCard2);
                    if (Gra.Zagrane.Count() > 2)
                    {
                        Gra.Zagrane.ElementAt(2).rysuj(TableCard3);
                        if (Gra.Zagrane.Count() > 3)
                        {
                            Gra.Zagrane.ElementAt(3).rysuj(TableCard4);
                            if (Gra.Zagrane.Count() > 4)
                            {
                                Gra.Zagrane.ElementAt(4).rysuj(TableCard5);
                            }
                            else
                            {
                                TableCard5.Image = Makao.Properties.Resources.Back;
                            }
                        }
                        else
                        {
                            TableCard4.Image = Makao.Properties.Resources.Back;
                            TableCard5.Image = Makao.Properties.Resources.Back;
                        }
                    }
                    else
                    {
                        TableCard3.Image = Makao.Properties.Resources.Back;
                        TableCard4.Image = Makao.Properties.Resources.Back;
                        TableCard5.Image = Makao.Properties.Resources.Back;
                    }
                }
                else
                {
                    TableCard2.Image = Makao.Properties.Resources.Back;
                    TableCard3.Image = Makao.Properties.Resources.Back;
                    TableCard4.Image = Makao.Properties.Resources.Back;
                    TableCard5.Image = Makao.Properties.Resources.Back;
                }
            }
            else
            {
                TableCard1.Image = Makao.Properties.Resources.Back;
                TableCard2.Image = Makao.Properties.Resources.Back;
                TableCard3.Image = Makao.Properties.Resources.Back;
                TableCard4.Image = Makao.Properties.Resources.Back;
                TableCard5.Image = Makao.Properties.Resources.Back;
            }
            if (Gra.Human.Count() > 0)
            {
                Gra.Human[left].rysuj(HumanCard1);
                if (Gra.Human.Count() > 1)
                {
                    Gra.Human[left + 1].rysuj(HumanCard2);
                    if (Gra.Human.Count() > 2)
                    {
                        Gra.Human[left + 2].rysuj(HumanCard3);
                        if (Gra.Human.Count() > 3)
                        {
                            Gra.Human[left + 3].rysuj(HumanCard4);
                            if (Gra.Human.Count() > 4)
                            {
                                Gra.Human[left + 4].rysuj(HumanCard5);
                            }
                            else
                            {
                                HumanCard5.Image = Makao.Properties.Resources.Back;
                            }
                        }
                        else
                        {
                            HumanCard4.Image = Makao.Properties.Resources.Back;
                            HumanCard5.Image = Makao.Properties.Resources.Back;
                        }
                    }
                    else
                    {
                        HumanCard3.Image = Makao.Properties.Resources.Back;
                        HumanCard4.Image = Makao.Properties.Resources.Back;
                        HumanCard5.Image = Makao.Properties.Resources.Back;
                    }
                }
                else
                {
                    HumanCard2.Image = Makao.Properties.Resources.Back;
                    HumanCard3.Image = Makao.Properties.Resources.Back;
                    HumanCard4.Image = Makao.Properties.Resources.Back;
                    HumanCard5.Image = Makao.Properties.Resources.Back;
                }
            }
            else
            {
                HumanCard1.Image = Makao.Properties.Resources.Back;
                HumanCard2.Image = Makao.Properties.Resources.Back;
                HumanCard3.Image = Makao.Properties.Resources.Back;
                HumanCard4.Image = Makao.Properties.Resources.Back;
                HumanCard5.Image = Makao.Properties.Resources.Back;
            }
        }

        private void CardsLeft_Click(object sender, EventArgs e)
        {
            if (!Gra.Rozgrywka)
                return;
            HumanChoose1.Checked = false;
            Gra.Human[left].setWybrana(false);
            if (Gra.Human.Count() > 1)
            {
                HumanChoose2.Checked = false;
                Gra.Human[left + 1].setWybrana(false);
                if (Gra.Human.Count() > 2)
                {
                    HumanChoose3.Checked = false;
                    Gra.Human[left + 2].setWybrana(false);
                    if (Gra.Human.Count() > 3)
                    {
                        HumanChoose4.Checked = false;
                        Gra.Human[left + 3].setWybrana(false);
                        if (Gra.Human.Count() > 4)
                        {
                            HumanChoose5.Checked = false;
                            Gra.Human[left + 4].setWybrana(false);
                        }
                    }
                }
            }
            if (left != 0)
            {
                left--;
                Gra.Human[left].rysuj(HumanCard1);
                Gra.Human[left + 1].rysuj(HumanCard2);
                Gra.Human[left + 2].rysuj(HumanCard3);
                Gra.Human[left + 3].rysuj(HumanCard4);
                Gra.Human[left + 4].rysuj(HumanCard5);
            }
        }

        private void CardsRight_Click(object sender, EventArgs e)
        {
            if (!Gra.Rozgrywka)
                return;

            HumanChoose1.Checked = false;
            Gra.Human[left].setWybrana(false);
            if (Gra.Human.Count() > 1)
            {
                HumanChoose2.Checked = false;
                Gra.Human[left + 1].setWybrana(false);
                if (Gra.Human.Count() > 2)
                {
                    HumanChoose3.Checked = false;
                    Gra.Human[left + 2].setWybrana(false);
                    if (Gra.Human.Count() > 3)
                    {
                        HumanChoose4.Checked = false;
                        Gra.Human[left + 3].setWybrana(false);
                        if (Gra.Human.Count() > 4)
                        {
                            HumanChoose5.Checked = false;
                            Gra.Human[left + 4].setWybrana(false);
                        }
                    }
                }
            }

            if (left+5 < Gra.Human.Count())
            {
                left++;
                Gra.Human[left].rysuj(HumanCard1);
                Gra.Human[left + 1].rysuj(HumanCard2);
                Gra.Human[left + 2].rysuj(HumanCard3);
                Gra.Human[left + 3].rysuj(HumanCard4);
                Gra.Human[left + 4].rysuj(HumanCard5);
            }
        }

        private void HumanCard1_Click(object sender, EventArgs e)
        {
            if (!Gra.Rozgrywka)
            {
                HumanChoose1.Checked = false;
                return;
            }
            if (Gra.Human[left].getWybrana())
            {
                Gra.Human[left].setWybrana(false);
                HumanChoose1.Checked = false;
            } else {
                Gra.Human[left].setWybrana(true);
                HumanChoose1.Checked = true;
            }
        }

        private void HumanChoose1_Click(object sender, EventArgs e)
        {
            HumanCard1_Click(sender, e);
        }

        private void HumanCard2_Click(object sender, EventArgs e)
        {
            if (!Gra.Rozgrywka)
            {
                HumanChoose2.Checked = false;
                return;
            }
            if (Gra.Human.Count() > left + 1)
                if (Gra.Human[left + 1].getWybrana())
                {
                    Gra.Human[left + 1].setWybrana(false);
                    HumanChoose2.Checked = false;
                }
                else
                {
                    Gra.Human[left + 1].setWybrana(true);
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
            if (!Gra.Rozgrywka)
            {
                HumanChoose3.Checked = false;
                return;
            }
            if (Gra.Human.Count() > left + 2)
                if (Gra.Human[left + 2].getWybrana())
                {
                    Gra.Human[left + 2].setWybrana(false);
                    HumanChoose3.Checked = false;
                }
                else
                {
                    Gra.Human[left + 2].setWybrana(true);
                    HumanChoose3.Checked = true;
                }
            else
                HumanChoose3.Checked = false;
        }

        private void HumanCard4_Click(object sender, EventArgs e)
        {

            if (!Gra.Rozgrywka)
            {
                HumanChoose4.Checked = false;
                return;
            }
            if (Gra.Human.Count() > left + 3)
                if (Gra.Human[left + 3].getWybrana())
                {
                    Gra.Human[left + 3].setWybrana(false);
                    HumanChoose4.Checked = false;
                }
                else
                {
                    Gra.Human[left + 3].setWybrana(true);
                    HumanChoose4.Checked = true;
                }
            else
                HumanChoose4.Checked = false;
        }

        private void HumanCard5_Click(object sender, EventArgs e)
        {
            if (!Gra.Rozgrywka)
            {
                HumanChoose5.Checked = false;
                return;
            }
            if (Gra.Human.Count() > left + 4)
                if (Gra.Human[left + 4].getWybrana())
                {
                    Gra.Human[left + 4].setWybrana(false);
                    HumanChoose5.Checked = false;
                }
                else
                {
                    Gra.Human[left + 4].setWybrana(true);
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
            if (!Gra.Rozgrywka)
                return;

            if (((Gra.Human.Count() == 0) || (Gra.Computer.Count() == 0)) && (Gra.Rozgrywka))
            {
                //Wywolanie okienka "Wygrales/Przegrales".
                bool kto = (Gra.Human.Count() == 0);
                Enabled = false;
                WinLose x = new WinLose(this, kto);
                x.ShowDialog();
                Gra.CleanGame();
                return;
            }

                //ODZNACZENIE ZNACZKOW
                HumanChoose1.Checked = false;
                HumanChoose2.Checked = false;
                HumanChoose3.Checked = false;
                HumanChoose4.Checked = false;
                HumanChoose5.Checked = false;

                int ile_zaznaczonych = 0;
                List<Karta> grane = new List<Karta>();
                int techno = 5;
                if (Gra.Human.Count() < 5)
                    techno = Gra.Human.Count();

                //SKOPIOWANIE ZAZNACZONYCH DO grane
                for (int i = techno - 1; i >= 0; i--)
                {
                    if (Gra.Human[left + i].getWybrana())
                    {
                        ile_zaznaczonych++;
                        grane.Add(Gra.Human[left + i]);
                        grane.Last().setWybrana(false);
                        Gra.Human.RemoveAt(left + i);
                    }
                }
                bool blad = false;
                //SPRAWDZENIE, CZY ILOSC ZAZNACZONYCH JEST POPRAWNA
                if ((ile_zaznaczonych <= 4) && (ile_zaznaczonych > 0))
                {
                    for (int a = 0; a < ile_zaznaczonych; a++)
                    {
                        for (int b = a + 1; b < ile_zaznaczonych; b++)
                            if (!(grane[a].getWartosc() == grane[b].getWartosc()))
                            {
                                blad = true;
                                break;
                            }
                    }
                    //JESLI WSZYSTKIE SA TEJ SAMEJ WARTOSCI
                    if (!blad)
                    {
                        Wartosc kladziona = grane.First().getWartosc();
                        if (grane.First().czyMoznaPolozycNa(Gra.Zagrane.Peek()))
                        {
                            Gra.HPlay(grane);
                            Gra.gracz = true;
                        }
                        else
                        {
                            for (int licznik = ile_zaznaczonych - 1; licznik >= 0; licznik--)
                            {
                                Gra.Human.Add(grane[licznik]);
                                grane.RemoveAt(licznik);
                            }
                            Karta.posortuj(Gra.Human);
                        }
                    }
                    else
                    {
                        for (int licznik = ile_zaznaczonych - 1; licznik >= 0; licznik--)
                        {
                            Gra.Human.Add(grane[licznik]);
                            grane.RemoveAt(licznik);
                        }
                        Karta.posortuj(Gra.Human);
                    }
                }
                else
                {
                    for (int licznik = ile_zaznaczonych - 1; licznik >= 0; licznik--)
                    {
                        Gra.Human.Add(grane[licznik]);
                        grane.RemoveAt(licznik);
                    }
                    Karta.posortuj(Gra.Human);
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
            if (!Gra.Rozgrywka)
                return;

            Karta dodana;
            if (Gra.Ukryte.Count() > 1)
            {
                dodana = Gra.Ukryte.Pop();
            }
            else
            {
                dodana = Gra.Ukryte.Pop();
                Karta.utworzStosikZostawJeden(Gra.Zagrane,Gra.Ukryte);
            }
            this.Enabled = false;
            Dobranie x = new Dobranie(this, dodana);
            x.ShowDialog();
        }

        internal void wywolajKarta2(List<Karta> lista,int ile)
        {
            this.Enabled = false;
            Karta2Okno x = new Karta2Okno(this, lista, ile);
            x.ShowDialog();
        }

        internal void wywolajWalet()
        {
            this.Enabled = false;
            WaletOkno x = new WaletOkno(this);
            x.ShowDialog();
        }

        internal void wywolajAs()
        {
            this.Enabled = false;
            AsOkno x = new AsOkno(this);
            x.ShowDialog();
        }

        internal void makeInfoOkno(string wiadomosc, string krotka)
        {
            this.Enabled = false;
            InfoOkno x = new InfoOkno(this,wiadomosc, krotka);
            x.ShowDialog();
        }
    }
}
