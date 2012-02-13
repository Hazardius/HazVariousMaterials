#ifndef _BUILDING_H_
    #define _BUILDING_H_

#include "MovObject.h"
#include "Transformers.h"

class Building : public MovObject, public Transformers {
     public:
            //METODY
            void setit(float,float,bool,bool,bool);
};

#endif
