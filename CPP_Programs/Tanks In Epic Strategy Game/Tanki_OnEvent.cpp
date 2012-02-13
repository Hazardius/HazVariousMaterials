#include "Tanki.h"
#include "GameUnit.h"

void Tanki::OnEvent(SDL_Event* Event) {
    CEvent::OnEvent(Event);
}

void Tanki::OnLButtonDown(int mX, int mY) {
  if(!Wygrana){
        int* UnitIter;
        int team;
        if(Gracz){
            cerr<<"Blue's turn!\n";
            UnitIter = &IterBlue;
            team=1;
        } else {
            cerr<<"Red's turn!\n";
            UnitIter = &IterRed;
            team=0;
        }
        if((mX>=44)&&(mX<556)&&(mY>=44)&&(mY<556)){
            cerr<<"z "<<Wszystkie[team][*UnitIter]->getPos(true)<<" "<<Wszystkie[team][*UnitIter]->getPos(false)<<endl;
            cerr<<"zdrowie - "<<(*Wszystkie[team][*UnitIter]).health<<endl;
            int ux = Wszystkie[team][*UnitIter]->getPos(true);
            int uy = Wszystkie[team][*UnitIter]->getPos(false);
            if((mX>=(-20+ux*64))&&(mX<(172+ux*64))&&
               (mY>=(-20+uy*64))&&(mY<(172+uy*64))){
                int x=((mX-44)/64);
                int y=((mY-44)/64);
                cerr<<"do "<<x<<" "<<y<<endl;
                Wszystkie[team][*UnitIter]->poruszsie(x,y,this);
                Gracz = !Gracz;
            } else {
                (*UnitIter)--;
            }
            
            int start = (*UnitIter+1)%5;
            bool zyje;
            int i;
            for(i=0;i<5;i++){
                if(Wszystkie[team][start]->state){
                    *UnitIter=start;
                    break;
                } else {
                    start=((start+1)%5);
                }
            }
            if(i==5)
            {
                Wygrana = true;
                if(Gracz){
                    cerr<<"Wygral RED!\n";
                    Wygrany = true;
                } else {
                    cerr<<"Wygral BLUE!\n";
                    Wygrany = false;
                }
            }
        }
  } else {
    cerr<<"Wygra³ gracz "<<Wygrany<<endl;
    OnExit();
  }
}

void Tanki::OnExit() {
    Running = false;
}
