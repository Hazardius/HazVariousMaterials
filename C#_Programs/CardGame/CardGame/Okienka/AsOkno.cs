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
    public partial class AsOkno : Form
    {
        private MakaoForm father;

        public AsOkno()
        {
            InitializeComponent();
        }
        
        public AsOkno(MakaoForm ojciec)
        {
            InitializeComponent();
            father = ojciec;
            Gra.Zagrane.Peek().rysuj(Wizerunek);
        }

        private void AsOkno_Load(object sender, EventArgs e)
        {

        }

        private void AsOkno_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }

        private void IWantIt_Click(object sender, EventArgs e)
        {
            int value = listBox1.SelectedIndex;
            switch (value)
            {
                case 0: KartaAs.zadany = Kolor.Pik; break;
                case 1: KartaAs.zadany = Kolor.Karo; break;
                case 2: KartaAs.zadany = Kolor.Trefl; break;
                case 3: KartaAs.zadany = Kolor.Kier; break;
            }
            KartaAs.zadanie = true;
            Gra.gracz = false;
            Gra.CPlay(new Action<int>(Gra.Zagrane.Peek().funkcja), 0);
            Gra.gracz = true;
            father.look_cards();
            Close();
        }
    }
}
