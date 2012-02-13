#include "GameObject.h"    

int GameObject :: getPos(bool x){
    if(x)
        return position[0];
    else
        return position[1];
};

void GameObject :: setPos(int x, int y){
    position[0]=x;
    position[1]=y;
};
