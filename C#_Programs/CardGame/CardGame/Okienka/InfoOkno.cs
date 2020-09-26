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
    public partial class InfoOkno : Form
    {
        MakaoForm father;
        public InfoOkno()
        {
            InitializeComponent();
        }
        public InfoOkno(MakaoForm ojciec, string wiadomosc, string krotkawiad)
        {
            InitializeComponent();
            father = ojciec;
            Text = krotkawiad;
            Informacja.Text = wiadomosc;
            Informacja.Enabled = false;
        }

        private void InfoOkno_Load(object sender, EventArgs e)
        {

        }

        private void InfoOkno_FormClosing(object sender, FormClosingEventArgs e)
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
