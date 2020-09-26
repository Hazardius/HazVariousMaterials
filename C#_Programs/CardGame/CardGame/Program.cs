namespace CardGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    enum Suit { Spades, Diamonds, Clubs, Hearts };
    enum Rank { c2, c3, c4, c5, c6, c7, c8, c9, c10, cJack, cQueen, cKing, cAce };

    static class Program
    {
        public static MainWindowForm window;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window = new MainWindowForm();
            Application.Run(window);
        }
    }
}
