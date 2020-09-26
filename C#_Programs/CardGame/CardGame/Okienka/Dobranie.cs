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
    public partial class Dobranie : Form
    {
        private MakaoForm father;
        private Karta wzieta;

        public Dobranie()
        {
            InitializeComponent();
        }

        internal Dobranie(MakaoForm ojciec, Karta dobrana)
        {
            InitializeComponent();
            father = ojciec;
            wzieta = dobrana;
            wzieta.rysuj(Wizerunek);
            if (!(wzieta.czyMoznaPolozycNa(Gra.Zagrane.Peek())))
            {
                PlayButton.Enabled = false;
            }
        }

        private void Dobranie_Load(object sender, EventArgs e)
        {

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            int ilosc = 1;
            Gra.Zagrane.Push(wzieta);
            Gra.Zagrane.Peek().funkcja(ilosc);
            Gra.gracz = false;
            Gra.CPlay();
            Gra.gracz = true;
            this.Close();
        }

        private void TakeButton_Click(object sender, EventArgs e)
        {
            Gra.Human.Add(wzieta);
            Karta.posortuj(Gra.Human);
            Gra.gracz = false;
            Gra.CPlay();
            Gra.gracz = true;
            this.Close();
        }

        private void Dobranie_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }
    }
}
