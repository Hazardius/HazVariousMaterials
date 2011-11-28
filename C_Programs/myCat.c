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
    char bufor[1];
    size_t nbytes;
    int wynik;

    nbytes = sizeof(bufor);
    if ( argc == 1 ) {
        while(argc) {
            str = "";
            while(1) {
                cc = getchar();
                str = append(str,cc);
                if ((cc == '\n')||(cc == EOF))
                    break;
            }
            str = append(str,'\n');
            for (iterator = 0; ; iterator++) {
                ch = str[iterator];
                if (ch == EOF)
                    return 0;
                printf("%c", ch);
                if (ch == '\n') {
                    break;
                }
            }
        }
    } else {
        for (iterator = 1; iterator < argc; iterator++) {
            wynik = open(argv[iterator], O_RDONLY);
            if (wynik == -1) {
                printf("Nie mozna otworzyc pliku: %s\n", argv[iterator]);
                return 1;
            } else {
                while (1) {
                    x = read(wynik, bufor, nbytes);
                    if (x == 0)
                        break;
                    printf("%c", bufor[0]);
                }
                x = close(wynik);
                if (x == -1) {
                    printf("Nie mozna zamknac pliku: %s\n", argv[iterator]);
                    return 1;
                }
            }
        }
    }
    return 0;
}
