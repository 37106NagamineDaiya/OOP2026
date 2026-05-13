namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            PrintInchToMeterList(1, 10);
        }

        private static void PrintInchToMeterList(int start, int end) {
            for(int inch = start; inch <= end; inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine($"{inch}″ = {meter}m");
            }
        }



    }
}

