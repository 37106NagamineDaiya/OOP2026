

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);

        }

        private static void Exercise1(List<string> langs) {
            Console.WriteLine("foreach文");

            var names = langs.FindAll(s => s.Contains('S'));
            foreach (var s in names) {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nfor文");
            names = langs.FindAll(s => s.Contains('S'));
            for(var i = 0; i < names.Count; i++) {
                Console.WriteLine(names[i]);
            }




            Console.WriteLine("\nwhile文");
            names = langs.FindAll(s => s.Contains('S'));
            var j = 0;
            while (j < names.Count) {
                Console.WriteLine(names[j]);
                j++;

            }


        }

        private static void Exercise2(List<string> langs) {
            IEnumerable<string> names = langs.Where(s => s.Contains('S')).ToList();
            foreach(var s in names) {
                Console.WriteLine(s);
            }
            
        }

        private static void Exercise3(List<string> langs) {
            var lang = langs.Find(s => s.Length == 10);
            if (lang == null) {
                lang = "unknown";
            }
            Console.WriteLine(lang);
        }
    }
}
