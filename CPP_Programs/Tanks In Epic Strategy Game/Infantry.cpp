#include "Tanki.h"
#include "Infantry.h"
#include "Forest.h"

void Infantry :: rysuj(Tanki* gra){
    int zlubs;
    if(team) zlubs=64; else zlubs=0;
    TSurface::OnDraw(gra->Surf_Display, gra->Surf_Units, (44+this->position[0]*64), (44+this->position[1]*64), zlubs, 64, 64, 64);
}

void Infantry :: poruszsie(int x, int y, Tanki* gra){
    if((x!=this->getPos(true))||(y!=this->getPos(false))){
        bool zwrot = gra->Tereny[gra->GLOWNA.ODzial[x][y][0]].imove;
        Forest temp;
        if(!temp.check(gra->GLOWNA.ODzial[x][y][1],0))
            zwrot = false;
        if(gra->GLOWNA.ODzial[x][y][2]!=0)
            zwrot = gra->Budynki[gra->GLOWNA.ODzial[x][y][2]].imove;
        
        int osa;
        int* UnitIter;    
        if(team){
            osa=2;
            UnitIter = &(gra->IterBlue);
        } else {
            osa=1;
            UnitIter = &(gra->IterRed);
        }
            
        if(zwrot){
            if(gra->GLOWNA.ODzial[x][y][3]!=0){ // POLE ZAJÊTE
                if(gra->GLOWNA.ODzial[x][y][3]==osa){
                    cerr<<"Pole zajete przez naszych!\n";
                    gra->Gracz = !(gra->Gracz);
                    (*UnitIter)--;
                } else {
                    cerr<<"Wróg!\n";
                    this->atak(x,y,gra);
                }
            } else {                      // POLE PUSTE
                gra->meGo(this->getPos(true),this->getPos(false));
                this->move(x,y);
                gra->meCome(x,y,osa);
            }
        }
    }
}
