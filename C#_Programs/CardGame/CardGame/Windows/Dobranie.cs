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
    public partial class Dobranie : Form
    {
        private MainWindowForm father;
        private Card wzieta;

        public Dobranie()
        {
            InitializeComponent();
        }

        internal Dobranie(MainWindowForm ojciec, Card dobrana)
        {
            InitializeComponent();
            father = ojciec;
            wzieta = dobrana;
            wzieta.draw(Wizerunek);
            if (!(wzieta.canPlaceOnTopOf(Game.Zagrane.Peek())))
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
            Game.Zagrane.Push(wzieta);
            Game.Zagrane.Peek().function(ilosc);
            Game.gracz = false;
            Game.CPlay();
            Game.gracz = true;
            this.Close();
        }

        private void TakeButton_Click(object sender, EventArgs e)
        {
            Game.Human.Add(wzieta);
            Card.sort(Game.Human);
            Game.gracz = false;
            Game.CPlay();
            Game.gracz = true;
            this.Close();
        }

        private void Dobranie_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }
    }
}
