using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using OzCodeDemo.ClassManagment;
using OzCodeDemo.ProjectManagment;
using System.IO;
using System.Reflection;

namespace OzCodeDemo
{
    
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "LINQ")]
    public class LINQDemo : IOzCodeDemo
    {
        public void Start()
        {
            DuplicateWordCounter();
        }
        
        private void DuplicateWordCounter()
        {
            Debugger.Break();          

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