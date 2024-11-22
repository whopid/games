using System;

public class BiggestNumber
{
    public static void Main(string[] args)
    {
        int biggest = int.MinValue;
        int secondAfterBiggest = int.MinValue;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Введите число " + (i + 1) + ":");
            int number = int.Parse(Console.ReadLine());

            if (number > biggest)
            {
                secondAfterBiggest = biggest;
                biggest = number;
            }
            else if (number > secondAfterBiggest && number != biggest)
            {
                secondAfterBiggest = number;
            }
        }

        Console.WriteLine("Наибольшее число: " + biggest);
        Console.WriteLine("Второе по величине число: " + secondAfterBiggest);
    }
}
