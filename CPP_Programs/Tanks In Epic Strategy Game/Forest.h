#ifndef _FOREST_H_
    #define _FOREST_H_

#include "StaticObj.h"
#include "Transformers.h"

class Forest : public StaticObject, public Transformers {
     public:
            //KONSTRUKTORY
            Forest();
            
            //METODY
            bool check(bool,int);
};

#endif
