#include <cstdlib>
#include <iostream>
#include <fstream.h>
#include <conio.h>

using namespace std;

void IN_podz(char*, char*, char*, char*, char*, char*, char*, char*, char*);
void RTF_printer(char*, char*, char*, char*, char*, char*, char*, char*, char*, char*);
void PS_printer(char*, char*, char*, char*, char*, char*, char*, char*, char*, char*);
void XML_printer(char*, char*, char*, char*, char*, char*, char*, char*, char*, char*);
void XSLT_printer();

int main(int argc, char *argv[])
{
    char firma[41],imie[41],stano[21],www[31],email[31],telefon[21], miasto[31], ulica[31], nip[14];
    IN_podz(firma, imie, stano, www, email, telefon, miasto, ulica, nip);
    char nazwapliku[12];
    cout<<"Podaj nazwe pliku(8 znakow): ";
    cin>>nazwapliku;
    system("CLS");
    cout<<"Wybierz co chcesz drukowac.\n1-RTF\n2-PostScript\n3-XML\n\n0-Wszystkie do plikow plik.rozszerzenie\n";
    int wybor;
    cin>>wybor;
    switch(wybor){
         case 1: strcat(nazwapliku,".rtf");
                 RTF_printer(firma,imie,stano,www,email,telefon,miasto,ulica,nip, nazwapliku);
                 break;
         case 2: strcat(nazwapliku,".ps");
                 PS_printer(firma,imie,stano,www,email,telefon,miasto,ulica,nip, nazwapliku);
                 break;
         case 3: strcat(nazwapliku,".xml");
                 XML_printer(firma,imie,stano,www,email,telefon,miasto,ulica,nip, nazwapliku);
                 break;
         case 0: RTF_printer(firma,imie,stano,www,email,telefon,miasto,ulica,nip, "plik.rtf");
                 PS_printer(firma,imie,stano,www,email,telefon,miasto,ulica,nip, "plik.ps");
                 XML_printer(firma,imie,stano,www,email,telefon,miasto,ulica,nip, "plik.xml");
                 break;
         default: cout<<"Zly wybor!";
    };
    system("PAUSE");
    return EXIT_SUCCESS;
}

void IN_podz(char* jeden, char* dwa, char* trzy, char* cztery, char* piec, char* szesc, char* siedem, char* osiem, char* dziewiec)
{
     char buf[254];
     cout<<"Podaj ciag znakow! ";
     for(int c=0;c<253;c++)
             buf[c]=getch();
     int i,j[4];
     for(i=0;i<13;i++)
     {
             if(buf[240+i]!=' ')
                  j[0]=i+1;
                  dziewiec[i]=buf[240+i];
     }
     dziewiec[j[0]]='\0';
     for(i=0;i<20;i++)
     {
             if(buf[80+i]!=' ')
                  j[0]=i+1;
                  trzy[i]=buf[80+i];
             if(buf[160+i]!=' ')
                  j[1]=i+1;
                  szesc[i]=buf[160+i];
     }
     trzy[j[0]]='\0';
     szesc[j[1]]='\0';
     for(i=0;i<30;i++)
     {
             if(buf[100+i]!=' ')
                  j[0]=i+1;
                  cztery[i]=buf[100+i];
             if(buf[130+i]!=' ')
                  j[1]=i+1;
                  piec[i]=buf[130+i];
             if(buf[180+i]!=' ')
                  j[2]=i+1;
                  siedem[i]=buf[180+i];
             if(buf[210+i]!=' ')
                  j[3]=i+1;
                  osiem[i]=buf[210+i];
     }
     cztery[j[0]]='\0';
     piec[j[1]]='\0';
     siedem[j[2]]='\0';
     osiem[j[3]]='\0';
     for(i=0;i<40;i++)
     {
             if(buf[i]!=' ')
                  j[0]=i+1;
                  jeden[i]=buf[i];
             if(buf[40+i]!=' ')
                  j[1]=i+1;
                  dwa[i]=buf[40+i];
     }
     jeden[j[0]]='\0';
     dwa[j[1]]='\0';
     cout<<endl;
};

