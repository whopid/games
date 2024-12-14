using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace Labyrinth
{
    class Program
    {
        static int width = 20;
        static int height = 20;
        static char[,] labyrinth = new char[width, height]; 
        static bool[,] visited = new bool[width, height]; 
        static Random random = new Random(); 
        static Player player;
        static (int x, int y) finish;

        static void Main(string[] args) 
        {
            GenerateLabyrinth(0, 0);
            player = new Player(0, 0);
            finish = (width - 2, height - 2);

            DateTime startTime = DateTime.Now;
            TimeSpan timeLimit = TimeSpan.FromMinutes(5);

            Console.WriteLine("Ограничение по времени: 5 минут");
            Console.WriteLine("Нажмите любую клавишу, чтобы начать...");
            Console.ReadKey();

            while (true)
            {
                Console.Clear();
                PrintLabyrinth();

                if (player.X == finish.x && player.Y == finish.y)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Лабиринт пройден.");
                    break;
                }


                TimeSpan elapsedTime = DateTime.Now - startTime;
                if (elapsedTime >= timeLimit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Время вышло.");
                    break;
                }


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Оставшееся время: {timeLimit - elapsedTime:hh\\:mm\\:ss}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Управление: W, A, S, D. Выход: Q.");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q) break;

                switch (key)
                {
                    case ConsoleKey.W:
                        player.Move(0, -1, labyrinth);
                        break;
                    case ConsoleKey.S:
                        player.Move(0, 1, labyrinth);
                        break;
                    case ConsoleKey.A:
                        player.Move(-1, 0, labyrinth);
                        break;
                    case ConsoleKey.D:
                        player.Move(1, 0, labyrinth);
                        break;
                }
            }
        }

        static void GenerateLabyrinth(int startX, int startY)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    labyrinth[x, y] = '|';
                    visited[x, y] = false;
                }
            }

            Stack<(int x, int y)> stack = new Stack<(int, int)>();
            stack.Push((startX, startY));
            visited[startX, startY] = true;
            labyrinth[startX, startY] = ' ';

            while (stack.Count > 0) 
            {
                var current = stack.Pop();
                List<(int x, int y)> neighbors = GetUnvisitedNeighbors(current.x, current.y);

                if (neighbors.Count > 0)
                {
                    stack.Push(current);
                    var next = neighbors[random.Next(neighbors.Count)];

                    labyrinth[(current.x + next.x) / 2, (current.y + next.y) / 2] = ' ';


                    visited[next.x, next.y] = true;
                    labyrinth[next.x, next.y] = ' ';
                    stack.Push(next); 
                }
            }
        }

        static List<(int x, int y)> GetUnvisitedNeighbors(int x, int y)
        {   
            List<(int x, int y)> neighbors = new List<(int x, int y)>();

            
            if (x > 1 && !visited[x - 2, y]) neighbors.Add((x - 2, y)); 
            if (x < width - 2 && !visited[x + 2, y]) neighbors.Add((x + 2, y));
            if (y > 1 && !visited[x, y - 2]) neighbors.Add((x, y - 2));
            if (y < height - 2 && !visited[x, y + 2]) neighbors.Add((x, y + 2));

            return neighbors; 
        }

        static void PrintLabyrinth()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == player.X && y == player.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('C');
                    }
                    else if (x == finish.x && y == finish.y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('F');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(labyrinth[x, y]);
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor(); 
        }

    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; } 

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int deltaX, int deltaY, char[,] labyrinth) 
        {
            int newX = X + deltaX;
            int newY = Y + deltaY;

            if (newX >= 0 && newX < labyrinth.GetLength(0) && newY >= 0 && newY < labyrinth.GetLength(1) && labyrinth[newX, newY] == ' ')
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
