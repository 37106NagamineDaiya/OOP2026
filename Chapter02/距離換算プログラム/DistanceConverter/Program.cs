using System.Diagnostics.Metrics;

namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "-tom")
            {
                int start = int.Parse(args[1]);
                int end = int.Parse(args[2]);
                PrintFeetMeterList(start,end);
            }
            else if (args.Length >= 1 && args[0] == "-tof")
            {
                int start = int.Parse(args[1]);
                int end = int.Parse(args[2]);
                PrintMeterToFeetList(start, end);
            }
            else
            {
                Console.WriteLine("引数エラー");
            }
        }
        static void PrintFeetMeterList(int start, int stop)
        {
            for (int feet = start; feet <= stop; feet++)
            {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.000}m");
            }
        }
        static void PrintMeterToFeetList(int start, int stop)
        {
            for (int meter = start; meter <= stop; meter++)
            {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.000}ft");
            }
        }
        static double FeetToMeter(int feet)
        {
            return feet * 0.3048;
        }
        static double MeterToFeet(int meter)
        {
            return meter / 0.3048;
        }
    }
}
