using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClassLibraryForAttributes;

namespace TypeReflection
{
    class Program
    {
        //Assembly assembly = null;
       // string assemblyName = "";


        static void Main(string[] args)
        {            
            string assemblyName = "";
            Assembly assembly = null;
            
            Car c =new Car();    
            Type type = typeof(Car);
            Console.WriteLine($"typeof:  {type}");
            Type tipe = c.GetType();
            Console.WriteLine($"GetType: {tipe}");


            Vehicle vehicle = new Car();
            Console.WriteLine($"GetType of vehicle {vehicle.GetType()}");
            Console.WriteLine($"typeof Vehicle     {typeof(Vehicle)}");


            Type type1 = Type.GetType("TypeReflection.Car");
            Console.WriteLine(type1);

            ListFields(type);
            ListMethodsLINQ(type);
            ListProperties(type);
            ListInterfacs(type);
            ListVariousStats(type);

            List<Car> cars= new List<Car>();
            Type type2 = cars.GetType();
            Console.WriteLine(type2);


            //Dynamically Loading Exernal Assemblies on-demend
            //do
            //{
            //    Console.WriteLine("Enter an Assembly name or \"Exit\" to exit");
            //    assemblyName = Console.ReadLine();
            //    if (assemblyName.Equals("Exit", StringComparison.OrdinalIgnoreCase))
            //    {
            //        break;
            //    }

            //    try
            //    {
            //        assembly = Assembly.LoadFrom(assemblyName);
            //        DisplayTypesInAsm(assembly);
            //    }
            //    catch 
            //    {
            //        Console.WriteLine("Sorry, can not find an asembly");                    
            //    }

            //} while (true);
            

            Console.WriteLine("Value of Custom Attribute");
            ReflectOnAttributesUsingEarlyBinding();

            //late binding is a technique in which you can create an instance of a given type and invoke its members at runtime without having hard - coded compile - time knowledge of its existence
            Console.WriteLine("Value of Custom Attribute");
            ReflectAttributesUsingLateBinding();

        }

        //Reflection - the process of runtime type discovery
        static void ListMethods(Type t)
        {
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                Console.WriteLine(m.Name);
            }
        }

        static void ListMethodsLINQ(Type t)
        {
            var methodNames = from n in t.GetMethods() select n.Name;
            foreach (var name in methodNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

        }

        static void ListFields(Type t)
        {
            var fieldNames = from f in t.GetFields() select f.Name;
            foreach (var name in fieldNames)
            {
                Console.WriteLine(name);
            }
        }

        static void ListProperties(Type t)
        {
            var propertyNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propertyNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

        }

        static void ListInterfacs(Type t)
        {
            var interfaceNames = from i in t.GetInterfaces() select i.Name;
            foreach (var name in interfaceNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

        }

        static void ListVariousStats(Type t)
        {            
            Console.WriteLine($"Base class is: { t.BaseType}");
            Console.WriteLine($"Is type abstract? {t.IsAbstract}");
            Console.WriteLine($"Is type sealed? {t.IsSealed}");
            Console.WriteLine($"Is type generic? {t.IsGenericTypeDefinition}");
            Console.WriteLine($"Is type a class type? {t.IsClass}");            
        }

        static void DisplayTypesInAsm(Assembly assembly)
        {
            Type[] assemblyTypes = assembly.GetTypes();
            foreach (Type type in assemblyTypes)
            {
                Console.WriteLine($"Type is: {type}");
            }
        }

        

        //Reflection with early binding
        static void ReflectOnAttributesUsingEarlyBinding()
        {
            // Get a Type representing the Winnebago.
            Type t = typeof(Car);
            // Get all attributes on the Winnebago.
            object[] customAtts = t.GetCustomAttributes(false);
            // Print the description.
            foreach (CustomAttribute v in customAtts)
            {
                Console.WriteLine(v.Description);
            }
        }

        //Reflecting on Attributes Using Late Binding
        static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                // Load the local copy of ClassLibraryForAttributes.
                Assembly asm = Assembly.LoadFrom("ClassLibraryForAttributes");
                // Get type info of CustomAttribute.
                Type vehicleDesc = asm.GetType("ClassLibraryForAttributes.CustomAttribute");
                // Get type info of the Description property.
                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");
                // Get all types in the assembly.
                Type[] types = asm.GetTypes();
                // Iterate over each type and obtain any CustomAttributes.
                foreach (Type t in types)
                {
                    object[] objs = t.GetCustomAttributes(vehicleDesc, false);
                    // Iterate over each CustomAttribute and print the description using late binding.
                    foreach (object o in objs)
                    {
                        Console.WriteLine($"{ t.Name}, { propDesc.GetValue(o, null)}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

