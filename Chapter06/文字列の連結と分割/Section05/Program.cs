using System.Text;

namespace Section05 {
    internal class Program {
        static void Main(string[] args) {

            var sb = new StringBuilder();
            foreach (var word in GetWords()) {
                sb.Append(word);
            }
            Console.WriteLine(sb);


            Console.WriteLine(String.Join(",", GetWords()));


        }

        private static IEnumerable<string> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}
