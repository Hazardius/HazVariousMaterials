#include "Tanki.h"
#include "GameUnit.h"
#include <math.h>

GameUnit :: GameUnit(){
    health = 100;
};

void GameUnit :: ramka(Tanki* gra){
    int zlubs;
    if(team) zlubs=64; else zlubs=0;
    TSurface::OnDraw(gra->Surf_Display, gra->Surf_Units, (44+this->position[0]*64), (44+this->position[1]*64), zlubs, 192, 64, 64);
};

void GameUnit :: move(int x,int y){
    setPos(x,y);
};

void GameUnit::zdrowie(Tanki* gra){
    int zdrowie = this->health;
    int jeden = (int)floor(zdrowie/100);
    int dwa = (int)floor((zdrowie-jeden*100)/10);
    int trzy = (int)floor((zdrowie-jeden*100-dwa*10));
    TSurface::OnDraw(gra->Surf_Side, gra->Surf_Cyfry, 60, 200, jeden*16, 0, 16, 20);
    TSurface::OnDraw(gra->Surf_Side, gra->Surf_Cyfry, 76, 200, dwa*16, 0, 16, 20);
    TSurface::OnDraw(gra->Surf_Side, gra->Surf_Cyfry, 92, 200, trzy*16, 0, 16, 20);
};

void GameUnit::atak(int xe,int ye, Tanki* Main){
    int xu = getPos(true);
    int yu = getPos(false);
    GameUnit* wrog=NULL;
    int check = -1;
    if(team)
        check = 0;
    else
        check = 1;
    int Iter=0;
    while(wrog==NULL){
        wrog = Main->Wszystkie[check][Iter];
        if((!(*wrog).position[0]==xe)||(!(*wrog).position[1]==ye)){
            wrog = NULL;
            Iter++;
        }
    }
    
    cerr<<"Przed atakiem:\n";
    cerr<<"AHp = "<<this->health<<"\nBHp = "<<(*wrog).health<<endl;
    
    float atsum = 0;
    float defsum = 0;
    atsum+=this->attack;
    atsum+=Main->Tereny[Main->GLOWNA.ODzial[xu][yu][0]].bonattack;
    atsum+=Main->Budynki[Main->GLOWNA.ODzial[xu][yu][2]].bonattack;
    defsum+=this->attack;
    defsum+=Main->Tereny[Main->GLOWNA.ODzial[xe][ye][0]].bondeffence;
    defsum+=Main->Budynki[Main->GLOWNA.ODzial[xe][ye][2]].bondeffence;
    float sum = atsum - defsum;
    if(sum>0){
        (*wrog).health-=(int)(sum*2.5);
        if((*wrog).health<=0) {
            (*wrog).state = false;
            Main->GLOWNA.ODzial[xe][ye][3]=0;
        }
    } else {
        this->health-=(int)(-sum*2.5);
        if(this->health<=0){
            this->state = false;
            Main->GLOWNA.ODzial[xu][yu][3]=0;
        }
    }
    cerr<<"Atakujacy = "<<atsum<<"\nBroniacy = "<<defsum<<endl;
    cerr<<"AHp = "<<this->health<<"\nBHp = "<<(*wrog).health<<endl;
    
};
