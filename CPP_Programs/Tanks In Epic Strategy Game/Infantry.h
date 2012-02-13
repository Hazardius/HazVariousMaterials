#ifndef _INFANTRY_H_
    #define _INFANTRY_H_

#include "GameUnit.h"

class Infantry : public GameUnit {
      public:
             void poruszsie(int,int, Tanki*);
             int numerek(){ return 0; };
             void rysuj(Tanki*);
             Infantry(){ };
             Infantry(int x, int y, bool team):GameUnit(5.0f,5.0f,team,x,y){ };
};

#endif
