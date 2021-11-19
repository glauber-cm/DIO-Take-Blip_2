using System;

namespace Diferenca
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, d;   //declare suas variaveis              ;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());
 
            //continue a solução
            Console.WriteLine("DIFERENCA = " + ( a * b - c * d));
            Console.ReadKey();
        }
    }
}
