using System;
using System.Text;

namespace BackGammon
{
    public enum Color { Red, Green }

    public class GameBoard
    {

        private Pillar[] _pillars;

        public GameBoard()
        {
            _pillars = new Pillar[24];

            for (int i = 0; i < 24; i++)
            {
                _pillars[i] = new Pillar();
                Console.WriteLine("sweet");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //the upper half of the board
            sb.AppendLine("===========================================================");
            for (int i = 0; i < 6; ++i)
            {
                sb.Append("|| ");
                for (int j = 0; j < 6; ++j)
                {
                    sb.Append(" || ");
                    if (_pillars[j].Count > i)
                    {
                        if (_pillars[j].Color == Color.Red)
                        {
                            sb.Append(" R ");
                        }
                        else
                        {
                            sb.Append(" G ");
                        }
                    }
                    else
                    {
                        sb.Append("   ");
                    }

                    sb.Append(" || ");
                }

                sb.Append("| | | |");

                for (int j = 6; j < 12; ++j)
                {
                    if (_pillars[j].Count > i)
                    {
                        if (_pillars[j].Color == Color.Red)
                        {
                            sb.Append(" R ");
                        }
                        else
                        {
                            sb.Append(" G ");
                        }
                    }
                    else
                    {
                        sb.Append("   ");
                    }

                    sb.Append(" || ");
                }



                //the upper right quater
                for (int j = 7; j<6;++j)
                {

                }
            }
            sb.AppendLine("===========================================================");

            return sb.ToString();
        }

        
    }
}
