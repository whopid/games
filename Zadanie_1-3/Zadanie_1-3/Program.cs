using System;

public class QuadraticEquationSolver
{
    public static Tuple<int, double[], string> Solve(double a, double b, double c)
    {
        string message = "";

        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    return Tuple.Create(100, new double[0], "Бесконечно много решений");
                }
                else
                {
                    return Tuple.Create(0, new double[0], "Нет решений");
                }
            }
            else
            {
                double x = -c / b;
                return Tuple.Create(1, new double[] { x }, "");
            }
        }
        else
        {
            double discriminant = b * b - 4 * a * c;
            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return Tuple.Create(2, new double[] { x1, x2 }, "");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                return Tuple.Create(1, new double[] { x }, "");
            }
            else
            {
                return Tuple.Create(0, new double[0], "");
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите коэффициенты квадратного уравнения ax^2 + bx + c = 0:");

        Console.Write("a = ");
        double a;
        while (!double.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Некорректный ввод. Введите число для коэффициента a:");
            Console.Write("a = ");
        }

        Console.Write("b = ");
        double b;
        while (!double.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("Некорректный ввод. Введите число для коэффициента b:");
            Console.Write("b = ");
        }

        Console.Write("c = ");
        double c;
        while (!double.TryParse(Console.ReadLine(), out c))
        {
            Console.WriteLine("Некорректный ввод. Введите число для коэффициента c:");
            Console.Write("c = ");
        }

        var result = Solve(a, b, c);
        PrintResult(result);
    }

    static void PrintResult(Tuple<int, double[], string> result)
    {
        int numSolutions = result.Item1;
        double[] solutions = result.Item2;
        string message = result.Item3;

        if (numSolutions == 100)
        {
            Console.WriteLine(message);
            return;
        }
        if (numSolutions == 0)
        {
            Console.WriteLine("Нет решений");
            return;
        }

        Console.WriteLine($"Количество решений: {numSolutions}");
        if (numSolutions > 0)
        {
            Console.WriteLine("Решения:");
            foreach (double sol in solutions)
            {
                Console.WriteLine(sol);
            }
        }
        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine(message);
        }
    }
}

