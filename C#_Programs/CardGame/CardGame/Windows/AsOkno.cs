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
    public partial class AceWindow : Form
    {
        private MainWindowForm father;

        public AceWindow()
        {
            InitializeComponent();
        }

        public AceWindow(MainWindowForm ojciec)
        {
            InitializeComponent();
            father = ojciec;
            Game.Zagrane.Peek().draw(Wizerunek);
        }

        private void AceWindow_Load(object sender, EventArgs e)
        {

        }

        private void AceWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }

        private void IWantIt_Click(object sender, EventArgs e)
        {
            int value = listBox1.SelectedIndex;
            switch (value)
            {
                case 0: CardAce.zadany = Suit.Spades; break;
                case 1: CardAce.zadany = Suit.Hearts; break;
                case 2: CardAce.zadany = Suit.Clubs; break;
                case 3: CardAce.zadany = Suit.Diamonds; break;
            }
            CardAce.zadanie = true;
            Game.gracz = false;
            Game.CPlay(new Action<int>(Game.Zagrane.Peek().function), 0);
            Game.gracz = true;
            father.look_cards();
            Close();
        }
    }
}
