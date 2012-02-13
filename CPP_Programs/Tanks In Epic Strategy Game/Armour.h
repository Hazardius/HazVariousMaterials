#ifndef _ARMOUR_H_
    #define _ARMOUR_H_

#include "GameUnit.h"

class Armour : public GameUnit {
      public:
             //KONSTRUKTORY
             Armour(){ };
             Armour(int x, int y, bool team):GameUnit(7.5f,7.5f,team,x,y){ };
             
             //METODY
             int numerek(){ return 1; }
             void rysuj(Tanki*);
             void poruszsie(int,int, Tanki*);
};

#endif
