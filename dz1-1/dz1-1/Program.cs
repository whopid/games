using System;

public class SimpleNumbers
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите целое число:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Простые числа, не превосходящие " + number + ":");
        for (int i = 2; i <= number; i++)
        {
            bool simple = true;
            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    simple = false;
                    break;
                }
            }
            if (simple)
            {
                Console.Write(i + " ");
            }
        }

        Console.WriteLine();
    }
}
