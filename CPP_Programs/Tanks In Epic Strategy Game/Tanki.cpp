#include "Tanki.h"

using namespace std;

Tanki::Tanki() {
    Surf_Mapa = NULL;
    Surf_UpRight = NULL;
    Surf_Units = NULL;
    Surf_Side = NULL;
    Surf_Display = NULL;
    Surf_Gracz = NULL;
    Surf_Cyfry = NULL;
    Surf_WinPic = NULL;
    Surf_Titles = NULL;
    
    Wszystkie[0][0] = new Infantry(0,3,false);
    Wszystkie[0][1] = new Infantry(0,6,false);
    Wszystkie[0][2] = new Armour(1,3,false);
    Wszystkie[0][3] = new Armour(1,6,false);
    Wszystkie[0][4] = new Artilery(0,4,false);
    Wszystkie[1][0] = new Armour(6,3,true);
    Wszystkie[1][1] = new Infantry(7,3,true);
    Wszystkie[1][2] = new Infantry(7,4,true);
    Wszystkie[1][3] = new Artilery(6,2,true);
    Wszystkie[1][4] = new Artilery(6,4,true);
    
    IterRed = 0;
    IterBlue = 0;
    
    Gracz = false;
    Wygrana = false;
    Wygrany = false;
    Running = true;
}

int Tanki::MAPA::ODzial[][8][4] = { //Terrain,Forest,Building,TeamControll
                      {{1,false,0,0},{1,false,0,0},{1,false,0,0},{0,false,1,1},
                   {0,false,1,1},{0,false,1,1},{0,false,1,0},{0,false,0,0},},
                      {{1,true,0,0},{1,true,1,0},{1,false,1,0},{1,false,1,1},
                   {0,false,0,0},{0,false,0,0},{0,false,1,1},{0,false,1,0},},
                      {{1,true,0,0},{1,true,1,0},{1,true,0,0},{1,false,1,0},
                   {1,false,0,0},{1,false,0,0},{0,false,0,0},{1,false,1,0},},
                      {{2,false,0,0},{2,false,2,0},{2,false,0,0},{2,false,3,0},
                   {1,false,6,0},{1,false,1,0},{1,false,0,0},{1,false,1,0},},
                      {{0,true,0,0},{0,true,1,0},{0,false,0,0},{0,false,1,0},
                   {2,false,0,0},{2,false,2,0},{2,false,0,0},{2,false,3,0},},
                      {{3,true,0,0},{3,false,1,0},{3,false,1,0},{3,false,1,0},
                   {3,true,1,0},{3,false,1,0},{0,false,1,0},{0,false,1,0},},
                      {{0,false,0,0},{3,false,0,0},{4,false,4,2},{4,false,1,2},
                   {4,false,4,2},{4,false,0,0},{3,false,0,0},{0,false,1,0},},
                      {{3,false,0,0},{4,false,0,0},{4,false,0,0},{4,false,1,2},
                   {4,false,5,2},{4,false,0,0},{3,false,0,0},{0,false,1,0},},
};

void Tanki::meGo(int x,int y){
     MAPA::ODzial[x][y][3]=0;
};

void Tanki::meCome(int x,int y,int team){
     MAPA::ODzial[x][y][3]=team;
     if(MAPA::ODzial[7][4][3]==1){
         Wygrany=true;
         Wygrana=true;
     }
};

int Tanki::OnExecute() {
    if(OnInit() == false) {
        return -1;
    }
    cerr<<"Inicjalizacja zakoñczona sukcesem!\n";
    
    SDL_Event Event;

    while(Running) {
        while(SDL_PollEvent(&Event)) {
            OnEvent(&Event);
        }
        OnLoop();
        OnRender();
    }
    
    OnClean();
    return 0;
}

int main(int argc, char* argv[]) {
    Tanki aplikacja;

    return aplikacja.OnExecute();
}
