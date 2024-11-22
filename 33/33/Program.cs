using System;

public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Сложение
    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    // Умножение
    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real * b.Real - a.Imaginary * b.Imaginary,
                                 a.Real * b.Imaginary + a.Imaginary * b.Real);
    }

    // Деление
    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
    {
        double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        if (denominator == 0)
        {
            throw new DivideByZeroException("Деление на ноль");
        }
        return new ComplexNumber((a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator,
                                 (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator);
    }


    // Возведение в степень (только для целых степеней)
    public ComplexNumber Power(int n)
    {
        if (n == 0) return new ComplexNumber(1, 0);
        ComplexNumber result = this;
        for (int i = 1; i < n; i++)
        {
            result *= this;
        }
        return result;
    }

    // Извлечение квадратного корня (основное значение)
    public ComplexNumber Sqrt()
    {
        double r = Module();
        double phi = Argument();
        double real = Math.Sqrt(r) * Math.Cos(phi / 2);
        double imag = Math.Sqrt(r) * Math.Sin(phi / 2);
        return new ComplexNumber(real, imag);

    }

    // Модуль
    public double Module()
    {
        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    // Аргумент (угол)
    public double Argument()
    {
        return Math.Atan2(Imaginary, Real);
    }

    public override string ToString()
    {
        return $"({Real}{(Imaginary >= 0 ? "+" : "")}{Imaginary}i)";
    }
}


public class Example
{
    public static void Main(string[] args)
    {
        ComplexNumber z1 = new ComplexNumber(2, 3);
        ComplexNumber z2 = new ComplexNumber(1, -1);

        Console.WriteLine($"z1 = {z1}");
        Console.WriteLine($"z2 = {z2}");

        Console.WriteLine($"z1 + z2 = {z1 + z2}");
        Console.WriteLine($"z1 * z2 = {z1 * z2}");
        Console.WriteLine($"z1 / z2 = {z1 / z2}");
        Console.WriteLine($"z1^2 = {z1.Power(2)}");
        Console.WriteLine($"sqrt(z1) = {z1.Sqrt()}");
        Console.WriteLine($"|z1| = {z1.Module()}");
        Console.WriteLine($"arg(z1) = {z1.Argument()}");

    }
}
