using System;
using System.Diagnostics;
using System.Numerics;

public class FactorialCalculator
{
    public static BigInteger FactorialRecursive(int n)
    {
        if (n < 0) throw new ArgumentException("Аргумент должен быть неотрицательным числом.");
        if (n == 0) return 1;
        return n * FactorialRecursive(n - 1);
    }

    public static BigInteger FactorialIterative(int n)
    {
        if (n < 0) throw new ArgumentException("Аргумент должен быть неотрицательным числом.");
        BigInteger result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public static void Main(string[] args)
    {
        int startNumber = 1;
        int endNumber = 30; // Увеличить для более точных результатов, но с риском переполнения стека в рекурсии


        for (int i = startNumber; i <= endNumber; i++)
        {
            Stopwatch stopwatchRecursive = new Stopwatch();
            Stopwatch stopwatchIterative = new Stopwatch();

            stopwatchRecursive.Start();
            BigInteger recursiveResult = FactorialRecursive(i);
            stopwatchRecursive.Stop();

            stopwatchIterative.Start();
            BigInteger iterativeResult = FactorialIterative(i);
            stopwatchIterative.Stop();

            Console.WriteLine($"Факториал {i}:");
            Console.WriteLine($"- Рекурсивно: {recursiveResult} ({stopwatchRecursive.ElapsedMilliseconds} мс)");
            Console.WriteLine($"- Итеративно: {iterativeResult} ({stopwatchIterative.ElapsedMilliseconds} мс)");

            if (stopwatchRecursive.ElapsedMilliseconds > stopwatchIterative.ElapsedMilliseconds * 10) // Рекурсия в 10 раз медленнее
            {
                Console.WriteLine($"\nРекурсивный метод стал заметно медленнее итеративного начиная с числа {i}.\n");
                break;
            }
        }
    }
}

