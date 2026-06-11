
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
            var words = text.Split().Where(w => w.Length <= 4);
            Console.WriteLine(string.Join(",",words));

        }

        private static void Exercise6(string text) {
            
        }
    }
}
