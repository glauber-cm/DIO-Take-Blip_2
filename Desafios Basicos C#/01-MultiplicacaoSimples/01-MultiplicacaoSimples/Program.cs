﻿using System;

namespace _01_MultiplicacaoSimples
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("PROD = " + (a * b));
            Console.ReadLine();
        }
    }
}
