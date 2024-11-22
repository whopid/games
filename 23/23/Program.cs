using System;

public class Numbers
{
    public static int AmountOfSteps(int n)
    {
        int steps = 0; 

        while (n != 1)
        {
            if (n % 2 == 0) 
            {
                n /= 2; 
            }
            else
            {
                n = 3 * n + 1; 
            }
steps++; 
        }

        return steps; 
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите число:");
int number = int.Parse(Console.ReadLine());

int steps = AmountOfSteps(number);
Console.WriteLine("Количество шагов: " + steps);
    }
}