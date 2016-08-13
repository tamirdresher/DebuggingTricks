using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGammon
{
    
    public class Checker
     {
        private Color _color;

        public Checker(Color c)
        {
            _color = c;
        }
        
        public Color Color
        {
            get { return _color; }
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
