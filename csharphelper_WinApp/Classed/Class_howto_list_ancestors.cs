
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_list_ancestors

 { 

class TypeInfo
    {
        public Type TheType;

        public TypeInfo(Type the_type)
        {
            TheType = the_type;
        }

        public override string ToString()
        {
            return TheType.Name;
        }
    }

}