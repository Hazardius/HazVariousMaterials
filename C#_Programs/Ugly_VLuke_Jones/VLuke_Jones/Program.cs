using System;
using System.Collections.Generic;
using Data;
using Data.Realm;
using AIMLbot.Utils;

namespace CsClient
{
    public class Program
    {
        static AgentAPI agentVLuke_Jones; //nasz agent, instancja klasy AgentAPI
        static int myEnergy; //tu zapisujemy aktualną energię naszego agenta
        static int mojaPozycjaX;
        static int mojaPozycjaY;
        static bool gracz;
        static bool czyRozmawiam; //przechowuje fakt czy bot rozmawia
        static String rozmowca;
        static String lastMessage;
        static String imie;
        static String groupname;
        static Wspolrzedne najblizszeZrodlo; //przechowuje współrzędne najbliższego źródła energii
        static int kosztDoZrodla;
        static int wysokosc;
        static int smallestCost; //najmniejszy koszt wykonania działania w świecie
        static int[] pozycjaRozmowcy;
        static int kierunekRozmowcy; // 0-polnoc 1-wschod 2-poludnie 3-zachod
        static int[] kierunek; //w komórkach tej zmiennej: [Xy, Yki]
        static WorldParameters cennikSwiata; //tu zapisujemy informacje o świecie
        static AIMLbot.Bot myBot; //bot AIMLowy

        internal class Wspolrzedne
        {
            public int x, y;

            public Wspolrzedne(int a, int b)
            {
                x = a;
                y = b;
            }
        };

        static private class ZnanaMapa
        {
            static private HashSet<ZbadanePole> znanaMapa = new HashSet<ZbadanePole>();
            static private int minX = 0;
            static private int maxX = 0;
            static private int minY = 0;
            static private int maxY = 0;

            static public void dodajPole(int x, int y, int jakaWysokosc, int ileEnergii, bool czyPrzeszkoda)
            {
                if (!test(x, y))
                {
                    znanaMapa.Add(new ZbadanePole(x, y, jakaWysokosc, ileEnergii, czyPrzeszkoda));
                    if (x < minX) minX = x;
                    if (x > maxX) maxX = x;
                    if (y < minY) minY = y;
                    if (y > maxY) maxY = y;
                }
            }

            static public void uaktualnijPole(int x, int y, int jakaWysokosc, int ileEnergii, bool czyPrzeszkoda)
            {
                if (test(x, y))
                {
                    ZbadanePole tePole = znajdzPole(x, y);
                    if (!tePole.getUnrechable())
                        tePole.UaktualnijPole(ileEnergii);
                    else
                    {
                        tePole.reached(jakaWysokosc, ileEnergii, czyPrzeszkoda);
                    }
                }
                else
                {
                    znanaMapa.Add(new ZbadanePole(x, y, jakaWysokosc, ileEnergii, czyPrzeszkoda));
                    if (x < minX) minX = x;
                    if (x > maxX) maxX = x;
                    if (y < minY) minY = y;
                    if (y > maxY) maxY = y;
                }
            }

            static public void uaktualnijPole(int x, int y, int ileOdjeto)
            {
                ZbadanePole pole = znajdzPole(x, y);
                int ileBylo = pole.getEnergia();
                pole.UaktualnijPole(ileBylo - ileOdjeto);
            }

