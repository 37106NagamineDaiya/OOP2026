using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    public class FeetConverter
    {
        public static readonly double raito = 0.3048;
        public static double FromMeter(double meter)
        {
            return meter / raito;
        }
        public static double ToMeter(double feet)
        {
            return feet * raito;
        }

    }
}
