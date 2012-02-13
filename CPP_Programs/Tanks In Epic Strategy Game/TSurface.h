#ifndef _TSURFACE_H_
    #define _TSURFACE_H_

#include <SDL/SDL.h>

class TSurface {
    public:
        //KONSTRUKTORY
        TSurface();
        
        //METODY
        static SDL_Surface* OnLoad(char* File);
        static bool OnDraw(SDL_Surface* Surf_Dest, SDL_Surface* Surf_Src, int X, int Y);
        static bool OnDraw(SDL_Surface* Surf_Dest, SDL_Surface* Surf_Src, int X, int Y, int X2, int Y2, int W, int H);
};

#endif
