using System;

namespace Homework_4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размер массива: ");
            ushort N = 0;
            while (!ushort.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("Ошибка ввода. Введите целое, неотрицательное число: ");
            }
            double[] array = new double[N];
            Random rnd = new Random();
            Console.WriteLine("Массив: ");
            for (int i = 0; i < N; i++)
            {
                array[i] = Math.Round(rnd.Next(-500, 500) * 0.1, 3);
                Console.WriteLine(array[i]);
            }
            double min = 50;
            int min_index = 0;
            for (int i = 0; i < N; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    min_index = i;
                }
            }
            Console.WriteLine($"Номер (начиная с нуля) минимального элемента массива: {min_index} ");

            double first_negative = 1;
            double second_negative = 1;
            int first_negative_index = 0;
            int second_negative_index = 0;
            for (int i = 0; i < N; i++)
            {
                if (first_negative > 0)
                {
                    if (array[i] < 0)
                    {
                        first_negative = array[i];
                        first_negative_index = i;
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                if (second_negative > 0 || second_negative_index == first_negative_index)
                {
                    if (array[i] < 0)
                    {
                        second_negative = array[i];
                        second_negative_index = i;
                    }
                }
            }
            double result = 0;
            if (first_negative > 0 || second_negative > 0)
            {
                Console.WriteLine("В массиве нет двух отрицательных чисел");
            }
            else
            {
                for (int i = first_negative_index + 1; i < second_negative_index; i++)
                {
                    result += array[i];
                }
                Console.WriteLine($"Сумма элементов массива, расположенных между первым и вторым отрицательными числами {result}");
            }
            double[] array2 = new double[N];
            int j = 0;
            for (int i = 0; i < N; i++)
            {
                if (Math.Abs(array[i]) <= 1)
                {
                    array2[j] = array[i];
                    j++;
                }
            }
            for (int i = 0; i < N; i++)
            {
                if (Math.Abs(array[i]) > 1)
                {
                    array2[j] = array[i];
                    j++;
                }
            }
            Console.WriteLine("Отсортированный по принципу \"сначала элементы, модуль которых не превышает 1\" массив: ");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(array2[i]);
            }
        }
    }
}
