using System;

public class QuadraticEquation
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите коэффициент a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите коэффициент b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите коэффициент c:");
        double c = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
            {
                Console.WriteLine("Уравнение не имеет решений");
            }
            else
            {
                Console.WriteLine("Уравнение имеет одно решение:");
                Console.WriteLine("x = " + (-c / b));
            }
        }
        else
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                Console.WriteLine("Уравнение не имеет действительных решений");
            }
            else if (discriminant == 0)
            {
                Console.WriteLine("Уравнение имеет одно решение:");
                Console.WriteLine("x = " + (-b / (2 * a)));
            }
            else
            {
                Console.WriteLine("Уравнение имеет два решения:");
                Console.WriteLine("x1 = " + (-b + Math.Sqrt(discriminant)) / (2 * a));
                Console.WriteLine("x2 = " + (-b - Math.Sqrt(discriminant)) / (2 * a));
            }
        }
    }
}
