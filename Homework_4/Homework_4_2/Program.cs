using System;
using System.Globalization;

namespace Homework_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк матрицы: ");
            ushort N = 0;
            while (!ushort.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("Ошибка ввода. Введите целое, неотрицательное число");
            }
            Console.WriteLine("Введите количество столбцов матрицы: ");
            ushort M = 0;
            while (!ushort.TryParse(Console.ReadLine(), out M))
            {
                Console.WriteLine("Ошибка ввода. Введите целое, неотрицательное число");
            }
            int[,] array = new int[N, M];
            Random rnd = new Random();
            Console.WriteLine("Матрица: ");
            for (int i = 0; i < N; i++)
            {
                for(int j= 0; j < M; j++)
                {
                    array[i,j] = rnd.Next(-50, 50);
                    Console.Write(array[i,j] + "\t");
                }
                Console.WriteLine();
            }
            int[] summa = new int[M];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if ((array[j, i] < 0) && (array[j, i] % 2 != 0)) summa[i] += Math.Abs(array[j, i]);
                }
            }
            Console.WriteLine("Сумма модулей отрицательных нечетных элементов столбцов: ");
            for (int i = 0; i < M; i++)
            {
                Console.Write(summa[i] + "\t");
            }
            for (int i = 0; i < N; i++)
                for (int j = i + 1; j < M; j++)
                    if (summa[i] > summa[j])
                    {
                        int temp = summa[i];
                        summa[i] = summa[j];
                        summa[j] = temp;
                        for (int k = 0; k < N; k++)
                        {
                            int temp1 = array[k, i];
                            array[k, i] = array[k, j];
                            array[k, j] = temp1;
                        }
                    }
            Console.WriteLine();
            Console.WriteLine("Отсортированная по \"характеристике\" матрица: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            int[] summa1 = new int[M];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (array[j, i] < 0) summa1[i] += 1;
                }
            }
            Console.WriteLine("Количество отрицательных элементов в столбце отсортированной матрице: ");
            for (int i = 0; i < M; i++)
            {
                Console.Write(summa1[i] + "\t");
            }
            for (int i = 0; i < M; i++)
            {
                if (summa1[i] > 0)
                {
                    summa1[i] = 0;
                    for (int j = 0; j < N; j++)
                    {
                        summa1[i] += array[j, i];
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Сумма элементов в тех столбцах, которые содержат хотя бы один отрицательный элемент: ");
            for (int i = 0; i < M; i++)
            {
                if(summa1[i]!=0)
                Console.Write(summa1[i] + "\t");
                else
                {
                    Console.Write("---" + "\t");
                }
            }

        }
    }
}
