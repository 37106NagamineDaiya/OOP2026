
namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            string? name = null;
            #region nullの判定
            if (name is null) {
                Console.WriteLine("nameはnullです");
            }
            #endregion


            #region nul合体演算子

            string code = "12345";
            //GetMessage()メソッドの戻り値がnullだったら、
            //DefaultMessage()メソッドが実行される
            var message = GetMessage(code) ?? DefaultMessage();
            Console.WriteLine(message);
            #endregion

            #region null合体代入演算子

            message = null;
            message ??= DefaultMessage();

            #endregion

            #region null条件演算子

            Sale? sale = new Sale {
                ShopName = "新宿店",
                ProductCategory = "洋菓子",
                Amount = 523100
            };
            //sale = null;

            int? amount = sale?.Amount;
            Console.WriteLine("売上高:" + amount);

            #endregion

            #region 2つの要素を入れ替える

            int a = 10;
            int b = 20;
            Console.Write("入れ替え前：");
            Console.WriteLine("a = " + a + ",b = " + b);
            Console.Write("入れ替え後：");

            (b, a) = (a, b);

            Console.WriteLine("a = " + a + ",b = " + b);

            #endregion


        }

        private static string? DefaultMessage() {
            return "DefaultMessage";
        }

        private static string? GetMessage(string code) {
            return null;
        }
        public class Sale {
            //店舗名
            public string ShopName { get; set; } = string.Empty;
            //商品カテゴリー
            public string ProductCategory { get; set; } = string.Empty;
            //売上高
            public int Amount { get; set; }
        }

    }
}
