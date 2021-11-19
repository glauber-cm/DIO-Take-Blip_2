using System;
using System.Numerics;

namespace TrigoNoTabuleiro
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong result_final = 0;
            BigInteger result, quantidade;
            
            int cont;
            int qtdTeste = int.Parse(Console.ReadLine());
            for (int i = 0; i < qtdTeste; i++)
            {
                result = 0;
                quantidade = 12;
                cont = 0;
                int casas = int.Parse(Console.ReadLine()) - 1;
                do
                {
                    quantidade = quantidade * 2;
                    result = result + quantidade;
                    cont++;

                } while ( cont < casas);
                result = result / 12000;
                result = result / 12;
                result_final = (ulong)result;
                Console.WriteLine($"{result_final} kg");
            }
        }
    }
}
