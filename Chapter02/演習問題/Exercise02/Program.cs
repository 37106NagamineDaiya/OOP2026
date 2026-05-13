namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            PrintInchToMeterList(1, 10);
            PrintInchFromMeterList(1, 10);
        }

        private static void PrintInchToMeterList(int start, int end) {
            for(int inch = start; inch <= end; inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine($"{inch}″ = {meter}m");
            }
        }

        private static void PrintInchFromMeterList(int start,int end) {
            for(int meter = start; meter <= end; meter++) {
                double inch = InchConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {inch}″");
            }
        }



    }
}

