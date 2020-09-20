using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lb1
{
    class Program
    {
        public delegate bool DelforLab(int x, int y, int z, bool res);
        public static bool Met(int x, int y, int chis, bool res)
        {
            Random rand = new Random();
            int[,] mas = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int u = 0; u < y; u++)
                {
                    mas[i, u] = rand.Next(0, 50);
                    Thread.Sleep(50);
                }
            }

            /*for (int i = 0; i < x; i++)
            {
                for (int u = 0; u < y; u++)
                {
                    Console.Write(mas[i, u] + " ");
                }
                Console.Write("\n");
            }*/

            for (int i = 0; i < x; i++)
            {
                for (int u = 0; u < y; u++)
                {
                    if (mas[i, u] == chis)
                    {
                        res = true;
                    }
                }
            }

            return res;

        }
        static void Main(string[] args)
        {


            Console.WriteLine("Введите m ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите n ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число ");
            int chislo = Convert.ToInt32(Console.ReadLine());


            /*   for (int i = 0; i < m; i++)
               {
                   for (int y = 0; y < n; y++)
                   {
                       Console.Write(mas[i, y]+" ");
                   }
                   Console.Write("\n");
               } */


            bool a = false;
            DelforLab delegat1 = Met;
            IAsyncResult ar = delegat1.BeginInvoke(m, n, chislo, a, null, null);

            while (!ar.IsCompleted)

            {
                Console.Write(".");
                Thread.Sleep(50);
            }

            bool result = delegat1.EndInvoke(ar);
            Console.WriteLine("\n");
            if (result == true)
            {
                Console.WriteLine("Элемент существует");
            }
            else
            {
                Console.WriteLine("Элемент не существует");
            }
            Console.ReadKey();

        }
    }
}


