using System;

public class StonePusherGame
{
    private const int FIELD_SIZE = 10;
    private char[,] field;
    private int playerX, playerY;

    public StonePusherGame()
    {
        // Инициализация игрового поля (уровень)
        field = new char[FIELD_SIZE, FIELD_SIZE]
        {
            {'#','#','#','#','#','#','#','#','#','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ','R',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ','T',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ','O',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ','R','#'},
            {'#',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#','#','#','#','#','#','#','#','#','#'}
        };
        playerX = 1;
        playerY = 1;
        field[playerY, playerX] = 'C';
    }

    public void Run()
    {
        while (true)
        {
            PrintField();
            Console.WriteLine("Введите направление (w-вверх, s-вниз, a-влево, d-вправо) или q-выйти:");
            string input = Console.ReadLine().ToLower();
            if (input == "q") break;

            int dx = 0, dy = 0;
            switch (input)
            {
                case "w": dy = -1; break;
                case "s": dy = 1; break;
                case "a": dx = -1; break;
                case "d": dx = 1; break;
                default: Console.WriteLine("Некорректный ввод."); continue;
            }

            Move(dx, dy);
            if (IsWin())
            {
                Console.WriteLine("Поздравляю! Вы победили!");
                break;
            }
        }
    }

    private void Move(int dx, int dy)
    {
        int newX = playerX + dx;
        int newY = playerY + dy;

        if (newX < 0 || newX >= FIELD_SIZE || newY < 0 || newY >= FIELD_SIZE ||
            field[newY, newX] == '#' || field[newY, newX] == 'T')
        {
            return; // Столкновение
        }

        if (field[newY, newX] == 'R') // Толкаем камень
        {
            int stoneX = newX + dx;
            int stoneY = newY + dy;
            if (stoneX < 0 || stoneX >= FIELD_SIZE || stoneY < 0 || stoneY >= FIELD_SIZE ||
                field[stoneY, stoneX] == '#' || field[stoneY, stoneX] == 'T' || field[stoneY, stoneX] == 'R')
            {
                return; // Столкновение камня
            }
            field[newY, newX] = ' ';
            field[stoneY, stoneX] = 'R';
        }
        field[playerY, playerX] = (field[playerY, playerX] == 'C') ? ' ' : 'O'; // Если плита была активирована - восстанавливаем
        playerX = newX;
        playerY = newY;
        field[playerY, playerX] = 'C';
    }

    private bool IsWin()
    {
        for (int y = 0; y < FIELD_SIZE; y++)
        {
            for (int x = 0; x < FIELD_SIZE; x++)
            {
                if (field[y, x] == 'O') return false;
            }
        }
        return true;
    }

    private void PrintField()
    {
        Console.Clear();
        for (int y = 0; y < FIELD_SIZE; y++)
        {
            for (int x = 0; x < FIELD_SIZE; x++)
            {
                Console.Write(field[y, x]);
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        StonePusherGame game = new StonePusherGame();
        game.Run();
    }
}
