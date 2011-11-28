#include <stdio.h>
#include <fcntl.h>


char *append(const char *oldstring, const char c)
{
    int result;
    char *newstring;
    result = asprintf(&newstring, "%s%c", oldstring, c);
    if (result == -1) newstring = NULL;
    return newstring;
}

int main( int argc, char *argv[] ) {
    int iterator, x;
    char *str;
    char ch, cc;
    char bufor[18];
    size_t nbytes;
    int wynik, it2;

    nbytes = sizeof(bufor);
    printf("%d", nbytes);
    if ( argc == 1 ) {
        printf("Nie podano nazwy pliku!");
        return 1;
    } else {
        wynik = open(argv[1], O_RDONLY);
        if (wynik == -1) {
            printf("Nie mozna otworzyc pliku: %s\n", argv[iterator]);
            return 1;
        } else {
            iterator = 0;
            while (1) {
                if (iterator%18 == 0) {
                    printf("\n");
                    x = read(wynik, bufor, nbytes);
                    if (x == 0)
                        break;
                }
                for (it2=0; it2<6; it2++){
                    str = "";
                    str = append(str, bufor[it2*3]);
                    str = append(str, bufor[it2*3+1]);
                    str = append(str, bufor[it2*3+2]);
                    printf("%o", str);
                    printf(" ");
                    iterator++;
                }
            }
            printf("\n");
            x = close(wynik);
            if (x == -1) {
                printf("Nie mozna zamknac pliku: %s\n", argv[iterator]);
                return 1;
            }
        }
    }
    return 0;
}
