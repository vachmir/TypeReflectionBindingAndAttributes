using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForAttributes
{
   public sealed class CustomAttribute:Attribute
    {
        public string? Description { get; set; }

        public CustomAttribute()
        {
            Console.WriteLine("Custom Attribute");
        }
    }
}
