
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
                if (number >= 500) {
                    Console.WriteLine(number);
                } else if (number >= 100) {
                    Console.WriteLine(number * 3);
                } else if (number >= 0) {
                    Console.WriteLine(number * 2);
                } else {
                    Console.WriteLine(number);
                }
            } else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }

        private static void Exercise2() {
            //switch文を使用
            Console.Write("数値を入力");
            var num = Console.ReadLine();
            if (!int.TryParse(num, out int number)) {
                Console.WriteLine("入力に誤りがあります");
            }

            switch (number) {
                case >= 500:
                    Console.WriteLine(number);
                    break;
                case >= 100:
                    Console.WriteLine(number * 3);
                    break;
                case >= 0:
                    Console.WriteLine(number * 2);
                    break;
                default:
                    Console.WriteLine(number);
                    break;
            }
        }

        private static void Exercise3() {
            //switch式を使用
            Console.Write("数値を入力");
            var num = Console.ReadLine();
            if (!int.TryParse(num, out int number)) {
                Console.WriteLine("入力に誤りがあります");
            }
            var num1 = number switch {
                >= 500 => number,
                >= 100 => number * 3,
                >= 0 => number * 2,
                _ => number
            };
            Console.WriteLine(num1);
        }
    }
}