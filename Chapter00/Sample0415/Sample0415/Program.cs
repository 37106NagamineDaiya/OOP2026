using System.Security.Cryptography.X509Certificates;

namespace Sample0415
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[] hairetu = new int[10];
            for (int i = 0; i < hairetu.Length; i++)
            {
                Console.Write("hairetu[" + i + "] =");
                string? inputNum = Console.ReadLine();
                int num = int.Parse(inputNum);
                hairetu[i] = num;
            }


            //for (int i = 0; i < hairetu.Length; i++)
            //{
            //    sum = hairetu[i] + sum;
            //}
            for (int i = 0; i < hairetu.Length; i++)
            {
                Console.Write("hairetu[" + i + "] : ");
                astOut(hairetu[i]);
            }

            //for (int i = 0; i < hairetu.Length; i++)
            //{
            //    Console.WriteLine("hairetu[" + i + "] = " + hairetu[i]);
            //}
            Console.WriteLine("合計:" + hairetu.Where(n=>n % 2 ==0).Sum());
        }

        static void astOut(int numm)
        {
            for (int j = 0; j < numm; j++) {
                Console.Write("*");
            }
            Console.WriteLine();         
            
        }
    }

}



