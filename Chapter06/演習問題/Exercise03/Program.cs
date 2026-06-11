
using System.Net.NetworkInformation;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion
        }

        private static void Exercise1(string text) {
            int count = text.Count(c => c == ' ');
            Console.WriteLine(count);
        }

        private static void Exercise2(string text) {
            Console.Write("検索：");
            var serch = Console.ReadLine();
            Console.Write("置換：");
            var replacement = Console.ReadLine();
            var replaced = text.Replace(serch, replacement);
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {
            
        }

        private static void Exercise4(string text) {
            var texts = text.Split(' ');

            Console.WriteLine(texts.Length);
        }

        private static void Exercise5(string text) {
            var texts = text.Split().Where(c => c.Length <= 4);
            foreach (var item in texts) {
                Console.WriteLine(item);
            }

        }
        //アルファベットの数をカウントして表示する
        private static void Exercise6(string text) {
            var str = text.ToLower().Replace(" ","");
            //辞書を使う方法
            var alphDicCount = Enumerable.Range('a', 26).
                ToDictionary(num => ((char)num), num => 0);

            //var dict = new SortedDictionary<char, int>();
            foreach (var c in str) {
                alphDicCount[c]++;
            }
            foreach (var word in alphDicCount) {
                Console.WriteLine(word.Key + ":" + word.Value);
                
            }
            //配列を用いた集計



            //'a'から順にカウントして集計



        }
    }
}
