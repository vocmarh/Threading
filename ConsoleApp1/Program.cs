using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        private static int x;
        private static int y;
        private static int[,] pole;

        static void Main()
        {
            Console.WriteLine("Vvedite razmer polya:");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            pole = new int[x, y];
            ThreadStart threadStart = new ThreadStart(Sadovnik1);
            Thread thread = new Thread(threadStart);
            ThreadStart threadStart1 = new ThreadStart(Sadovnik2);
            Thread thread2 = new Thread(threadStart1);
            thread.Start();
            thread2.Start();
            thread.Join();
            thread2.Join();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(pole[i, j] + " ");

                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Sadovnik1()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (pole[i, j] == 0)
                    {
                        pole[i, j] = 1;
                        Thread.Sleep(5);
                    }

                }
                Console.WriteLine();
            }
        }
        static void Sadovnik2()
        {
            for (int j = y - 1; j > 0; j--)
            {
                for (int i = x - 1; i > 0; i--)
                {
                    if (pole[j, i] == 0)
                    {
                        pole[j, i] = 2;
                        Thread.Sleep(5);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}