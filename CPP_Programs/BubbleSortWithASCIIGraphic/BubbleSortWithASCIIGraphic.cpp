#include<ctime>
#include<conio.h>
#include<iostream>
#include<windows.h>

void gotoxy(int x, int y) {
    COORD coordinates;
    coordinates.X = x;
    coordinates.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coordinates);
}

int main() {

    int getOut = 0;
    while (getOut == 1) {
        //system("clear"); //Working with bash
        system("CLS"); //Working with cmd.exe

        std::cout << "How much elements do you want to sort? ";
        unsigned int quantity;
        std::cin >> quantity;
        int* table = new int[quantity];
        srand(time(NULL));
        SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
              FOREGROUND_BLUE | FOREGROUND_INTENSITY);

        for (int i = 0; i < quantity; i++) {
            table[i] = rand() % 75;
            std::cout << table[i] << " ";
        }

        std::cout << std::endl << std::endl;
        SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
              FOREGROUND_GREEN | FOREGROUND_INTENSITY);

        for (int i = 0; i < quantity; i++) {
            for (int p = 0; p < table[i]; p++)
                std::cout << "$";
            std::cout << "\n";
        }

        if (quantity <= 0)
            std::cout << "Tabela nie mo\276e mie\206 0 lub mniej miejsc.";
        else {
            int iterator = 1;
            while (iterator != 0) {
                iterator = 0;
                int temp;
                for (int i = 0; i < quantity - 1; i++) {
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
                          FOREGROUND_RED | FOREGROUND_INTENSITY);
                    gotoxy(0, i + 3);
                    if (quantity >= 28)
                        gotoxy(0, i + 4);

                    for (int w = i; w <= i + 1; w++) {
                        for (int p = 0; p < 80; p++)
                            std::cout << " ";

                        gotoxy(0, w + 3);
                        if (quantity >= 28)
                            gotoxy(0, w + 4);

                        for (int p = 0; p < table[w]; p++)
                            std::cout << "$";
                    }

                    Sleep(250);

                    if (table[i] > table[i + 1]) {
                        temp = table[i];
                        table[i] = table[i + 1];
                        table[i + 1] = temp;
                        gotoxy(0, i + 3);
                        if (quantity >= 28)
                            gotoxy(0, i + 4);

                        for (int w = i; w <= i + 1; w++) {
                            for (int p = 0; p < 80; p++)
                                std::cout << " ";

                            gotoxy(0, w + 3);
                            if (quantity >= 28)
                                gotoxy(0, w + 4);

                            for (int p = 0; p < table[w]; p++)
                                std::cout << "$";
                        }

                        Sleep(250);
                        iterator = iterator + 1;
                    }

                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
                          FOREGROUND_GREEN | FOREGROUND_INTENSITY);
                    gotoxy(0, i + 3);

                    if (quantity >= 28)
                        gotoxy(0, i + 4);

                    for (int w = i; w <= i + 1; w++) {
                        for (int p = 0; p < 80; p++)
                            std::cout << " ";

                        gotoxy(0, w + 3);
                        if (quantity >= 28)
                            gotoxy(0, w + 4);

                        for (int p = 0; p < table[w]; p++)
                            std::cout << "$";
                    }
                    Sleep(250);
                }
            }
            std::cout << std::endl;
            SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
                  FOREGROUND_BLUE | FOREGROUND_INTENSITY);
            gotoxy(0, quantity + 4);
            if (quantity >= 28)
                gotoxy(0, quantity + 5);

            for (int i = 0; i < quantity; i++)
                std::cout << " " << table[i];
        }
        std::cout << "\n\nDo you want to repeat this?\n1. Yes\n2. No\n";
        std::cin >> getOut;
    }
    getch();
    return 0;
}
