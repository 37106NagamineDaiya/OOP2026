namespace Sample0413
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.Write("表示回数：");
            string?  inputNum = Console.ReadLine(); //入力

            int count = int.Parse(inputNum);
            int i = 1;
            while(i <= count){
                if (i % 2 == 0)
                {
                    Console.Write(i + ":");
                    Console.WriteLine("群馬県太田市"); //画面出力
                }
                i++;
            } 
        }
    }
}
