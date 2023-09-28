
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_force_garbage_collection

 { 

class Person
    {
        public Person()
        {
            Console.WriteLine("Person:Create");
        }

        ~Person()
        {
            Console.WriteLine("Person:Finalize");
        }
    }

}