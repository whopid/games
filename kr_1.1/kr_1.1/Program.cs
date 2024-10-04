using System;

public class PalindromeChecker
{
    public static bool IsPalindrome(string text)
    {
        string cleanText = text.Replace(" ", "").ToLower();

        return cleanText == new string(cleanText.Reverse().ToArray());
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку: ");
        string text = Console.ReadLine();


        if (IsPalindrome(text))
        {
            Console.WriteLine($"'{text}' - палиндром");
        }
        else
        {
            Console.WriteLine($"'{text}' - не палиндром");
        }
    }
}
