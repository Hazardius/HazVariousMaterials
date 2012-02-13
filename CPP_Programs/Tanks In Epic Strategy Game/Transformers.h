#ifndef _TRANSFORMERS_H_
    #define _TRANSFORMERS_H_

class Transformers {
    public:
           //ATRYBUTY
           float bonattack;     //bonus do ataku, moze byc ujemny!!!
           float bondeffence;   //bonus do obrony, moze byc ujemny!!!
           bool imove;          //infantry movement
           bool tmove;          //tank movement
           bool amove;          //artillery movement
           
           //METODY
           void setBon(float,float);
           void setMov(bool,bool,bool);
};

#endif
