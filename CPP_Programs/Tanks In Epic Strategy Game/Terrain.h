#ifndef _TERRAIN_H_
    #define _TERRAIN_H_

#include "StaticObj.h"
#include "Transformers.h"

class Terrain : public StaticObject, public Transformers {
     public:
            void setit(float,float,bool,bool,bool);
};

#endif
