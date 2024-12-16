using System;

public class NumberValidator
{
    public void ValidateInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Ничего не введено.");
        }

        if (!int.TryParse(input, out int result))
        {
            throw new FormatException("Неккоректное значение.");
        }

        if (result < int.MinValue)
        {
            throw new ArgumentOutOfRangeException("Введено слишком маленькое число.");
        }

        if (result > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException("Введено слишком больше число.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var validator = new NumberValidator();

        Console.WriteLine("Введите число:");

        string input = Console.ReadLine();

        try
        {
            validator.ValidateInput(input);
            Console.WriteLine("Ввод корректен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
