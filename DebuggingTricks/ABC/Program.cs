using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC
{
    class Program
    {
        private static char letter = 'A';

        static char Next()
        {
            return letter++;
        }
        static void Main(string[] args)
        {
            string theAlphabet = "the alphabet is: " + Next() + Next() + Next();
        }
    }
}
