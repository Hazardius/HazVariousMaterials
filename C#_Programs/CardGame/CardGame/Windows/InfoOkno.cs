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
    public partial class InfoWindow : Form
    {
        MainWindowForm father;
        public InfoWindow()
        {
            InitializeComponent();
        }
        public InfoWindow(MainWindowForm ojciec, string wiadomosc, string krotkawiad)
        {
            InitializeComponent();
            father = ojciec;
            Text = krotkawiad;
            Informacja.Text = wiadomosc;
            Informacja.Enabled = false;
        }

        private void InfoWindow_Load(object sender, EventArgs e)
        {

        }

        private void InfoWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
