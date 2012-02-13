#include "Forest.h"

Forest :: Forest(){
    bonattack = 3.0;
    bondeffence = 4.0;
    imove = true;
    tmove = false;
    amove = true;
};

bool Forest :: check(bool t,int a){
    if(t)
        switch(a){
            case 0: return imove;
            case 1: return tmove;
            case 2: return amove;
        };
    return true;
};
