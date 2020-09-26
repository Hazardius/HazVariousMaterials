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
    public partial class Karta2Okno : Form
    {
        private MakaoForm father;
        private int ilosc;
        private List<Karta> posiadane;
        private Wartosc war;

        public Karta2Okno()
        {
            InitializeComponent();
        }

        internal Karta2Okno(MakaoForm ojciec, List<Karta> lista ,int ile)
        {
            InitializeComponent();
            oneButton.Enabled = false;
            twoButton.Enabled = false;
            threeButton.Enabled = false;
            innaButton.Enabled = false;
            father = ojciec;
            posiadane = lista;
            ilosc = ile;
            war = Wartosc.k2;
            if (Wartosc.k3 == Gra.Zagrane.Peek().getWartosc())
            {
                innaButton.Text = "Zagraj 2";
                Info.Text = "Komputer zagral 3!";
                Text = "Komputer zagral 3!";
                war = Wartosc.k3;
            }

            List<Karta> atakujace = new List<Karta>();
            for (int albert = 0; albert < ilosc; albert++)
            {
                atakujace.Add(Gra.Zagrane.ElementAt(albert));
            }
            int mnogi = atakujace.FindAll(delegate(Karta k)
            {
                if (k.getWartosc() == Wartosc.k2)
                    return true;
                return false;
            }).Count() * 2;
            mnogi = mnogi + atakujace.FindAll(delegate(Karta k)
            {
                if (k.getWartosc() == Wartosc.k3)
                    return true;
                return false;
            }).Count() * 3;
            takeIt.Text = "Wez " + mnogi;
            posiadane.ElementAt(0).rysuj(wyb1);
            int numerbutonow=0;
            if (posiadane.ElementAt(0).getWartosc() == war)
                numerbutonow++;
            else
                innaButton.Enabled = true;
            if(posiadane.Count()>1){
                posiadane.ElementAt(1).rysuj(wyb2);
                if (posiadane.ElementAt(1).getWartosc() == war)
                    numerbutonow++;
                else
                    innaButton.Enabled = true;
                if (posiadane.Count() > 2)
                {
                    posiadane.ElementAt(2).rysuj(wyb3);
                    if (posiadane.ElementAt(2).getWartosc() == war)
                        numerbutonow++;
                    else
                        innaButton.Enabled = true;
                    if (posiadane.Count() > 3)
                    {
                        posiadane.ElementAt(3).rysuj(wyb4);
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

        private void Karta2Okno_Load(object sender, EventArgs e)
        {

        }

        private void Karta2Okno_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            Karta jedna = Gra.Human.Find(
                delegate(Karta k)
                {
                    if (k.getWartosc() == war)
                        return true;
                    return false;
                });
            int jednaid = Gra.Human.FindIndex(
                delegate(Karta k)
                {
                    if (k.getWartosc() == war)
                        return true;
                    return false;
                });
            Gra.Zagrane.Push(jedna);
            Gra.Human.RemoveAt(jednaid);
            Gra.gracz = true;
            Gra.CPlay(new Action<int>(Gra.Zagrane.Peek().funkcja), ilosc + 1);
            father.look_cards();
            this.Close();
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            Karta jedna;
            int jednaid;
            for (int i = 0; i < 2; i++)
            {
                jedna = Gra.Human.Find(
                    delegate(Karta k)
                    {
                        if (k.getWartosc() == war)
                            return true;
                        return false;
                    });
                jednaid = Gra.Human.FindIndex(
                    delegate(Karta k)
                    {
                        if (k.getWartosc() == war)
                            return true;
                        return false;
                    });
                Gra.Zagrane.Push(jedna);
                Gra.Human.RemoveAt(jednaid);
            }
            Gra.gracz = true;
            Gra.CPlay(new Action<int>(Gra.Zagrane.Peek().funkcja), ilosc + 1);
            father.look_cards();
            this.Close();
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            Karta jedna;
            int jednaid;
            for (int i = 0; i < 3; i++)
            {
                jedna = Gra.Human.Find(
                    delegate(Karta k)
                    {
                        if (k.getWartosc() == war)
                            return true;
                        return false;
                    });
                jednaid = Gra.Human.FindIndex(
                    delegate(Karta k)
                    {
                        if (k.getWartosc() == war)
                            return true;
                        return false;
                    });
                Gra.Zagrane.Push(jedna);
                Gra.Human.RemoveAt(jednaid);
            }
            Gra.gracz = true;
            Gra.CPlay(new Action<int>(Gra.Zagrane.Peek().funkcja), ilosc + 1);
            father.look_cards();
            this.Close();
        }

        private void innaButton_Click(object sender, EventArgs e)
        {
            Wartosc temp = Wartosc.k2;
            if (war == Wartosc.k2)
                temp = Wartosc.k3;
            Karta jedna = Gra.Human.Find(
                delegate(Karta k)
                {
                    if (k.getWartosc() == temp)
                        return true;
                    return false;
                });
            int jednaid = Gra.Human.FindIndex(
                delegate(Karta k)
                {
                    if (k.getWartosc() == temp)
                        return true;
                    return false;
                });
            Gra.Zagrane.Push(jedna);
            Gra.Human.RemoveAt(jednaid);
            Gra.gracz = true;
            Gra.CPlay(new Action<int>(Gra.Zagrane.Peek().funkcja), ilosc + 1);
            father.look_cards();
            this.Close();
        }

        private void takeIt_Click(object sender, EventArgs e)
        {
            List<Karta> atakujace = new List<Karta>();
            for (int albert = 0; albert < ilosc; albert++)
            {
                atakujace.Add(Gra.Zagrane.ElementAt(albert));
            }
            int mnogi = atakujace.FindAll(delegate(Karta k)
            {
                if (k.getWartosc() == Wartosc.k2)
                    return true;
                return false;
            }).Count() * 2;
            mnogi = mnogi + atakujace.FindAll(delegate(Karta k)
            {
                if (k.getWartosc() == Wartosc.k3)
                    return true;
                return false;
            }).Count() * 3;

            if (!(Gra.Ukryte.Count() > mnogi))
            {
                Karta.utworzStosikZostawJeden(Gra.Zagrane, Gra.Ukryte);
            }
            for (int om = 0; om < mnogi; om++)
            {
                Gra.Human.Add(Gra.Ukryte.Pop());
            }
            Karta.posortuj(Gra.Human);
            father.look_cards();
            this.Close();
        }
    }
}
