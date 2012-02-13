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
    public partial class WaletOkno : Form
    {
        private MakaoForm father;

        public WaletOkno()
        {
            InitializeComponent();
        }

        public WaletOkno(MakaoForm ojciec)
        {
            InitializeComponent();
            father = ojciec;
            Gra.Zagrane.Peek().rysuj(Wizerunek);
        }

        private void WaletOkno_Load(object sender, EventArgs e)
        {

        }

        private void WaletOkno_FormClosing(object sender, FormClosingEventArgs e)
        {
            father.Enabled = true;
            father.look_cards();
        }

        private void IWantIt_Click(object sender, EventArgs e)
        {
            int value = listBox1.SelectedIndex;
            switch(value){
                case 0: KartaWalet.zadana = Wartosc.k4; break;
                case 1: KartaWalet.zadana = Wartosc.k5; break;
                case 2: KartaWalet.zadana = Wartosc.k6; break;
                case 3: KartaWalet.zadana = Wartosc.k7; break;
                case 4: KartaWalet.zadana = Wartosc.k8; break;
                case 5: KartaWalet.zadana = Wartosc.k9; break;
                case 6: KartaWalet.zadana = Wartosc.k10; break;
                case 7: KartaWalet.zadana = Wartosc.kDama; break;
            }
            KartaWalet.zadanie = true;
            Gra.gracz = false;
            Gra.CPlay(new Action<int>(Gra.Zagrane.Peek().funkcja), 0);
            Gra.gracz = true;
            father.look_cards();
            Close();
        }
    }
}
