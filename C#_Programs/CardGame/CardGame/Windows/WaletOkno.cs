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
    public partial class JackWindow : Form
    {
        private MainWindowForm father;

        public JackWindow()
        {
            InitializeComponent();
        }

        public JackWindow(MainWindowForm ojciec)
        {
            InitializeComponent();
            father = ojciec;
            Game.Zagrane.Peek().draw(Wizerunek);
        }

        private void JackWindow_Load(object sender, EventArgs e)
        {

        }

        private void JackWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }

        private void IWantIt_Click(object sender, EventArgs e)
        {
            int value = listBox1.SelectedIndex;
            switch(value){
                case 0: CardJack.zadana = Rank.c4; break;
                case 1: CardJack.zadana = Rank.c5; break;
                case 2: CardJack.zadana = Rank.c6; break;
                case 3: CardJack.zadana = Rank.c7; break;
                case 4: CardJack.zadana = Rank.c8; break;
                case 5: CardJack.zadana = Rank.c9; break;
                case 6: CardJack.zadana = Rank.c10; break;
                case 7: CardJack.zadana = Rank.cQueen; break;
            }
            CardJack.zadanie = true;
            Game.gracz = false;
            Game.CPlay(new Action<int>(Game.Zagrane.Peek().function), 0);
            Game.gracz = true;
            father.look_cards();
            Close();
        }
    }
}
