#include <stdio.h>

int main( int argc, char *argv[] ) {
int flag_n, flag_e, myslniki, iterator, it2, niebylmyslnik, x, y;
char *flaga;

    flag_n = 0;
    flag_e = 0;
    myslniki = 1;
    for (iterator = 1; iterator < argc; iterator++) {
        niebylmyslnik = 1;
        flaga = argv[iterator];
        if ((flaga[0] == '-') && (myslniki)) {
            if (flaga[1] == 'n') {
                if (flag_n) {
                    printf("Too much -n options!\n");
                    return 1;
                }
                flag_n = 1;
                niebylmyslnik = 0;
            }
            if (flaga[1] == 'e') {
                if (flag_e) {
                    printf("Too much -e options!\n");
                    return 1;
                }
                flag_e = 1;
                niebylmyslnik = 0;
            }
        }
        if (niebylmyslnik) {
            myslniki = 0;
            printf("%s ", argv[iterator]);
        }
    }
    if (!flag_n) printf("\n");
    return 0;
}
