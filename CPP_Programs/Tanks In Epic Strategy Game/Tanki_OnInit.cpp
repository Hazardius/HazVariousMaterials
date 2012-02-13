#include "Tanki.h"

//FUNKCJA INICJALIZUJACA GRAFICZNA APLIKACJE
bool Tanki::OnInit() {     
    if(SDL_Init(SDL_INIT_EVERYTHING) < 0) {
        return false;
    }

    //USTAWIENIE TRYBU WIDEO GLOWNEGO OKNA
    if((Surf_Display = SDL_SetVideoMode(800, 600, 32, SDL_HWSURFACE | SDL_DOUBLEBUF)) == NULL) {
        return false;
    }
    
    //USTAWIENIE NAZWY OKNA
    SDL_WM_SetCaption( "Tanks In Easy Strategy Game - by Hazardius", NULL );

    //WCZYTANIE OBRAZKOW
    if((Surf_Mapa = TSurface::OnLoad("./gfx/mapa.bmp")) == NULL) {
        return false;
    }
    
    if((Surf_UpRight = TSurface::OnLoad("./gfx/pics.bmp")) == NULL) {
        return false;
    }
    
    if((Surf_Units = TSurface::OnLoad("./gfx/units.bmp")) == NULL) {
        return false;
    }
    
        //PPRZEZROCZYSTOSC ROZOWEGO!
        Uint32 colorMask = SDL_MapRGB(Surf_Units->format, 255, 0, 255);
        SDL_SetColorKey(Surf_Units, SDL_SRCCOLORKEY|SDL_RLEACCEL, colorMask);
    
    if((Surf_Side = TSurface::OnLoad("./gfx/boczek.bmp")) == NULL) {
        return false;
    }
    
    if((Surf_Gracz = TSurface::OnLoad("./gfx/gracz.bmp")) == NULL) {
        return false;
    }
    
    if((Surf_Cyfry = TSurface::OnLoad("./gfx/cyfry.bmp")) == NULL) {
        return false;
    }
    
    if((Surf_WinPic = TSurface::OnLoad("./gfx/winpic.bmp")) == NULL) {
        return false;
    }
    
    if((Surf_Titles = TSurface::OnLoad("./gfx/titles.bmp")) == NULL) {
        return false;
    }
    
    //STATYSTYKI TERENOW
    Tereny[0].setit(-2.5,5,true,true,true);      //Pustynia
    Tereny[1].setit(0,0,true,true,true);         //P³askowy¿
    Tereny[2].setit(-7.5,7.5,false,false,false); //Rzeka
    Tereny[3].setit(-2.5,2.5,true,true,false);   //Wzgórza
    Tereny[4].setit(-5.0,10.00,true,false,false);//Góry
    Budynki[0].setit(0,0,true,true,true);        //NIC
    Budynki[1].setit(0.0,-1.0,true,true,true);   //Droga
    Budynki[2].setit(-2.0,4.0,true,false,true);   //Drewniany Most
    Budynki[3].setit(-2.0,6.0,true,true,true);   //Kamienny Most
    Budynki[4].setit(-2.0,8.0,true,true,true);   //Bunkier
    Budynki[5].setit(1.0,2.5,true,true,true);   //Magazyn
    Budynki[6].setit(4.0,4.0,true,false,false);   //M³yn
    
    return true;
}