            static public void show()
            {
                Console.Write("\n");
                for (int i = maxY + 1; i >= minY - 1; i--)
                {
                    for (int j = minX - 1; j <= maxX + 1; j++)
                    {
                        ZbadanePole wyswietlane = znajdzPole(j, i);
                        if (wyswietlane == null)
                        {
                            Console.Write("?");
                        }
                        else if (wyswietlane.getUnrechable())
                        {
                            Console.Write("@");
                        }
                        else if (wyswietlane.getPrzeszkoda())
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            if ((mojaPozycjaX == j) && (mojaPozycjaY == i))
                            {
                                switch (kierunek[0])
                                {
                                    case 1:
                                        Console.Write(">");
                                        break;
                                    case 0:
                                        if (kierunek[1] == 1)
                                        {
                                            Console.Write("A");
                                        }
                                        else
                                        {
                                            Console.Write("V");
                                        }
                                        break;
                                    case -1:
                                        Console.Write("<");
                                        break;
                                }
                            }
                            else if (wyswietlane.getEnergia() == 0)
                            {
                                Console.Write(" ");
                            }
                            else
                                Console.Write("E");
                        }
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }

            static public String toString()
            {
                return "";
            }

            static public void dodajMapeZeStringa(String mapaString)
            {
                return;
            }

            //Zwraca null w razie nieznanego mu pola.
            static public ZbadanePole znajdzPole(int x, int y)
            {
                foreach (ZbadanePole pole in znanaMapa)
                {
                    if ((pole.getX() == x) && (pole.getY() == y))
                        return pole;
                }
                return null;
            }

            //Sprawdza, czy dane pole istnieje na mapie.
            static private bool test(int x, int y)
            {
                foreach (ZbadanePole pole in znanaMapa)
                {
                    if ((pole.getX() == x) && (pole.getY() == y))
                        return true;
                }
                return false;
            }

            static public Wspolrzedne findClosestEnergy()
            {
                List<ZbadanePole> listaEnergii = new List<ZbadanePole>();
                foreach (ZbadanePole zp in znanaMapa)
                {
                    if (zp.getEnergia() != 0)
                        listaEnergii.Add(zp);
                }
                if (listaEnergii.Count == 0)
                {
                    return null;
                }
                int minKoszt = 10000;
                ZbadanePole closest = null;
                foreach (ZbadanePole ep in listaEnergii)
                {
                    int koszt = findShortestWay(ep.getX(), ep.getY());
                    if (koszt < minKoszt)
                    {
                        minKoszt = koszt;
                        closest = ep;
                    }
                }
                return new Wspolrzedne(closest.getX(), closest.getY());
            }

            /**
             * firstStep return values:
             * 0-noWay 1-stepUp 2-leftStep 3-rightStep 4-backStep
             */
            static public void oneStepToThe(int x, int y)
            {
                int[] temp = new int[2];
                int whatever = 0;
                temp = findShortestWay(x, y, whatever);
                if (temp[0] >= 0)
                {
                    switch (temp[1])
                    {
                        case 1:
                            StepForward();
                            break;
                        case 2:
                            RotateLeft();
                            StepForward();
                            break;
                        case 3:
                            RotateRight();
                            StepForward();
                            break;
                        case 4:
                            RotateLeft();
                            RotateLeft();
                            StepForward();
                            break;
                    }
                    najblizszeZrodlo = ZnanaMapa.findClosestEnergy();
                    if (najblizszeZrodlo != null)
                    {
                        kosztDoZrodla = ZnanaMapa.findShortestWay(najblizszeZrodlo.x, najblizszeZrodlo.y);
                    }
                    else
                    {
                        kosztDoZrodla = -1;
                    }
                }
                else
                {
                    if (!test(x, y))
                    {
                        ZbadanePole unrechable = new ZbadanePole(x, y, true);
                        ZnanaMapa.znanaMapa.Add(unrechable);
                    }
                }
            }

            static public int findShortestWay(int x, int y)
            {
                int whatever = 0;
                return findShortestWay(x, y, whatever)[0];
            }

            /**
             * firstStep return values:
             * 0-noWay 1-stepUp 2-leftStep 3-rightStep 4-backStep
             */
            //-1 to nieosiagalne pole!!!
            static public int[] findShortestWay(int x, int y, int firstStep)
            {
                int kier = -1;
                List<Wspolrzedne> before = new List<Wspolrzedne>();
                int limit = (Math.Abs(mojaPozycjaX - x) + Math.Abs(mojaPozycjaY - y)) + 2;
                int[] temp = new int[2];
                temp = znajdzDrogePowrotnaRek(x, y, kier, before, 0, limit);
                temp[0] += cennikSwiata.moveCost;
                if (temp[0] < limit * cennikSwiata.moveCost)
                    return temp;
                temp[0] = -1;
                temp[1] = 0;
                return temp;
            }

            //lastKier - kierunek z ktorego weszlismy 0-gora 1-prawo 2-dol 3-lewo
            static private int[] znajdzDrogePowrotnaRek(int x, int y, int lastKier, List<Wspolrzedne> before, int upCost, int limit)
            {
                if (before.Count > limit)
                {
                    int[] wczesniak = new int[2];
                    wczesniak[0] = limit * cennikSwiata.moveCost * 2;
                    wczesniak[1] = 0;
                    return wczesniak;
                }
                int firstStep = 0;
                int overalCost = limit * cennikSwiata.moveCost;
                int koszt = upCost;

                //Sprawdzenie, czy dalej mamy "po x" czy "po y".
                //if (Math.Abs(mojaPozycjaX - x) > Math.Abs(mojaPozycjaY - y))

                //Sprawdzenie, czy jestesmy u celu!
                #region jestesUCelu
                if ((mojaPozycjaX == x) && (mojaPozycjaY == y))
                {
                    switch (lastKier)
                    {
                        case 0:
                            switch (kierunek[0])
                            {
                                case 1:
                                    koszt += cennikSwiata.rotateCost;
                                    firstStep = 2;
                                    break;
                                case 0:
                                    if (kierunek[1] == 1)
                                    {
                                        firstStep = 1;
                                    }
                                    else
                                    {
                                        koszt += cennikSwiata.rotateCost * 2;
                                        firstStep = 4;
                                    }
                                    break;
                                case -1:
                                    koszt += cennikSwiata.rotateCost;
                                    firstStep = 3;
                                    break;
                            };
                            break;
                        case 1:
                            switch (kierunek[0])
                            {
                                case 1:
                                    firstStep = 1;
                                    break;
                                case 0:
                                    koszt += cennikSwiata.rotateCost;
                                    if (kierunek[1] == 1)
                                    {
                                        firstStep = 3;
                                    }
                                    else
                                    {
                                        firstStep = 2;
                                    }
                                    break;
                                case -1:
                                    koszt += cennikSwiata.rotateCost * 2;
                                    firstStep = 4;
                                    break;
                            };
                            break;
                        case 2:
                            switch (kierunek[0])
                            {
                                case 1:
                                    koszt += cennikSwiata.rotateCost;
                                    firstStep = 3;
                                    break;
                                case 0:
                                    if (kierunek[1] == 1)
                                    {
                                        koszt += cennikSwiata.rotateCost * 2;
                                        firstStep = 4;
                                    }
                                    else
                                    {
                                        firstStep = 1;
                                    }
                                    break;
                                case -1:
                                    koszt += cennikSwiata.rotateCost;
                                    firstStep = 2;
                                    break;
                            };
                            break;
                        case 3:
                            switch (kierunek[0])
                            {
                                case 1:
                                    koszt += cennikSwiata.rotateCost * 2;
                                    firstStep = 4;
                                    break;
                                case 0:
                                    koszt += cennikSwiata.rotateCost;
                                    if (kierunek[1] == 1)
                                    {
                                        firstStep = 2;
                                    }
                                    else
                                    {
                                        firstStep = 3;
                                    }
                                    break;
                                case -1:
                                    firstStep = 1;
                                    break;
                            };
                            break;
                    }
                    overalCost = koszt;
                }
                #endregion
                #region ifZachod
                //Sprawdzenie, czy idziemy na wschod czy na zachod.
                else if (mojaPozycjaX - x > 0)
                {
                    ZbadanePole nextStep = ZnanaMapa.znajdzPole(x + 1, y);
                    before.Add(new Wspolrzedne(x, y));
                    if (nextStep != null)
                        if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                        {
                            int nextKier = 3;
                            int[] temp = new int[2];
                            temp[0] = upCost;
                            if (!before.Exists(delegate(Wspolrzedne w)
                            {
                                if ((w.x == x + 1) && (w.y == y))
                                    return true;
                                else
                                    return false;
                            }))
                            {
                                if (before.Count > 1)
                                {
                                    ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                    int nowaWysokosc = nextStep.getWysokosc();

                                    temp[0] += cennikSwiata.moveCost;
                                    temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                        (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                        .getWysokosc())) / 100));
                                    if ((lastKier == 0) || (lastKier == 2))
                                        temp[0] += cennikSwiata.rotateCost;
                                    if (lastKier == 1)
                                        temp[0] += cennikSwiata.rotateCost * 2;
                                }
                                temp = znajdzDrogePowrotnaRek(x + 1, y, nextKier, before, temp[0], limit);

                                if (overalCost > temp[0])
                                {
                                    overalCost = temp[0];
                                    firstStep = temp[1];
                                }
                            }
                        }
                    if (mojaPozycjaY - y > 0)
                    {
                        nextStep = ZnanaMapa.znajdzPole(x, y + 1);
                        if (nextStep != null)
                            if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                            {
                                int nextKier = 2;
                                int[] temp = new int[2];
                                temp[0] = upCost;
                                if (!before.Exists(delegate(Wspolrzedne w)
                                {
                                    if ((w.x == x) && (w.y == y + 1))
                                        return true;
                                    else
                                        return false;
                                }))
                                {
                                    if (before.Count > 1)
                                    {
                                        ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                        int nowaWysokosc = nextStep.getWysokosc();

                                        temp[0] += cennikSwiata.moveCost;
                                        temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                            (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                            .getWysokosc())) / 100));
                                        if ((lastKier == 1) || (lastKier == 3))
                                            temp[0] += cennikSwiata.rotateCost;
                                        if (lastKier == 2)
                                            temp[0] += cennikSwiata.rotateCost * 2;
                                    }
                                    temp = znajdzDrogePowrotnaRek(x, y + 1, nextKier, before, temp[0], limit);

