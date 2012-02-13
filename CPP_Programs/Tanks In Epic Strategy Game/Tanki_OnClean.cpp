#include "Tanki.h"

void Tanki::OnClean() {
    SDL_FreeSurface(Surf_Cyfry);
    SDL_FreeSurface(Surf_WinPic);
    SDL_FreeSurface(Surf_Titles);
    SDL_FreeSurface(Surf_Mapa);
    SDL_FreeSurface(Surf_Side);
    SDL_FreeSurface(Surf_Gracz);
    SDL_FreeSurface(Surf_UpRight);
    SDL_FreeSurface(Surf_Units);
    SDL_FreeSurface(Surf_Display);
    SDL_Quit();
}
