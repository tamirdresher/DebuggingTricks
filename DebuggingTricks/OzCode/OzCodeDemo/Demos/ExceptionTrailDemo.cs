using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace OzCodeDemo
{
    [Export(typeof (IOzCodeDemo)), ExportMetadata("Demo", "ExceptionTrail")]
    public class ExceptionTrailDemo : IOzCodeDemo
    {
        public void Start()
        {
            DoDevideByZero();
            DoAccessViolation();
        }

        private void DoDevideByZero()
        {
            try
            {
                Do(3);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
               System.Diagnostics.Debugger.Break();
            }
        }

        private void Do(int i)
        {
            try
            {
                Trace.Write(12 / i);
                Do(i - 1);
            }
            catch (Exception ex)
            {
                throw new Exception("OzCode Rocks! #" + (i + 1), ex);
            }
        }

        struct X
        {
            public int Y;
            public Func<int, int, int> Add;
        }

        [HandleProcessCorruptedStateExceptions]
        private unsafe static void DoAccessViolation()
        {
            var x = new X { Add = (a, b) => a + b };
                
            int* p = &x.Y;
            *(p - 1) = 0x101011;

            try
            {
                Trace.WriteLine(x.Add(3, 4));
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
               System.Diagnostics.Debugger.Break();
            }
        }
    }
}