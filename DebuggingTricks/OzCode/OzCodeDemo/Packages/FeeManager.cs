using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzCodeDemo.Packages
{
    internal class FeeManager
    {
        public double? MakeUpNumber(Package package)
        {
            if (package.ID % 100 == 27)
            {
                return -200;
            }

            return null;
        }
    }

    internal class Package
    {
        public static IEnumerable<Package> GetPackages()
        {
            for (int i = 15000; i < 15100; i++)
            {
                yield return new Package(i);
            }
        }

        public Package(int id)
        {
            ID = id;
        }        

        static readonly Random _rand = new Random();

        public bool IsExpressShipment { get { return true; } }

        public int ID { get; private set; }

        public double GetDeliverySurcharge()
        {
            double result = ID % 100 != 13 ?
                    (1 + (double)_rand.Next(1, 100) / 100.0) :
                    0.0;
            return result;
        }

        public double GetNominalFee()
        {
            return 20;
        }
    }
}
