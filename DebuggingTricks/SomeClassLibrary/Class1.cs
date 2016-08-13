using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeClassLibrary
{
    public class SomeClass
    {
        /// <summary>
        /// Somehwere, very nested, this method will call to Console.WriteLine
        /// </summary>
        public void SomeMethod()
        {
            InnerMethod();
        }

        private void InnerMethod()
        {
            InnerInnerMethod();
        }

        private void InnerInnerMethod()
        {
            InnerInnerInnerMethod();
        }

        private void InnerInnerInnerMethod()
        {
            Console.WriteLine("Hello World");
        }
    }
}
