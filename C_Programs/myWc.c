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
    char ch, cc, cd;
    char bufor[1];
    char str2[10];
    size_t nbytes;
    int wynik, fLines, tLines, fWords, tWords, fChars, tChars;

    fLines = 0;
    tLines = 0;
    fWords = 0;
    tWords = 0;
    fChars = 0;
    tChars = 0;
    nbytes = sizeof(bufor);
    if ( argc == 1 ) {
        while(1) {
            cd = '\0';
            cc = getchar();
            if ((cc == '\n')||(cc == '\r')) {
                tLines++;
                tWords++;
                tChars++;
            } else {
                if ((cc == ' ')||(cc == '\t')) {
                    if (!(cc = cd))
                        tWords++;
                    tChars++;
                } else {
                    if (cc == EOF)
                        break;
                    tChars++;
                }
            }
            cd = cc;
        }
        printf("\t%d\t%d\t%d\n", tLines, tWords, tChars);
    } else {
        str = "";
        for (iterator = 1; iterator < argc; iterator++) {
            wynik = open(argv[iterator], O_RDONLY);
            if (wynik == -1) {
                printf("Nie mozna otworzyc pliku: %s\n", argv[iterator]);
                return 1;
            } else {
                while(1) {
                    cd = '\0';
                    x = read(wynik, bufor, nbytes);
                    if (x == 0)
                        break;
                    cc = bufor[0];
                    if ((cc == '\n')||(cc == '\r')) {
                        fLines++;
                        fWords++;
                        fChars++;
                        tLines++;
                        tWords++;
                        tChars++;
                    } else {
                        if ((cc == ' ')||(cc == '\t')) {
                            if (!(cc = cd)) {
                                fWords++;
                                tWords++;
                            }
                            fChars++;
                            tChars++;
                        } else {
                            fChars++;
                            tChars++;
                        }
                    }
                    cd = cc;
                }
                str = append(str, '\t');
                sprintf(str2,"%d",fLines);
                x = 0;
                while (1) {
                    ch = str2[x];
                    if (ch == '\0')
                        break;
                    str = append(str, ch);
                    x++;
                }
                str = append(str, '\t');
                sprintf(str2,"%d",fWords);
                x = 0;
                while (1) {
                    ch = str2[x];
                    if (ch == '\0')
                        break;
                    str = append(str, ch);
                    x++;
                }
                str = append(str, '\t');
                sprintf(str2,"%d",fChars);
                x = 0;
                while (1) {
                    ch = str2[x];
                    if (ch == '\0')
                        break;
                    str = append(str, ch);
                    x++;
                }
                str = append(str, '\t');
                x = 0;
                while (1) {
                    ch = argv[iterator][x];
                    if (ch == '\0')
                        break;
                    str = append(str, ch);
                    x++;
                }
                str = append(str, '\n');
                fLines = 0;
                fWords = 0;
                fChars = 0;
                x = close(wynik);
                if (x == -1) {
                    printf("Nie mozna zamknac pliku: %s\n", argv[iterator]);
                    return 1;
                }
            }
        }
        printf("%s\t%d\t%d\t%d\n", str, tLines, tWords, tChars);
    }
    return 0;
}
