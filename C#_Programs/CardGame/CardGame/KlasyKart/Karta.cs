using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    abstract class Karta
    {
        //ATRYBUTY
        private Kolor kolor;
        private Wartosc wartosc;
        private bool wybrana;

        //KONSTRUKTORY
        public Karta() { }
        public Karta(Kolor kol, Wartosc war) { kolor = kol; wartosc = war; wybrana = false; }

        //METODY
        public abstract void funkcja();
        public abstract void funkcja(int ile);

        public bool czyMoznaPolozycNa(Karta karte){
            if (wartosc == Wartosc.kDama)
                return true;
            if (karte.wartosc == Wartosc.kDama)
                return true;
            if (karte.wartosc == this.wartosc)
                return true;
            if (karte.kolor == this.kolor)
                return true;
            return false;
        }

        public bool czyFunkcyjna()
        {
            bool zwrot = false;
            Wartosc[] wartoscTab = { Wartosc.k2, Wartosc.k3, Wartosc.kWalet, Wartosc.kKrol, Wartosc.kAs };
            foreach (Wartosc icek in wartoscTab)
            {
                if (wartosc == icek)
                {
                    zwrot = true;
                    break;
                }
            }
            return zwrot;
        }

        public static void makeTalia(List<Karta> kontener)
        {
            Kolor[] kolorTab = {Kolor.Pik, Kolor.Kier, Kolor.Trefl, Kolor.Karo};
            Wartosc[] wartoscTab = { Wartosc.k4, Wartosc.k5, Wartosc.k6, Wartosc.k7, Wartosc.k8, Wartosc.k9, Wartosc.k10, Wartosc.kDama};
            foreach (Kolor itko in kolorTab)
            {
                foreach (Wartosc itwa in wartoscTab)
                {
                    kontener.Add(new KartaZwykla(itko, itwa));
                }
                {
                    kontener.Add(new Karta2(itko));
                    kontener.Add(new Karta3(itko));
                    kontener.Add(new KartaWalet(itko));
                    kontener.Add(new KartaKrol(itko));
                    kontener.Add(new KartaAs(itko));
                }
            }
        }

        public static void utworzStosik(List<Karta> kontener, Stack<Karta> stosik)
        {
            Random generator = new Random();
            int max = kontener.Count();
            for (int i = max; i > 0; i--)
            {
                int numerek = generator.Next(i);
                stosik.Push(kontener[numerek]);
                kontener.RemoveAt(numerek);
            }
        }

        public static void utworzStosikZostawJeden(Stack<Karta> kontener, Stack<Karta> stosik)
        {
            Random generator = new Random();
            int max = kontener.Count();
            Karta przechowac = kontener.Pop();
            Karta[] tablica = new Karta[max-1];
            kontener.CopyTo(tablica, 0);
            List<Karta> lista = tablica.ToList();
            for (int i = max-1; i > 0; i--)
            {
                int numerek = generator.Next(i);
                stosik.Push(lista[numerek]);
                lista.RemoveAt(numerek);
            }
            kontener.Clear();
            kontener.Push(przechowac);
        }

        public static void rozdaj(Stack<Karta> stosik, List<Karta> Human, List<Karta> Computer, Stack<Karta> stolik)
        {
            for (int i = 0; i < 5; i++)
            {
                Human.Add(stosik.Pop());
                Computer.Add(stosik.Pop());
            }
            int j = 0;
            Stack<Karta> temporary = new Stack<Karta>();
            while (stosik.Peek().czyFunkcyjna())
            {
                temporary.Push(stosik.Pop());
                j++;
            }
            stolik.Push(stosik.Pop());
            while (j != 0)
            {
                stosik.Push(temporary.Pop());
                j--;
            }
        }

        public static void posortuj(List<Karta> lista)
        {
            lista.Sort((x, y) => x.wartosc.CompareTo(y.wartosc));
        }

        public void rysuj(System.Windows.Forms.PictureBox cel)
        {
            cel.Image = Makao.Properties.Resources.Back;
            switch (wartosc) {
                case Wartosc.kAs :
                    switch (kolor){
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.PikAs; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.KaroAs; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.TreflAs; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.KierAs; break;
                    } break;
                case Wartosc.k2 :
                    switch(kolor){
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik2; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo2; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl2; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier2; break;
                    } break;
                case Wartosc.k3:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik3; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo3; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl3; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier3; break;
                    } break;
                case Wartosc.k4:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik4; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo4; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl4; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier4; break;
                    } break;
                case Wartosc.k5:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik5; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo5; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl5; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier5; break;
                    } break;
                case Wartosc.k6:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik6; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo6; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl6; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier6; break;
                    } break;
                case Wartosc.k7:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik7; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo7; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl7; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier7; break;
                    } break;
                case Wartosc.k8:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik8; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo8; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl8; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier8; break;
                    } break;
                case Wartosc.k9:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik9; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo9; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl9; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier9; break;
                    } break;
                case Wartosc.k10:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.Pik10; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.Karo10; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.Trefl10; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.Kier10; break;
                    } break;
                case Wartosc.kWalet:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.PikWalet; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.KaroWalet; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.TreflWalet; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.KierWalet; break;
                    } break;
                case Wartosc.kDama:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.PikDama; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.KaroDama; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.TreflDama; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.KierDama; break;
                    } break;
                case Wartosc.kKrol:
                    switch (kolor)
                    {
                        case Kolor.Pik: cel.Image = Makao.Properties.Resources.PikKrol; break;
                        case Kolor.Karo: cel.Image = Makao.Properties.Resources.KaroKrol; break;
                        case Kolor.Trefl: cel.Image = Makao.Properties.Resources.TreflKrol; break;
                        case Kolor.Kier: cel.Image = Makao.Properties.Resources.KierKrol; break;
                    } break;
            }

        }

        //GET'y SET'y
        public Kolor getKolor() { return kolor; }
        public void setKolor(Kolor kol) { kolor = kol; }
        public Wartosc getWartosc() { return wartosc; }
        public void setWartosc(Wartosc war) { wartosc = war; }
        public bool getWybrana() { return wybrana; }
        public void setWybrana(bool wyb) { wybrana = wyb; }
    }
}
