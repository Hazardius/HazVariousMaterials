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
    public partial class WinLose : Form
    {
        MakaoForm father;
        public WinLose()
        {
            InitializeComponent();
        }

        public WinLose(MakaoForm ojciec, bool wygrana)
        {
            InitializeComponent();
            father = ojciec;
            Text = "Przegrales!";
            if (wygrana)
            {
                Info.Text = "Wygrales!";
                Text = "Wygrales!";
            }

        }

        private void WinLose_Load(object sender, EventArgs e)
        {

        }

        private void WinLose_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
