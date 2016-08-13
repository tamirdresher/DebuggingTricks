using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Windows;

// ReSharper disable LocalizableElement
// ReSharper disable LoopCanBeConvertedToQuery

namespace OzCodeDemo
{
    [Export(typeof (IOzCodeDemo)), ExportMetadata("Demo", "Foresee")]
    public class ForeseeDemo : IOzCodeDemo
    {
        public void Start()
        {
            const int count = 100;
            var calculationResult = new List<double>();

            for (double value = 0; value < count; value++)
            {
                calculationResult.Add(value * value / (value - count / 10.0));
            }

            double sumTotal = 0;

           System.Diagnostics.Debugger.Break();

            foreach (var result in calculationResult)
            {
                sumTotal += result;
            }

            //Can you spot why and when the average become infinity?
            //Run to this item and single step through it.
            //Now go back (set execution point) to the for loop,
            //line: calculationResult.Add(value * value / (value - count / 10.0));
            //force value to be 10 and watch the simplify result
				App.Output.Lines.Add(string.Format("Average: {0}", sumTotal / count));
        }

    }
}