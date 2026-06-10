namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var strNum = Console.ReadLine();
            if(int.TryParse(strNum, out var Num)) {
                var strNum2 = $"{Num:#,0}";
                Console.WriteLine(strNum2);
            } else {
                Console.WriteLine("整数文字列じゃないです");
            }

        }
    }
}
