using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        private static int[,] Field;
        private static int TheGardener1;
        private static int TheGardener2;
        static object locker = new object();
        static void Main()
        {
            Console.WriteLine("Введите первую сторону участка: ");
            int Side1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вторую сторону участка: ");
            int Side2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Садовники приступили к работе");
            TheGardener1 = Side1;
            TheGardener2 = Side2;
            Field = new int[Side1, Side2];
            Thread TheGardenerWork1 = new Thread(Sad1);
            Thread TheGardenerWork2 = new Thread(Sad2);
            TheGardenerWork1.Start();
            TheGardenerWork2.Start();
            Console.ReadKey();
        }
        private static void Sad1()
        {
            lock (locker)
                for (int i = 0; i < TheGardener2; i++)
                {
                    for (int j = 0; j < TheGardener1; j++)
                    {
                        if (Field[i, j] == 0)
                            Field[i, j] = 1;
                        Console.Write(Field[i, j] + " ");
                        Console.WriteLine();
                        Thread.Sleep(100);
                    }
                }
        }
        private static void Sad2()
        {
            for (int i = TheGardener1 - 1; i > 0; i--)
            {
                for (int j = TheGardener2 - 1; j > 0; j--)
                {
                    if (Field[j, i] == 0)
                        Field[j, i] = 2;
                    Console.Write(Field[i, j] + " ");
                    Thread.Sleep(100);
                }
            }
        }
    }
}