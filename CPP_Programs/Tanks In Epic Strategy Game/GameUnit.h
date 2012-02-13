#ifndef _GAMEUNIT_H_
    #define _GAMEUNIT_H_

#include "MovObject.h"
class Tanki;

class GameUnit : public MovObject {
      public:
             //ATRYBUTY
             int health;          //punkty zycia [0-100]
             float attack;        //wsp. ataku   [0-10]
             float defence;       //wsp. obrony  [0-10]
             bool team;           //true-red        false-blue
             
             //KONSTRUKTORY
             GameUnit();
             GameUnit(float a,float d,bool t,int x, int y):MovObject(x,y){
                 health=100;
                 attack=a;
                 defence=d;
                 team=t;
             };
             
             //METODY
             void ramka(Tanki*);                //Rysuje ramke dla jednostki
             void move(int,int);                //Zmienia position
             void zdrowie(Tanki*);              //Rysuje liczbe HP jednostki
             void atak(int,int,Tanki*);         //Wykonuje atak na pole
           
             //METODY WIRTUALNE
             virtual int numerek()=0;           //Nr typu jednostki - czasem potrzebny
             virtual void poruszsie(int,int,Tanki*)=0;     //Porusza sie jednostka
             virtual void rysuj(Tanki*)=0;      //Rysuje jednostke na mapie
};

#endif
