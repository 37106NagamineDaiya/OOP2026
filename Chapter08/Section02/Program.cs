namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("C:\\Users\\infosys\\source\\repos\\OOP2026\\Chapter08\\Section02\\sample.txt");
            var we = new WordsExtractor(lines);
            foreach(var word in we.Extract()) {
                Console.WriteLine(word);
            }
        }
    }
}
