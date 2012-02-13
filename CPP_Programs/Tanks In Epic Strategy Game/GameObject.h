#ifndef _GAMEOBJECT_H_
    #define _GAMEOBJECT_H_

class GameObject {
    public:
           //ATRYBUTY
           int position[2]; //pozycja w formacie [0-7][0-7] na mapie
           
           //KONSTRUKTORY
           GameObject(){ };
           GameObject(int x, int y){
               position[0]=x;
               position[1]=y;
           };
           
           //METODY
           int getPos(bool);
           void setPos(int, int);
};

#endif
