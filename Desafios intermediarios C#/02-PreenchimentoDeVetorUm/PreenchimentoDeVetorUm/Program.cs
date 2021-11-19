using System;

namespace PreenchimentoDeVetorUm
{
    class Program
    {
        static void Main(string[] args)
        {
            int valorLido = int.Parse(Console.ReadLine());
            int[] n = new int[10];
            for (int i = 0; i < n.Length; i++)
            {
                n[i] = valorLido;
                Console.WriteLine("N[" + i +  "] = " + n[i]);
                valorLido = valorLido * 2;

            }
        }
    }
}
