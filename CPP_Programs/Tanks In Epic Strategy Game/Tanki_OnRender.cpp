#include "Tanki.h"
#include <iostream>

using namespace std;

void Tanki::OnRender() {
    if(!Wygrana){      //JEZELI JESZCZE NIE KONIEC
    //NARYSUJ MAPE
    TSurface::OnDraw(Surf_Display, Surf_Mapa, 44, 44);
    
    //NARUSUJ NAZWE GRY I AUTORA
    TSurface::OnDraw(Surf_Display, Surf_Titles, 44, 0, 0, 0, 512,44);
    TSurface::OnDraw(Surf_Display, Surf_Titles, 44, 556, 0, 44, 512,44);
    
    //NARYSUJ IKONE I HP AKTYWNEJ JEDNOSTKI
    if(Gracz){
        TSurface::OnDraw(Surf_Side, Surf_Gracz, 0, 150, 0, 50, 150, 50);
        TSurface::OnDraw(Surf_Display, Surf_UpRight, 600, 44, 150*((*Wszystkie[1][IterBlue]).numerek() + 1), 0, 150, 150);
        (*Wszystkie[1][IterBlue]).zdrowie(this);
    } else {
        TSurface::OnDraw(Surf_Side, Surf_Gracz, 0, 150, 0, 0, 150, 50);
        TSurface::OnDraw(Surf_Display, Surf_UpRight, 600, 44, 150*((*Wszystkie[0][IterRed]).numerek() + 1), 0, 150, 150);
        (*Wszystkie[0][IterRed]).zdrowie(this);
    }
    
    //NARYSUJ WSZYSTKIE JEDNOSTKI NA MAPIE
    for(int i=0;i<10;i++){
        if((*Wszystkie[i%2][i/2]).state){
            (*Wszystkie[i%2][i/2]).rysuj(this);
        }
    }
    
    //NARYSUJ OBWODKI AKTYWNYCH JEDNOSTEK
    (*Wszystkie[0][IterRed]).ramka(this);
    (*Wszystkie[1][IterBlue]).ramka(this);
    
    //NARYSUJ KROTKA INSTRUKCJE
    TSurface::OnDraw(Surf_Display, Surf_Side, 600, 193);
    
    } else {                       //JEZELI KONIEC - NARYSUJ EKRANY "WYGRAL RED/BLUE"
        if(Wygrany)
            TSurface::OnDraw(Surf_Display, Surf_WinPic, 0, 0, 0, 0, 800,600);
        else
            TSurface::OnDraw(Surf_Display, Surf_WinPic, 0, 0, 800, 0, 800,600);
    }

    //NIECH WSZYSTKO SIE POJAWI
    SDL_Flip(Surf_Display);
}
