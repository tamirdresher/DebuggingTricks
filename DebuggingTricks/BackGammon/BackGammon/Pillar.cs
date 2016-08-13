using System;


namespace BackGammon
{
    public class Pillar
    {
        private Color _dominator;
        private int _count;


        public Pillar()
        {
            _count = 0;
            _dominator = Color.Red;
        }

        public Pillar(Color c)
        {
            _count = 0;
            _dominator = c;
        }

        public Color Color
        {
            get { return Color; }
        }

        public int Count
        {
            get { return Count; }
        }

        public void Increase(Color c)
        {
            if (_count == 0)
            {
                _dominator = c;
            }
            _count++;
        }

        public void Decrease()
        {
            if (_count > 0)
            {
                _count--;
            }
        }

    }
}
