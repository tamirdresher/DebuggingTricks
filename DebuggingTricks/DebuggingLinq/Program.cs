using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = @"99 little bugs in the code, 99 bugs in the code.
                         Take one down, patch it around, 127 bugs in the code.
                        (Repeat until NO MORE BUGS)";

            var mostFrequentWord = text
                .Split(' ', '.', ',')
                .Where(i => i != "")
                .GroupBy(i => i)
                .OrderBy(i => i.Count())
                .Last();

            Debug.Assert(mostFrequentWord.Key == "bugs");
        }
    }
}
