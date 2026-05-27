
using System.ComponentModel.Design;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(" --- 4.2.1 ---");
            Exercise1();
            Console.WriteLine("\n --- 4.2.2 ---");
            Exercise2();
            Console.WriteLine("\n --- 4.2.3 ---");
            Exercise3();
        }

        private static void Exercise1() {
            //if-else文を使用
            Console.Write("数値を入力");
            var num = Console.ReadLine();
            bool result = int.TryParse(num, out int number);
            if (result) {
                int nums = int.Parse(num);
                if (nums >= 500) {
                    Console.WriteLine(nums);
                } else if (nums >= 100 && nums < 500) {
                    Console.WriteLine(nums * 3);
                } else if (nums >= 0 && nums < 100) {
                    Console.WriteLine(nums * 2);
                } else {
                    Console.WriteLine(nums);
                }
            } else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }

        private static void Exercise2() {
            //switch文を使用

        }

        private static void Exercise3() {
            //switch式を使用


        }
    }
}
