#ifndef _ARTILERY_H_
    #define _ARTILERY_H_

#include "GameUnit.h"

class Artilery : public GameUnit {
      public:
             //KONSTRUKTORY
             Artilery(){ };
             Artilery(int x, int y, bool team):GameUnit(10.0f,3.0f,team,x,y){ };
             
             //METODY
             int numerek(){ return 2; }
             void rysuj(Tanki*);
             void poruszsie(int,int, Tanki*);
};

#endif
