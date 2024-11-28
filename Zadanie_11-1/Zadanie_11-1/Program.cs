using System;
using System.IO;

public class SineTableGenerator
{
    public static void GenerateSineTable(string filePath, double start, double end, double step)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("x\tsin(x)"); // Заголовок

                for (double x = start; x <= end; x += step)
                {
                    double sinX = Math.Sin(x);
                    writer.WriteLine($"{x:F1}\t{sinX:F4}"); //Форматирование вывода с точностью до одной и четырёх знаков после запятой соответственно
                }
            }
            Console.WriteLine($"Таблица синусов успешно сохранена в файл: {filePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        string filePath = "f.txt";
        double start = 0;
        double end = 1;
        double step = 0.1;

        GenerateSineTable(filePath, start, end, step);
    }
}
