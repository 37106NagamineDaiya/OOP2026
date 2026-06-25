using System.Security.Cryptography.X509Certificates;

namespace Section01 {
    internal class Program {

        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();


        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + Z】");


            while (true) {

                //①都道府県の入力
                Console.Write("都道府県：");
                pref = Console.ReadLine();
                if (pref == null) break;


                //②県庁所在地の入力
                Console.Write("県庁所在地：");
                prefCaptalLocation = Console.ReadLine();
                if (prefCaptalLocation == null) break;
                //③県庁所在地登録処理
                prefOfficeDict.Add(pref, prefCaptalLocation);


            }
            while (true) {
                Console.WriteLine("*****メニュー*****");
                Console.WriteLine("1:一覧表示");
                Console.WriteLine("2:検索");
                Console.WriteLine("9:終了");

                var num = Console.ReadLine();
                if (int.TryParse(num, out var number)) {
                    if (number == 1) {
                        foreach (var item in prefOfficeDict) {
                            Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
                        }
                    } else if (number == 2) {
                        Console.Write("都道府県：");
                        var checkPref = Console.ReadLine();
                        foreach (var item in prefOfficeDict) {
                            if (item.Key == checkPref) {
                                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
                                break;
                            }
                        }
                    } else if (number == 9) {
                        break;
                    }
                } else {
                    Console.WriteLine("文字もしくは無効な数字が入力されてます");
                }
            }


        }



    }

}
