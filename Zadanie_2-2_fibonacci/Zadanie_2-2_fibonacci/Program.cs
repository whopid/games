using System;
using System.Diagnostics;
using System.Numerics;

public class FibonacciCalculator
{
    public static BigInteger FibonacciRecursive(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        if (n <= 1) return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    public static BigInteger FibonacciIterative(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        BigInteger a = 0, b = 1;
        for (int i = 0; i < n; i++)
        {
            BigInteger temp = a;
            a = b;
            b = temp + b;
        }
        return a;
    }

    public static void Main(string[] args)
    {
        int startNumber = 1;
        int endNumber = 45; // Увеличить для более точных результатов, но с риском переполнения стека в рекурсии

        for (int i = startNumber; i <= endNumber; i++)
        {
            Stopwatch stopwatchRecursive = new Stopwatch();
            Stopwatch stopwatchIterative = new Stopwatch();

            stopwatchRecursive.Start();
            BigInteger recursiveResult = FibonacciRecursive(i);
            stopwatchRecursive.Stop();

            stopwatchIterative.Start();
            BigInteger iterativeResult = FibonacciIterative(i);
            stopwatchIterative.Stop();

            Console.WriteLine($"Число Фибоначчи {i}:");
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
