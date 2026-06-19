using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };

            var books = Books.GetBooks();
            var priceaverage = books.Average(x=> x.Price);
            var pageaverage = books.Sum(x => x.Pages);
            var maxPrice = books.Max(x => x.Price);


            Console.WriteLine("平均金額" + priceaverage);
            Console.WriteLine("合計ページ" + pageaverage);
            Console.WriteLine("高価な本" + maxPrice);

            Console.WriteLine("---500円以上の本---");
            foreach(var b in books.Where(x=> x.Price >= 500)) {
                Console.WriteLine(b.Title);
            }
            
            //250ページ以上の本を上位三冊出力
            Console.WriteLine("---250ページ以上の本---");
            foreach(var book in books.Where(x=> x.Pages >= 250).Take(3) ){
                Console.WriteLine(book.Title);
            }

        }
    }
}
