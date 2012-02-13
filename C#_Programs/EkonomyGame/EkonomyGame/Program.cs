using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Makao
{
    enum Kolor { Pik, Kier, Trefl, Karo };
    enum Wartosc { k2, k3, k4, k5, k6, k7, k8, k9, k10, kWalet, kDama, kKrol, kAs };

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        public static MakaoForm okno;

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            okno = new MakaoForm();
            Application.Run(okno);
        }
    }
}
