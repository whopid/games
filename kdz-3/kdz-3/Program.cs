using System;

public class Game
{
    private char[,] gameField;
    private int playerY, playerX;
    private int activatedPlatesCount;

    public Game()
    {
        gameField = new char[10, 10];
        activatedPlatesCount = 0;
        InitializeField();
    }

    private void InitializeField()
    {
        // Заполнение поля символами
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                gameField[i, j] = '#'; // Трава по умолчанию
            }
        }

        // Размещение объектов
        gameField[1, 1] = 'R'; 
        gameField[2, 2] = 'T'; 
        gameField[3, 3] = 'O'; 
        gameField[4, 4] = 'O'; 
        gameField[5, 5] = 'R'; 
        gameField[6, 6] = 'O'; 
        gameField[8, 8] = 'C'; 
        playerX = 8;
        playerY = 8;
    }

    public void Run()
    {
        while (true)
        {
            Render();
            GetInput();
            CheckWinCondition();
        }
    }

    private void Render()
    {
        Console.Clear();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write(gameField[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Активированные плиты: {activatedPlatesCount}");
    }

    private void GetInput()
    {
        ConsoleKeyInfo key = Console.ReadKey();
        int newX = playerX;
        int newY = playerY;

        switch (key.Key)
        {
            case ConsoleKey.W: newY--; break;
            case ConsoleKey.S: newY++; break;
            case ConsoleKey.A: newX--; break;
            case ConsoleKey.D: newX++; break;
        }

        MovePlayer(newX, newY);
    }

    private void MovePlayer(int newX, int newY)
    {
        if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10)
        {
            char targetCell = gameField[newY, newX];

            if (targetCell == 'R')
            {
                MoveRock(newX, newY);
            }
            else if (targetCell == '#')
            {
                gameField[playerY, playerX] = '#';
                playerX = newX;
                playerY = newY;
                gameField[playerY, playerX] = 'C';
            }
            else if (targetCell == 'O')
            {
                ActivatePlate(newX, newY);
            }
            else if (targetCell == 'T')
            {
                // Ничего не делаем, если это дерево
            }
        }
    }

    private void ActivatePlate(int newX, int newY)
    {
        gameField[playerY, playerX] = '#';
        playerX = newX;
        playerY = newY;
        gameField[playerY, playerX] = 'C';
        activatedPlatesCount++;
        Console.WriteLine("Плита активирована!");
    }

    private void MoveRock(int newX, int newY)
    {
        int dx = newX - playerX;
        int dy = newY - playerY;

        int rockNewX = newX + dx;
        int rockNewY = newY + dy;

        if (rockNewX >= 0 && rockNewX < 10 && rockNewY >= 0 && rockNewY < 10)
        {
            char cellBehindRock = gameField[rockNewY, rockNewX];
            if (cellBehindRock == '#' || cellBehindRock == 'O')
            {
                if (cellBehindRock == '#')
                {
                    gameField[playerY, playerX] = '#';
                    gameField[newY, newX] = 'C';
                    gameField[rockNewY, rockNewX] = 'R';
                    playerX = newX;
                    playerY = newY;
                }
                else
                {
                    gameField[playerY, playerX] = '#';
                    gameField[newY, newX] = 'C';
                    gameField[rockNewY, rockNewX] = 'Ⓡ';
                    playerX = newX;
                    playerY = newY;
                    activatedPlatesCount++;
                    Console.WriteLine("Плита активирована!");
                }
            }
        }
    }

    private void CheckWinCondition()
    {
        if (activatedPlatesCount >= 3) // Условие выигрыша
        {
            Console.Clear();
            Console.WriteLine("Поздравляем! Вы активировали все плиты и выиграли!");
            Environment.Exit(0); // Завершение игры
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.Run();
    }
}
