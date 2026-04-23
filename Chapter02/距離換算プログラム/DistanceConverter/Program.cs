using System.Diagnostics.Metrics;

namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3 && int.TryParse(args[1], out int start) && int.TryParse(args[2], out int end))
            {
                if (args[0] == "-tom")
                {
                    PrintFeetMeterList(start, end);
                }
                else if (args[0] == "-tof")
                {
                    PrintMeterToFeetList(start, end);
                }
                else
                {
                    Console.WriteLine("引数エラー");
                }
            }
            else
            {
                Console.WriteLine("正常に変換できませんでした。");
            }
        }
        static void PrintFeetMeterList(int start, int stop)
        {
            for (int feet = start; feet <= stop; feet++)
            {
                double meter = FeetConverter.ToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.000}m");
            }
        }
        static void PrintMeterToFeetList(int start, int stop)
        {
            for (int meter = start; meter <= stop; meter++)
            {              
                double feet = FeetConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {feet:0.000}ft");
            }
        }

    }
}