void RTF_printer(char *pole1, char *pole2, char *pole3, char *pole4, char *pole5,
                 char *pole6, char *pole7, char *pole8, char *pole9, char *nazwa)
{
    ofstream plik;
    plik.open(nazwa,ios::out);
    plik << "{\\rtf1\\deff0\n";
    plik << "\\qc \\intbl { "<<pole1<<"\\cell }\n";
    plik << "\\ql \\intbl";
    plik << "{ \\trowd\n\\irow0\\irowband0\\ltrrow\\ts15\\trgaph70\\trrh708";
    plik << "\\trleft-108\n\\clvertalc\n\\clbrdrt\\brdrs\\brdrw30\n\\clbrdrl";
    plik << "\\brdrs\\brdrw30\n\\clbrdrb\\brdrs\\brdrw15\n\\clbrdrr\\brdrs";
    plik << "\\brdrw30\n\\cellx9438\\row\n\\ltrrow\n}\n\\trowd\n\\irow1";
    plik << "\\irowband1\\lastrow\n\\ltrrow\\ts15\\trgaph70\\trrh1562";
    plik << "\\trleft-108\n\\trbrdrt\\brdrs\\brdrw30\n\\trbrdrl\\brdrs";
    plik << "\\brdrw30\n\\trbrdrb\\brdrs\\brdrw30\n\\trbrdrr\\brdrs\\brdrw30\n";
    plik << "\\trbrdrh\\brdrs\\brdrw15\n\\trbrdrv\\brdrs\\brdrw30\n\\clvertalc";
    plik << "\n\\clbrdrt\\brdrs\\brdrw15\n\\clbrdrl\\brdrs\\brdrw30\n\\clbrdrb";
    plik << "\\brdrs\\brdrw30\n\\clbrdrr\\brdrnone\n\\cltxlrtb\\clftsWidth3";
    plik << "\\clwWidth4773\\clshdrawnil\n\\cellx4665\\clvertalb\n\\clbrdrt";
    plik << "\\brdrs\\brdrw15\n\\clbrdrl\\brdrnone\n\\clbrdrb\\brdrs\\brdrw30\n";
    plik << "\\clbrdrr\\brdrs\\brdrw30\n\\cltxlrtb\\clftsWidth3\\clwWidth4773";
    plik << "\\clshdrawnil\n\\cellx9438\n";
    plik << "\\pard \\ql \\intbl { \\tab "<<pole2<<" \\par "<<pole3<<" \\par ";
    plik << "\\par "<<pole4<<" \\par "<<pole5<<" \\par "<<pole6<<" \\cell }\n";
    plik << "\\pard \\qr \\intbl { "<<pole7<<" \\par "<<pole8<<" \\par ";
    plik << pole9<<" \\cell }\n";
    plik << "{\\ltrch\\fcs0\n\\insrsid1782760\n\\trowd\n\\irow1\\irowband1";
    plik << "\\lastrow\n\\ltrrow\\ts15\\trgaph70\\trrh1562\\trleft-108\n";
    plik << "\\trbrdrt\\brdrs\\brdrw30\n\\trbrdrl\\brdrs\\brdrw30\n\\trbrdrb";
    plik << "\\brdrs\\brdrw30\n\\trbrdrr\\brdrs\\brdrw30\n\\trbrdrh\\brdrs";
    plik << "\\brdrw15\n\\trbrdrv\\brdrs\\brdrw30\n\\clvertalc\n\\clbrdrt";
    plik << "\\brdrs\\brdrw15\n\\clbrdrl\\brdrs\\brdrw30\n\\clbrdrb\\brdrs";
    plik << "\\brdrw30\n\\clbrdrr\\brdrnone\n\\cltxlrtb\\clftsWidth3";
    plik << "\\clwWidth4773\\clshdrawnil\n\\cellx4665\\clvertalb\\clbrdrt";
    plik << "\\brdrs\\brdrw15\n\\clbrdrl\\brdrnone\n\\clbrdrb\\brdrs\\brdrw30\n";
    plik << "\\clbrdrr\\brdrs\\brdrw30\n\\cltxlrtb\\clftsWidth3\\clwWidth4773";
    plik << "\\clshdrawnil\n\\cellx9438\\row\n}\n";
    plik << "}\n";
    plik.close();
    cout<<"Drukowanie do pliku "<<nazwa<<" zakonczone.\n";
}

