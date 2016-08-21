using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRiddle
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new[] {true, false, true};

            Console.WriteLine("what will be the result of the next line?");

            var result = collection
                .Select(i => i == true)
                .Aggregate((i1, i2) => i1 && i2);

            Console.WriteLine("The answer is: " + result);
        }
    }
}
