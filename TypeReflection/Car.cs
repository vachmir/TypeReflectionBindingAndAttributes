using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryForAttributes;

namespace TypeReflection
{
    //[ObsoleteAttribute("Use another")]
    [CustomAttribute]
    class Car : Vehicle, ISomething
    {
        int a, b;
        bool bl = true;
        float f = 15.8f;
        double d = 5.8;

        public int Property1 { get; set; }
        public string? Property2 { get; set; }
        public void Types()
        {
            Type type = typeof(string);    
            Console.WriteLine(type);
        }

        public void Types(int a) 
        {

        }
        public virtual void TypePrinter() { }
    }
}
