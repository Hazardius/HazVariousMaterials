#include "Building.h"

void Building :: setit(float atc,float def,bool im,bool tm,bool am){
     setState(true);
     setPos(0,0);
     setBon(atc,def);
     setMov(im,tm,am);
};
