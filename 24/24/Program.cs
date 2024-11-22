using System;

public class BubbleSort
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите размер массива:");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            int[] arr = new int[n];
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    arr[i] = num;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.  Попробуйте еще раз.");
                    return; //Выход из программы при ошибке ввода
                }
            }

            BubbleSortArray(arr);

            Console.WriteLine("Отсортированный массив:");
            Console.WriteLine(string.Join(" ", arr));
        }
        else
        {
            Console.WriteLine("Некорректный ввод размера массива.");
        }
    }

    public static void BubbleSortArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