                                    if (overalCost > temp[0])
                                    {
                                        overalCost = temp[0];
                                        firstStep = temp[1];
                                    }
                                }
                            }
                        nextStep = ZnanaMapa.znajdzPole(x, y - 1);
                        if (nextStep != null)
                            if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                            {
                                int nextKier = 0;
                                int[] temp = new int[2];
                                temp[0] = upCost;
                                if (!before.Exists(delegate(Wspolrzedne w)
                                {
                                    if ((w.x == x) && (w.y == y - 1))
                                        return true;
                                    else
                                        return false;
                                }))
                                {
                                    if (before.Count > 1)
                                    {
                                        ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                        int nowaWysokosc = nextStep.getWysokosc();

                                        temp[0] += cennikSwiata.moveCost;
                                        temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                            (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                            .getWysokosc())) / 100));
                                        if ((lastKier == 1) || (lastKier == 3))
                                            temp[0] += cennikSwiata.rotateCost;
                                        if (lastKier == 0)
                                            temp[0] += cennikSwiata.rotateCost * 2;
                                    }
                                    temp = znajdzDrogePowrotnaRek(x, y - 1, nextKier, before, temp[0], limit);

                                    if (overalCost > temp[0])
                                    {
                                        overalCost = temp[0];
                                        firstStep = temp[1];
                                    }
                                }
                            }
                    }
                    else
                    {
                        nextStep = ZnanaMapa.znajdzPole(x, y - 1);
                        if (nextStep != null)
                            if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                            {
                                int nextKier = 0;
                                int[] temp = new int[2];
                                temp[0] = upCost;
                                if (!before.Exists(delegate(Wspolrzedne w)
                                {
                                    if ((w.x == x) && (w.y == y - 1))
                                        return true;
                                    else
                                        return false;
                                }))
                                {
                                    if (before.Count > 1)
                                    {
                                        ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                        int nowaWysokosc = nextStep.getWysokosc();

                                        temp[0] += cennikSwiata.moveCost;
                                        temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                            (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                            .getWysokosc())) / 100));
                                        if ((lastKier == 1) || (lastKier == 3))
                                            temp[0] += cennikSwiata.rotateCost;
                                        if (lastKier == 0)
                                            temp[0] += cennikSwiata.rotateCost * 2;
                                    }
                                    temp = znajdzDrogePowrotnaRek(x, y - 1, nextKier, before, temp[0], limit);

                                    if (overalCost > temp[0])
                                    {
                                        overalCost = temp[0];
                                        firstStep = temp[1];
                                    }
                                }
                            }
                        nextStep = ZnanaMapa.znajdzPole(x, y + 1);
                        if (nextStep != null)
                            if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                            {
                                int nextKier = 2;
                                int[] temp = new int[2];
                                temp[0] = upCost;
                                if (!before.Exists(delegate(Wspolrzedne w)
                                {
                                    if ((w.x == x) && (w.y == y + 1))
                                        return true;
                                    else
                                        return false;
                                }))
                                {
                                    if (before.Count > 1)
                                    {
                                        ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                        int nowaWysokosc = nextStep.getWysokosc();

                                        temp[0] += cennikSwiata.moveCost;
                                        temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                            (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                            .getWysokosc())) / 100));
                                        if ((lastKier == 1) || (lastKier == 3))
                                            temp[0] += cennikSwiata.rotateCost;
                                        if (lastKier == 2)
                                            temp[0] += cennikSwiata.rotateCost * 2;
                                    }
                                    temp = znajdzDrogePowrotnaRek(x, y + 1, nextKier, before, temp[0], limit);

                                    if (overalCost > temp[0])
                                    {
                                        overalCost = temp[0];
                                        firstStep = temp[1];
                                    }
                                }
                            }
                    }
                    nextStep = ZnanaMapa.znajdzPole(x - 1, y);
                    if (nextStep != null)
                        if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                        {
                            int nextKier = 1;
                            int[] temp = new int[2];
                            temp[0] = upCost;
                            if (!before.Exists(delegate(Wspolrzedne w)
                            {
                                if ((w.x == x - 1) && (w.y == y))
                                    return true;
                                else
                                    return false;
                            }))
                            {
                                if (before.Count > 1)
                                {
                                    ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                    int nowaWysokosc = nextStep.getWysokosc();

                                    temp[0] += cennikSwiata.moveCost;
                                    temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                        (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                        .getWysokosc())) / 100));
                                    if ((lastKier == 0) || (lastKier == 2))
                                        temp[0] += cennikSwiata.rotateCost;
                                    if (lastKier == 3)
                                        temp[0] += cennikSwiata.rotateCost * 2;
                                }
                                temp = znajdzDrogePowrotnaRek(x - 1, y, nextKier, before, temp[0], limit);

                                if (overalCost > temp[0])
                                {
                                    overalCost = temp[0];
                                    firstStep = temp[1];
                                }
                            }
                        }
                }
                #endregion
                #region elseWschod
                else //Idziemy na wschod
                {
                    ZbadanePole nextStep = ZnanaMapa.znajdzPole(x - 1, y);
                    before.Add(new Wspolrzedne(x, y));
                    if (nextStep != null)
                        if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                        {
                            int nextKier = 1;
                            int[] temp = new int[2];
                            temp[0] = upCost;
                            if (!before.Exists(delegate(Wspolrzedne w)
                            {
                                if ((w.x == x - 1) && (w.y == y))
                                    return true;
                                else
                                    return false;
                            }))
                            {
                                if (before.Count > 1)
                                {
                                    ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                    int nowaWysokosc = nextStep.getWysokosc();

                                    temp[0] += cennikSwiata.moveCost;
                                    temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                        (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                        .getWysokosc())) / 100));
                                    if ((lastKier == 0) || (lastKier == 2))
                                        temp[0] += cennikSwiata.rotateCost;
                                    if (lastKier == 3)
                                        temp[0] += cennikSwiata.rotateCost * 2;
                                }
                                temp = znajdzDrogePowrotnaRek(x - 1, y, nextKier, before, temp[0], limit);

                                if (overalCost > temp[0])
                                {
                                    overalCost = temp[0];
                                    firstStep = temp[1];
                                }
                            }
                        }
                    if (mojaPozycjaY - y > 0)
                    {
                        nextStep = ZnanaMapa.znajdzPole(x, y + 1);
                        if (nextStep != null)
                            if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                            {
                                int nextKier = 2;
                                int[] temp = new int[2];
                                temp[0] = upCost;
                                if (!before.Exists(delegate(Wspolrzedne w)
                                {
                                    if ((w.x == x) && (w.y == y + 1))
                                        return true;
                                    else
                                        return false;
                                }))
                                {
                                    if (before.Count > 1)
                                    {
                                        ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                        int nowaWysokosc = nextStep.getWysokosc();

                                        temp[0] += cennikSwiata.moveCost;
                                        temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                            (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                            .getWysokosc())) / 100));
                                        if ((lastKier == 1) || (lastKier == 3))
                                            temp[0] += cennikSwiata.rotateCost;
                                        if (lastKier == 2)
                                            temp[0] += cennikSwiata.rotateCost * 2;
                                    }
                                    temp = znajdzDrogePowrotnaRek(x, y + 1, nextKier, before, temp[0], limit);

                                    if (overalCost > temp[0])
                                    {
                                        overalCost = temp[0];
                                        firstStep = temp[1];
                                    }
                                }
                            }
                        nextStep = ZnanaMapa.znajdzPole(x, y - 1);
                        if (nextStep != null)
                            if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                            {
                                int nextKier = 0;
                                int[] temp = new int[2];
                                temp[0] = upCost;
                                if (!before.Exists(delegate(Wspolrzedne w)
                                {
                                    if ((w.x == x) && (w.y == y - 1))
                                        return true;
                                    else
                                        return false;
                                }))
                                {
                                    if (before.Count > 1)
                                    {
                                        ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                        int nowaWysokosc = nextStep.getWysokosc();

                                        temp[0] += cennikSwiata.moveCost;
                                        temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                            (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                            .getWysokosc())) / 100));
                                        if ((lastKier == 1) || (lastKier == 3))
                                            temp[0] += cennikSwiata.rotateCost;
                                        if (lastKier == 0)
                                            temp[0] += cennikSwiata.rotateCost * 2;
                                    }
                                    temp = znajdzDrogePowrotnaRek(x, y - 1, nextKier, before, temp[0], limit);

                                    if (overalCost > temp[0])
                                    {
                                        overalCost = temp[0];
                                        firstStep = temp[1];
                                    }
                                }
                            }
                    }
                    else
                    {
                        nextStep = ZnanaMapa.znajdzPole(x, y - 1);
                        if (nextStep != null)
                            if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                            {
                                int nextKier = 0;
                                int[] temp = new int[2];
                                temp[0] = upCost;
                                if (!before.Exists(delegate(Wspolrzedne w)
                                {
                                    if ((w.x == x) && (w.y == y - 1))
                                        return true;
                                    else
                                        return false;
                                }))
                                {
                                    if (before.Count > 1)
                                    {
                                        ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                        int nowaWysokosc = nextStep.getWysokosc();

                                        temp[0] += cennikSwiata.moveCost;
                                        temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                            (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                            .getWysokosc())) / 100));
                                        if ((lastKier == 1) || (lastKier == 3))
                                            temp[0] += cennikSwiata.rotateCost;
                                        if (lastKier == 0)
                                            temp[0] += cennikSwiata.rotateCost * 2;
                                    }
                                    temp = znajdzDrogePowrotnaRek(x, y - 1, nextKier, before, temp[0], limit);

                                    if (overalCost > temp[0])
                                    {
                                        overalCost = temp[0];
                                        firstStep = temp[1];
                                    }
                                }
                            }
                        nextStep = ZnanaMapa.znajdzPole(x, y + 1);
                        if (nextStep != null)
                            if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                            {
                                int nextKier = 2;
                                int[] temp = new int[2];
                                temp[0] = upCost;
                                if (!before.Exists(delegate(Wspolrzedne w)
                                {
                                    if ((w.x == x) && (w.y == y + 1))
                                        return true;
                                    else
                                        return false;
                                }))
                                {
                                    if (before.Count > 1)
                                    {
                                        ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                        int nowaWysokosc = nextStep.getWysokosc();

                                        temp[0] += cennikSwiata.moveCost;
                                        temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                            (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                            .getWysokosc())) / 100));
                                        if ((lastKier == 1) || (lastKier == 3))
                                            temp[0] += cennikSwiata.rotateCost;
                                        if (lastKier == 2)
                                            temp[0] += cennikSwiata.rotateCost * 2;
                                    }
                                    temp = znajdzDrogePowrotnaRek(x, y + 1, nextKier, before, temp[0], limit);

                                    if (overalCost > temp[0])
                                    {
                                        overalCost = temp[0];
                                        firstStep = temp[1];
                                    }
                                }
                            }
                    }
                    nextStep = ZnanaMapa.znajdzPole(x + 1, y);
                    if (nextStep != null)
                        if (!((nextStep.getPrzeszkoda()) || (nextStep.getUnrechable())))
                        {
                            int nextKier = 3;
                            int[] temp = new int[2];
                            temp[0] = upCost;
                            if (!before.Exists(delegate(Wspolrzedne w)
                            {
                                if ((w.x == x + 1) && (w.y == y))
                                    return true;
                                else
                                    return false;
                            }))
                            {
                                if (before.Count > 1)
                                {
                                    ZbadanePole tuStoje = ZnanaMapa.znajdzPole(x, y);
                                    int nowaWysokosc = nextStep.getWysokosc();

                                    temp[0] += cennikSwiata.moveCost;
                                    temp[0] += Convert.ToInt32(Math.Ceiling(Convert.ToDouble
                                        (cennikSwiata.moveCost * (nowaWysokosc - tuStoje
                                        .getWysokosc())) / 100));
                                    if ((lastKier == 0) || (lastKier == 2))
                                        temp[0] += cennikSwiata.rotateCost;
                                    if (lastKier == 1)
                                        temp[0] += cennikSwiata.rotateCost * 2;
                                }
                                temp = znajdzDrogePowrotnaRek(x + 1, y, nextKier, before, temp[0], limit);

                                if (overalCost > temp[0])
                                {
                                    overalCost = temp[0];
                                    firstStep = temp[1];
                                }
                            }
                        }
                }
                #endregion
                before.Remove(
                    before.Find(delegate(Wspolrzedne w)
                    {
                        if ((w.x == x) && (w.y == y))
                            return true;
                        else
                            return false;
                    })
                );
                int[] zwrot = new int[2];
                zwrot[0] = overalCost;
                zwrot[1] = firstStep;
                return zwrot;
            }

            static public Wspolrzedne najblizszeUkryte()
            {
                for (int i = 1; ; i++)
                {
                    int lTestowanych = 0;
                    List<Wspolrzedne> zakrytePola = new List<Wspolrzedne>();
                    for (int j = mojaPozycjaY + i; j >= mojaPozycjaY - i; j--)
                    {
                        for (int k = mojaPozycjaX - i; k <= mojaPozycjaX + i; k++)
                        {
                            if ((mojaPozycjaY + i > j) && (mojaPozycjaY - i < j)
                                && (mojaPozycjaX - i < k) && (mojaPozycjaX + i > k))
                            {
                                goto Nastepne;
                            }
                            if (((k == mojaPozycjaX - i) || (k == mojaPozycjaX + i))
                                && ((j == mojaPozycjaY + i) || (j == mojaPozycjaY - i)))
                            {
                                goto Nastepne;
                            }
                            ZbadanePole testowane = znajdzPole(k, j);
                            if (testowane == null)
                            {
                                lTestowanych++;
                                for (int l = j + 1; l >= j - 1; l--)
                                {
                                    for (int m = k - 1; m <= k + 1;
                                        m++)
                                    {
                                        ZbadanePole dookolaTestowanego = znajdzPole(m, l);
                                        if (!((dookolaTestowanego == null)
                                            || dookolaTestowanego.getPrzeszkoda()
                                            || dookolaTestowanego.getUnrechable()))
                                        {
                                            Wspolrzedne dodawana = new Wspolrzedne(k, j);
                                            zakrytePola.Add(dodawana);
                                            goto Nastepne;
                                        }
                                    }
                                }
                            }
                            else
                                if (testowane.getUnrechable())
                                {
                                    lTestowanych++;
                                    for (int l = j + 1; l >= j - 1; l--)
                                    {
                                        for (int m = k - 1; m <= k + 1;
                                            m++)
                                        {
                                            ZbadanePole dookolaTestowanego = znajdzPole(m, l);
                                            if (!((dookolaTestowanego == null)
                                                || dookolaTestowanego.getPrzeszkoda()
                                                || dookolaTestowanego.getUnrechable()))
                                            {
                                                Wspolrzedne dodawana = new Wspolrzedne(k, j);
                                                zakrytePola.Add(dodawana);
                                                goto Nastepne;
                                            }
                                        }
                                    }
                                }
                        Nastepne:
                            ;
                        }
                    }
                    if (zakrytePola.Count == 0)
                    {
                        if (lTestowanych == (8 * i) - 4)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Wspolrzedne closest = null;
                        int shortestWay = 2 * cennikSwiata.initialEnergy;
                        foreach (Wspolrzedne wsp in zakrytePola)
                        {
                            int comparer = findShortestWay(wsp.x, wsp.y);
                            if ((closest == null) || (shortestWay > comparer))
                            {
                                closest = wsp;
                                shortestWay = comparer;
                            }
                        }
                        return closest;
                    }
                }
                return null;
            }
        }

        private class ZbadanePole
        {
            private int x, y; //Współrzędne położenia pola w stosunku do pozycji startowej.
            private int wysokosc;
            private bool przeszkoda;
            private int energia;
            private bool unrechable;

            public ZbadanePole(int iks, int ygrek, int jakaWysokosc, int ileEnergii, bool czyPrzeszkoda)
            {
                x = iks;
                y = ygrek;
                wysokosc = jakaWysokosc;
                energia = ileEnergii;
                przeszkoda = czyPrzeszkoda;
                unrechable = false;
            }

            public ZbadanePole(int iks, int ygrek, bool unreachable)
            {
                x = iks;
                y = ygrek;
                wysokosc = 100;
                energia = 0;
                przeszkoda = false;
                unrechable = true;
            }

            public void UaktualnijPole(int ileEnergii)
            {
                energia = ileEnergii;
            }

            public void reached(int jakaWysokosc, int ileEnergii, bool czyPrzeszkoda)
            {
                unrechable = false;
                przeszkoda = czyPrzeszkoda;
                energia = ileEnergii;
                wysokosc = jakaWysokosc;
            }

            #region getySety
            public int getX()
            {
                return x;
            }

            public int getY()
            {
                return y;
            }

            public int getWysokosc()
            {
                return wysokosc;
            }

            public int getEnergia()
            {
                return energia;
            }

            public void pobierzEnergie(int ile)
            {
                if (energia > 0)
                {
                    energia = energia - ile;
                }
                else
                {
                    throw new Exception("Udało się pobrać energię z pola na którym jej nie ma!"
                    + " Czemu wogóle agent próbował ją pobrać?");
                }
            }

            public void setEnergia(int nowaMoc)
            {
                energia = nowaMoc;
            }

            public bool getUnrechable()
            {
                return unrechable;
            }

            public void setUnrechable()
            {
                unrechable = true;
            }

            public bool getPrzeszkoda()
            {
                return przeszkoda;
            }
            #endregion
        }

        #region WlasciweMetodyKlasy
        // Nasza metoda nasłuchująca
        static void Listen(String krzyczacyAgent, String komunikat)
        {
            if (krzyczacyAgent == imie + "." + groupname)
            {
                Console.WriteLine(krzyczacyAgent + " krzyczy " + komunikat);
                Console.WriteLine("~Słysze własne słowa~");
            }
            else
            {
                if (rozmowca == krzyczacyAgent)
                {
                    Console.WriteLine(krzyczacyAgent + ": " + komunikat);
                    if (!gracz)
                    {
                        rozmowca = krzyczacyAgent;
                        lastMessage = komunikat;
                        czyRozmawiam = true;
                        InterpretujWiadomosc(komunikat);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //powtarzamy czynnosci az nam się uda
            while (true)
            {
                agentVLuke_Jones = new AgentAPI(Listen); //tworzymy nowe AgentAPI,
                //podając w parametrze naszą metodę nasłuchującą

                // pobieramy parametry połączenia i agenta z klawiatury
                Console.Write("Wczytano IP serwera.\n");
                String ip = "atlantyda.vm.wmi.amu.edu.pl";

                Console.Write("Wczytano nazwe druzyny.\n");
                groupname = "VLuke_Jones";

                Console.Write("Wprowadzono haslo.\n");
                String grouppass = "xlpxxf";

                Console.Write("Podaj nazwe swiata: ");
                String worldname = Console.ReadLine();

                Console.Write("Podaj imie: ");
                imie = Console.ReadLine();

                try
                {
                    //łączymy się z serwerem. Odbieramy parametry świata i wyświetlamy je      
                    cennikSwiata = agentVLuke_Jones.Connect(ip, 6008, groupname, grouppass,
                        worldname, imie);
                    Console.WriteLine(cennikSwiata.initialEnergy + " - Maksymalna energia");
                    Console.WriteLine(cennikSwiata.maxRecharge + " - Maksymalne doładowanie");
                    Console.WriteLine(cennikSwiata.sightScope + " - Zasięg widzenia");
                    Console.WriteLine(cennikSwiata.hearScope + " - Zasięg słyszenia");
                    Console.WriteLine(cennikSwiata.moveCost + " - Koszt chodzenia");
                    Console.WriteLine(cennikSwiata.rotateCost + " - Koszt obrotu");
                    Console.WriteLine(cennikSwiata.speakCost + " - Koszt mówienia");

                    smallestCost = cennikSwiata.moveCost;
                    if (smallestCost > cennikSwiata.rotateCost)
                        smallestCost = cennikSwiata.rotateCost;
                    if (smallestCost > cennikSwiata.speakCost)
                        smallestCost = cennikSwiata.speakCost;
                    kosztDoZrodla = -1;

                    Console.Write("Wybierz tryb:\n(0)Random\n(1)SmartBot\n(2)Klawiatura\n");
                    String tryb = Console.ReadLine();

                    pozycjaRozmowcy = new int[2];
                    pozycjaRozmowcy[0] = -1000;
                    pozycjaRozmowcy[1] = -1000;
                    kierunekRozmowcy = 0;
                    czyRozmawiam = false;
                    gracz = false;

                    myBot = new AIMLbot.Bot();
                    myBot.loadSettings();
                    myBot.loadAIMLFromFiles();

                    //ustawiamy nasza energie na poczatkowa energie kazdego agenta w danym swiecie
                    myEnergy = cennikSwiata.initialEnergy;
                    if (tryb == "0")
                        Zachowanie("Random");
                    if (tryb == "1")
                        Zachowanie("SmartBot");
                    if (tryb == "2")
                    {
                        gracz = true;
                        KeyReader();
                    }
                    //na koncu rozlaczamy naszego agenta
                    try
                    {
                        agentVLuke_Jones.Disconnect();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Disconnected with problems! " + e.Message);
                    }
                    Console.ReadKey();
                    break;
                }
                //w przypadku mało poważnego błędu, jak podanie złego hasła,
                //rzucany jest wyjątek NonCriticalException; zaczynamy od nowa
                catch (NonCriticalException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // w przypadku każdego innego wyjątku niż NonCriticalException
                //powinniśmy zakończyć program; taki wyjątek nie powinien się zdarzyć
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.ReadKey();
                }
            }
        }
        
        #region zachowanie
        static int CoTeraz()
        {
            if (ZnanaMapa.najblizszeUkryte() == null)
            {
                Console.WriteLine("Ile moglem, tyle zbadalem!");
                return 4;
            }

            return new Random().Next(4);
        }

        internal static void Czekaj(int timeSec)
        {
            System.Threading.Thread.Sleep(1000 * timeSec);
            Look();
            return;
        }
        
        //Zachowanie naszego bota
        static void Zachowanie(String myState)
        {
            kierunek = new int[2];
            wysokosc = 100;
            kierunek[0] = 0;
            kierunek[1] = 1;
            mojaPozycjaX = 0;
            mojaPozycjaY = 0;
            ZnanaMapa.dodajPole(0, 0, 100, 0, false);
            Look();
            if (3 * cennikSwiata.rotateCost < (myEnergy - cennikSwiata.rotateCost))
            {
                if (new Random().Next(2) == 1)
                {
                    RotateLeft();
                    RotateLeft();
                    RotateLeft();
                }
                else
                {
                    RotateRight();
                    RotateRight();
                    RotateRight();
                }
            }
            najblizszeZrodlo = ZnanaMapa.findClosestEnergy();
            if (najblizszeZrodlo != null)
            {
                kosztDoZrodla = ZnanaMapa.findShortestWay(najblizszeZrodlo.x, najblizszeZrodlo.y);
            }
            else
            {
                kosztDoZrodla = -1;
            }
            bool loop = true;
            while (loop)
            {
                //Czekaj(1); //FUFUFUFUFU A JA ZASTANAWIAŁEM SIĘ CZEMU TAK WOLNO DZIAŁA!!! xP
                //Console.WriteLine("Moja energia: " + myEnergy);
                if ((myEnergy < smallestCost) || (myEnergy < cennikSwiata.moveCost))
                {
                    Console.WriteLine("Mam za mało energii aby cokolwiek zrobić! Ginę!");
                    break;
                }
                if ((czyRozmawiam) && (myEnergy - ZnanaMapa.znajdzPole(najblizszeZrodlo.x,
                            najblizszeZrodlo.y).getEnergia() >= kosztDoZrodla
                            + cennikSwiata.speakCost))
                {
                    Talk(rozmowca, lastMessage);
                    continue;
                }
                Wspolrzedne cel = ZnanaMapa.najblizszeUkryte();
                if (cel == null)
                {
                    Console.WriteLine("Ile moglem, tyle zbadalem!\nWIN!");
                    break;
                }
                if (myState == "Random")
                {
                    if (ZnanaMapa.najblizszeUkryte() == null)
                    {
                        break;
                    }
                    switch (new Random().Next(4))
                    {
                        case 4/*"wyjdz"*/: loop = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (najblizszeZrodlo != null)
                    {
                        if (ZnanaMapa.znajdzPole(najblizszeZrodlo.x,
                            najblizszeZrodlo.y).getEnergia() > 0)
                        {
                            if ((myEnergy < cennikSwiata.initialEnergy - ZnanaMapa.znajdzPole(najblizszeZrodlo.x,
                            najblizszeZrodlo.y).getEnergia()) || (myEnergy < kosztDoZrodla
                            + 2 * cennikSwiata.moveCost))
                            {
                                cel = najblizszeZrodlo;
                            }
                        }
                        else
                        {
                            if (myEnergy < kosztDoZrodla
                                + cennikSwiata.moveCost * 3)
                            {
                                cel = najblizszeZrodlo;
                            }
                        }
                    }
                    ZnanaMapa.oneStepToThe(cel.x, cel.y);
                }
            }
            ZnanaMapa.show();
            Console.WriteLine("Press SPACEBAR to end!");
            loop = true;
            while (loop)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Spacebar: loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        //funkcja wykonywująca określone akcje w zależności od naciśniętego przycisku
        //Zostawiona do celów diagnostycznych!
        static void KeyReader()
        {
            kierunek = new int[2];
            wysokosc = 0;
            kierunek[0] = 0;
            kierunek[1] = 1;
            mojaPozycjaX = 0;
            mojaPozycjaY = 0;
            ZnanaMapa.dodajPole(0, 0, 0, 0, false);
            Look();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Moja energia: " + myEnergy);
                if (myEnergy < smallestCost)
                {
                    Console.WriteLine("Mam za mało energii aby cokolwiek zrobić! Ginę!");
                    break;
                }
                if (ZnanaMapa.najblizszeUkryte() == null)
                {
                    Console.WriteLine("Ile moglem, tyle zbadalem! Nie dam rady więcej zbadać!");
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow: StepForward();
                        break;
                    case ConsoleKey.LeftArrow: RotateLeft();
                        break;
                    case ConsoleKey.RightArrow: RotateRight();
                        break;
                    case ConsoleKey.Enter: String message = Console.ReadLine();
                        Speak(message);
                        break;
                    case ConsoleKey.S: ZnanaMapa.show();
                        break;
                    case ConsoleKey.Q: loop = false;
                        break;
                    default: //Console.Beep();
                        break;
                }
            }
        }
        #endregion
        // ładujemy się
        private static void Recharge()
        {
            int added = agentVLuke_Jones.Recharge();
            myEnergy += added;
            ZnanaMapa.uaktualnijPole(mojaPozycjaX, mojaPozycjaY, added);
            ZbadanePole pole = ZnanaMapa.znajdzPole(mojaPozycjaX, mojaPozycjaY);
            if (pole.getEnergia() == 0)
            {
                najblizszeZrodlo = ZnanaMapa.findClosestEnergy();
                if (najblizszeZrodlo != null)
                {
                    kosztDoZrodla = ZnanaMapa.findShortestWay(najblizszeZrodlo.x, najblizszeZrodlo.y);
                }
                else
                {
                    kosztDoZrodla = -1;
                }
            }
            Console.WriteLine("Otrzymano " + added + " energii");
            if (ZnanaMapa.znajdzPole(mojaPozycjaX, mojaPozycjaY).getEnergia() != 0)
                if (!(myEnergy == cennikSwiata.initialEnergy))
                    Recharge();
        }

        #region komunikacja
        private static void Talk(String toWhom, String komunikat)
        {
            AIMLbot.User myUser = new AIMLbot.User(toWhom, myBot);
            if (najblizszeZrodlo != null)
                if ((myEnergy < cennikSwiata.initialEnergy - ZnanaMapa.znajdzPole(najblizszeZrodlo.x,
                            najblizszeZrodlo.y).getEnergia()) || (myEnergy < kosztDoZrodla
                            + 2 * cennikSwiata.speakCost))
                    return;
            AIMLbot.Request r = new AIMLbot.Request(komunikat, myUser, myBot);
            AIMLbot.Result res = myBot.Chat(r);
            if ((res.Output == "")||(res.Output == "Nie rozumiem!"))
            {
                czyRozmawiam = false;
                return;
            }
            Console.WriteLine("Ja: " + res.Output);
            Speak(res.Output);
        }

        private static void InterpretujWiadomosc(String komunikat)
        {
            if ((komunikat == "") || (komunikat == "Nie rozumiem!"))
            {
                czyRozmawiam = false;
                return;
            }
            else
            {

            }
        }

        //przeliczanie koordynatów na relatywny układ rozmówcy
        private static String hisCoordinates(int x, int y)
        {
            int calcX, calcY;
            calcX = 0;
            calcY = 0;
            switch (kierunek[0]) {
                case 1:
                    switch (kierunekRozmowcy)
                    {
                        case 0:
                            calcX = pozycjaRozmowcy[1] - y;
                            calcY = pozycjaRozmowcy[0] - x;
                            break;
                        case 1:
                            calcX = x - pozycjaRozmowcy[0];
                            calcY = y - pozycjaRozmowcy[1];
                            break;
                        case 2:
                            calcX = y - pozycjaRozmowcy[1];
                            calcY = pozycjaRozmowcy[0] - x;
                            break;
                        case 3:
                            calcX = pozycjaRozmowcy[0] - x;
                            calcY = pozycjaRozmowcy[1] - y;
                            break;
                    }
                    break;
                case 0:
                    if (kierunek[1] == 1)
                    {
                        switch (kierunekRozmowcy)
                        {
                            case 0:
                                calcX = x - pozycjaRozmowcy[0];
                                calcY = y - pozycjaRozmowcy[1];
                                break;
                            case 1:
                                calcX = y - pozycjaRozmowcy[1];
                                calcY = pozycjaRozmowcy[0] - x;
                                break;
                            case 2:
                                calcX = pozycjaRozmowcy[0] - x;
                                calcY = pozycjaRozmowcy[1] - y;
                                break;
                            case 3:
                                calcX = pozycjaRozmowcy[1] - y;
                                calcY = pozycjaRozmowcy[0] - x;
                                break;
                        }
                    }
                    else
                    {
                        switch (kierunekRozmowcy)
                        {
                            case 0:
                                calcX = pozycjaRozmowcy[0] - x;
                                calcY = pozycjaRozmowcy[1] - y;
                                break;
                            case 1:
                                calcX = pozycjaRozmowcy[1] - y;
                                calcY = pozycjaRozmowcy[0] - x;
                                break;
                            case 2:
                                calcX = x - pozycjaRozmowcy[0];
                                calcY = y - pozycjaRozmowcy[1];
                                break;
                            case 3:
                                calcX = y - pozycjaRozmowcy[1];
                                calcY = pozycjaRozmowcy[0] - x;
                                break;
                        }
                    }
                    break;
                case -1:
                    switch (kierunekRozmowcy)
                    {
                        case 0:
                            calcX = y - pozycjaRozmowcy[1];
                            calcY = pozycjaRozmowcy[0] - x;
                            break;
                        case 1:
                            calcX = pozycjaRozmowcy[0] - x;
                            calcY = pozycjaRozmowcy[1] - y;
                            break;
                        case 2:
                            calcX = pozycjaRozmowcy[1] - y;
                            calcY = pozycjaRozmowcy[0] - x;
                            break;
                        case 3:
                            calcX = x - pozycjaRozmowcy[0];
                            calcY = y - pozycjaRozmowcy[1];
                            break;
                    }
                    break;
            }
            return "" + calcX + " " + calcY;
        }

        //wysyłamy komunikat
        private static void Speak(String wiadomosc)
        {
            if (!agentVLuke_Jones.Speak(wiadomosc, 1))
                Console.WriteLine("Mowienie nie powiodlo sie - brak energii");
            else
            {
                myEnergy -= cennikSwiata.rotateCost;
                //POPRAWNA LINIA, ALE ATLANTYDA ŹLE DZIAŁA!!!
                //myEnergy -= cennikSwiata.speakCost;
            }
            if (ZnanaMapa.znajdzPole(mojaPozycjaX, mojaPozycjaY).getEnergia() != 0)
                Recharge();
            Look();
        }
        #endregion

        #region poruszanieSie
        //obracamy się w lewo
        private static void RotateLeft()
        {
            if (!agentVLuke_Jones.RotateLeft())
                Console.WriteLine("Obrot nie powiodl sie - brak energii");
            else
            {
                myEnergy -= cennikSwiata.rotateCost;
                switch (kierunek[0])
                {
                    case 1:
                        kierunek[0] = 0;
                        kierunek[1] = 1;
                        break;
                    case 0:
                        if (kierunek[1] == 1)
                        {
                            kierunek[0] = -1;
                            kierunek[1] = 0;
                        }
                        else
                        {
                            kierunek[0] = 1;
                            kierunek[1] = 0;
                        }
                        break;
                    case -1:
                        kierunek[0] = 0;
                        kierunek[1] = -1;
                        break;
                }
            }
            if (ZnanaMapa.znajdzPole(mojaPozycjaX, mojaPozycjaY).getEnergia() != 0)
                Recharge();
            Look();
        }

        //obracamy się w prawo
        private static void RotateRight()
        {
            if (!agentVLuke_Jones.RotateRight())
                Console.WriteLine("Obrot nie powiodl sie - brak energii");
            else
            {
                myEnergy -= cennikSwiata.rotateCost;
                switch (kierunek[0])
                {
                    case 1:
                        kierunek[0] = 0;
                        kierunek[1] = -1;
                        break;
                    case 0:
                        if (kierunek[1] == 1)
                        {
                            kierunek[0] = 1;
                            kierunek[1] = 0;
                        }
                        else
                        {
                            kierunek[0] = -1;
                            kierunek[1] = 0;
                        }
                        break;
                    case -1:
                        kierunek[0] = 0;
                        kierunek[1] = 1;
                        break;
                }
            }
            if (ZnanaMapa.znajdzPole(mojaPozycjaX, mojaPozycjaY).getEnergia() != 0)
                Recharge();
            Look();
        }

        //idziemy do przodu
        private static void StepForward()
        {
            Look();

            ZbadanePole tamIde = ZnanaMapa.znajdzPole(mojaPozycjaX + kierunek[0], mojaPozycjaY
                + kierunek[1]);
            int nowaWysokosc = tamIde.getWysokosc();

            int koszt = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cennikSwiata.moveCost
                * (nowaWysokosc - wysokosc)) / 100));
            koszt += cennikSwiata.moveCost;
            //int koszt = cennikSwiata.moveCost * (1 + (nowaWysokosc - wysokosc) / 100);

            if (isFrontStepable())
            {
                if (!agentVLuke_Jones.StepForward())
                {
                    //Kara za brute force! O.o O tym też nie było nic mówione wcześniej.
                    if (myEnergy >= koszt)
                    {
                        myEnergy -= koszt;
                        Console.WriteLine("Wpadles na cos!!! Koszt: " + koszt);
                    }
                    Console.WriteLine("Wykonanie kroku nie powiodlo sie");
                }
                else
                {
                    if (myEnergy >= koszt)
                    {
                        myEnergy -= koszt;
                        wysokosc = nowaWysokosc;
                        mojaPozycjaX += kierunek[0];
                        mojaPozycjaY += kierunek[1];
                    }
                }
            }
            else
            {
                Czekaj(2);
            }
            if (tamIde.getEnergia() != 0)
                Recharge();
            Look();
        }

        private static bool isFrontStepable()
        {
            OrientedField[] pola = agentVLuke_Jones.Look();
            foreach (OrientedField of in pola)
            {
                if ((of.x == 0) && (of.y == 1))
                    if (of.agent != null)
                        return false;
            }
            return true;
        }
        #endregion

        private static void Look()
        {
            //dostajemy listę pól które widzi nasz agent
            OrientedField[] pola = agentVLuke_Jones.Look();

            //zapisujemy informacje o wszystkich widzianych polach
            foreach (OrientedField pole in pola)
            {
                #region komunikacjaPoZauwazeniu
                if ((najblizszeZrodlo != null) && (pole.agent != null) && (Math.Sqrt(pole.x ^ 2
                    + pole.y ^ 2) <= cennikSwiata.hearScope) && (!gracz))
                    if (pole.agent.agentGroup == groupname)
                        if (((myEnergy < cennikSwiata.initialEnergy - ZnanaMapa.znajdzPole(najblizszeZrodlo.x,
                            najblizszeZrodlo.y).getEnergia()) || (myEnergy < kosztDoZrodla
                            + 2 * cennikSwiata.moveCost)) || ((ZnanaMapa.znajdzPole(najblizszeZrodlo.x,
                            najblizszeZrodlo.y).getEnergia() > 0) && (myEnergy < kosztDoZrodla
                                + cennikSwiata.moveCost * 3)))
                        {
                            switch (kierunek[0])
                            {
                                case 1:
                                    pozycjaRozmowcy[0] = mojaPozycjaX + pole.y;
                                    pozycjaRozmowcy[1] = mojaPozycjaY - pole.x;
                                    break;
                                case 0:
                                    if (kierunek[1] == 1)
                                    {
                                        pozycjaRozmowcy[0] = mojaPozycjaX + pole.x;
                                        pozycjaRozmowcy[1] = mojaPozycjaY + pole.y;
                                    }
                                    else
                                    {
                                        pozycjaRozmowcy[0] = mojaPozycjaX - pole.x;
                                        pozycjaRozmowcy[1] = mojaPozycjaY - pole.y;
                                    }
                                    break;
                                case -1:
                                    pozycjaRozmowcy[0] = mojaPozycjaX - pole.y;
                                    pozycjaRozmowcy[1] = mojaPozycjaY + pole.x;
                                    break;
                            }
                            kierunekRozmowcy = (int)pole.agent.direction;
                            int mojkier = kierunekRozmowcy;
                            if (kierunekRozmowcy % 2 != 0)
                                mojkier = (kierunekRozmowcy + 2) % 4;
                            czyRozmawiam = true;
                            rozmowca = pole.agent.agentGroup + "." + pole.agent.agentname;
                            Talk(rozmowca, "Stój! Jestem na twoim " + hisCoordinates(mojaPozycjaX,
                                mojaPozycjaY) + ". Patrzę na " + mojkier + ".");
                        }
                #endregion
                #region zapisanieOgladanychPol
                switch (kierunek[0])
                {
                    case 1:
                        ZnanaMapa.uaktualnijPole(mojaPozycjaX + pole.y, mojaPozycjaY - pole.x,
                            wysokosc + pole.height, pole.energy, pole.obstacle);
                        break;
                    case 0:
                        if (kierunek[1] == 1)
                        {
                            ZnanaMapa.uaktualnijPole(mojaPozycjaX + pole.x, mojaPozycjaY + pole.y,
                                wysokosc + pole.height, pole.energy, pole.obstacle);
                        }
                        else
                        {
                            ZnanaMapa.uaktualnijPole(mojaPozycjaX - pole.x, mojaPozycjaY - pole.y,
                                wysokosc + pole.height, pole.energy, pole.obstacle);
                        }
                        break;
                    case -1:
                        ZnanaMapa.uaktualnijPole(mojaPozycjaX - pole.y, mojaPozycjaY
                            + pole.x, wysokosc + pole.height, pole.energy, pole.obstacle);
                        break;
                }
                #endregion
            }
        }
        #endregion
    }
}