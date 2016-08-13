using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeClassLibrary;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var someClass = new SomeClass();
            someClass.SomeMethod();
            Console.ReadLine();
        }
    }
}