void PS_printer(char *pole1, char *pole2, char *pole3, char *pole4, char *pole5,
                 char *pole6, char *pole7, char *pole8, char *pole9, char *nazwa)
{
    ofstream plik;
    plik.open(nazwa,ios::out);
    plik << "\%!PS-Adobe-3.0\n";
    plik << "100 500 moveto\n400 0 rlineto\n0 300 rlineto\n-400 0 rlineto\n";
    plik << "closepath\ngsave\ngrestore\n5 setlinewidth\nstroke\n";          //Rysowanie prostokata
    plik << "110 725 moveto\n380 0 rlineto\nclosepath\ngsave\ngrestore\n3 setlinewidth\nstroke\n";
    plik << "/Times-Roman findfont\n16 scalefont\nsetfont\n";
    plik << 300-(((strlen(pole1)+2)*8)/2)<<" 770 moveto\n("<<pole1<<") show\n";
    plik << "130 700 moveto\n("<<pole2<<") show\n";
    plik << "110 670 moveto\n("<<pole3<<") show\n";
    plik << "110 610 moveto\n("<<pole4<<") show\n";
    plik << "110 580 moveto\n("<<pole5<<") show\n";
    plik << "110 550 moveto\n("<<pole6<<") show\n";
    plik << 500-((strlen(pole7)+2)*8)<<" 610 moveto\n("<<pole7<<") show\n";
    plik << 500-(strlen(pole8)*8)<<" 580 moveto\n("<<pole8<<") show\n";
    plik << 500-((strlen(pole9)+2)*8)<<" 550 moveto\n("<<pole9<<") show\n";
    plik << "showpage\n";
    plik.close();
    cout<<"Drukowanie do pliku "<<nazwa<<" zakonczone.\n";
}

void XSLT_printer()
{
     ofstream plik;
     plik.open("scheme.xsl",ios::out);
     plik << "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\n";
     plik << "<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">\n";
     plik << "<xsl:template match=\"/\">\n<html>\n<body>\n<center>\n";
     plik << "<table border=\"1\" width=\"50\%\" cellspacing=\"0\" cellpadding=\"20\" rules=\"rows\">\n";
     plik << "<xsl:for-each select=\"root/osoba\">\n<tr>\n";
     plik << "<td colspan=\"2\"><center><xsl:value-of select=\"firma\"/></center></td>\n";
     plik << "</tr>\n</xsl:for-each>\n<xsl:for-each select=\"root/osoba\">\n";
     plik << "<tr>\n<td align=\"left\" width=\"50\%\" valign=\"bottom\"><xsl:value-of select=\"imie\"/> <br/>\n";
     plik << "<xsl:value-of select=\"stanowisko\"/> <br/>\n<br/>\n<xsl:value-of select=\"www\"/> <br/>\n";
     plik << "<xsl:value-of select=\"mail\"/> <br/>\n<xsl:value-of select=\"telefon\"/></td>\n";
     plik << "<td align=\"right\" valign=\"bottom\" width=\"50\%\"> <xsl:value-of select=\"miasto\"/><br/>\n";
     plik << "<xsl:value-of select=\"ulica\"/><br/>\n<xsl:value-of select=\"nip\"/></td>\n";
     plik << "</tr>\n</xsl:for-each>\n</table>\n</center>\n</body>\n</html>\n";
     plik << "</xsl:template>\n</xsl:stylesheet>\n";
     plik.close();
     cout<<"Drukowanie pliku scheme.xsl zakonczone.\n";
}

void XML_printer(char *pole1, char *pole2, char *pole3, char *pole4, char *pole5,
                 char *pole6, char *pole7, char *pole8, char *pole9, char *nazwa)
{
     XSLT_printer();
     ofstream plik;
     plik.open(nazwa,ios::out);
     plik << "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
     plik << "<?xml-stylesheet type=\"text/xsl\" href=\"scheme.xsl\"?>\n";
     plik << "<root>\n<osoba>\n";
     plik << "<firma>"<<pole1<<"</firma>\n";
     plik << "<imie>"<<pole2<<"</imie>\n";
     plik << "<stanowisko>"<<pole3<<"</stanowisko>\n";
     plik << "<www>"<<pole4<<"</www>\n";
     plik << "<mail>"<<pole5<<"</mail>\n";
     plik << "<telefon>"<<pole6<<"</telefon>\n";
     plik << "<miasto>"<<pole7<<"</miasto>\n";
     plik << "<ulica>"<<pole8<<"</ulica>\n";
     plik << "<nip>"<<pole9<<"</nip>\n";
     plik << "</osoba>\n</root>\n";
     plik.close();
     cout<<"Drukowanie do pliku "<<nazwa<<" zakonczone.\n";
}
