#ifndef _MOVOBJ_H_
    #define _MOVOBJ_H_

#include "GameObject.h"

class MovObject : public GameObject {
      public:
             bool state; //1-zyje/stoi  2-martwy/zniszczony
             
             MovObject(){ };
             MovObject(int x,int y):GameObject(x,y){
             state=true;
             };
             
           void setState(bool stan){
                state = stan;
           }
};

#endif
