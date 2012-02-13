#ifndef _TANKI_H_
    #define _TANKI_H_

#include <SDL/SDL.h>
#include <iostream>

#include "CEvent.h"
#include "TSurface.h"
#include "Terrain.h"
#include "Forest.h"
#include "Building.h"
#include "Infantry.h"
#include "Armour.h"
#include "Artilery.h"

using namespace std;

class Tanki : public CEvent{
    private:
        bool Running, Wygrana, Wygrany;
        SDL_Surface* Surf_Mapa;
        SDL_Surface* Surf_UpRight;
        SDL_Surface* Surf_Gracz;
        SDL_Surface* Surf_WinPic;
        SDL_Surface* Surf_Titles;
    
    public:
        Tanki();
        int OnExecute();
        
        SDL_Surface* Surf_Display;
        SDL_Surface* Surf_Units;
        SDL_Surface* Surf_Side;
        SDL_Surface* Surf_Cyfry;
        bool Gracz;
        int IterRed, IterBlue;
        Terrain Tereny[5];
        Building Budynki[7];
        
        GameUnit* Wszystkie[2][5];     //KONTERER OBIEKTOW!!!
        
        class MAPA{
               public:
               static int ODzial[][8][4]; //Obszar Dzia³añ
        } GLOWNA;
    
    public:
        bool OnInit();
        void OnEvent(SDL_Event* Event);
        void OnLButtonDown(int mX, int mY);
        void OnExit(); 
        void OnLoop();
        void OnRender();
        void OnClean();
        
        void meGo(int,int);
        void meCome(int,int,int);
};

#endif
