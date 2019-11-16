using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleGameSnake
{
    class Program
    {
        static readonly int x=80;
        static readonly int y = 26;
        static Walls wall;
        static Food food;
        static Snake snake;
        static Timer time;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            wall = new Walls(x, y, '#');
            food = new Food(x, y, '@');
            food.CreateFood();
            snake = new Snake(x / 2, y / 2);
            bool eat = false;
            Console.SetCursorPosition(82, 0);
            Console.Write("To start the game press something");
            Console.SetCursorPosition(82, 1);
            Console.Write("Snake game");
            Console.SetCursorPosition(82, 2);
            Console.Write("Keyboard controls :");
            Console.SetCursorPosition(82, 3);
            Console.Write("UpArrow- UP");
            Console.SetCursorPosition(82, 4);
            Console.Write("RightArrow- RIGHT");
            Console.SetCursorPosition(82, 5);
            Console.Write("DownArrow- DOWN");
            Console.SetCursorPosition(82, 6);
            Console.Write("LeftArrow- LEFT");
            Console.SetCursorPosition(82, 7);
            Console.Write("ESC- ESCAPE");

            ConsoleKeyInfo pressed;
            pressed = Console.ReadKey();
            snake.direction = Snake.Direction.RIGHT;
            time = new Timer(Loop, null, 0, 200);

            do
            {
                if (Console.KeyAvailable)
                {
                    pressed = Console.ReadKey();
                    snake.Move(pressed.Key);
                    eat = snake.CheckFood(food.position);
                    if (eat)
                    {
                        food.CreateFood();
                        eat = false;
                    }
                }
            } while (!wall.IsHit(snake.GetHead()) && !snake.IsHit(snake.GetHead()) && pressed.Key != ConsoleKey.Escape);

            Console.SetCursorPosition(82, 10);
            Console.Write("Game over");
            Console.ReadKey();

        }
        static void Loop(object obj)
        {
            if (Console.KeyAvailable)//не работает выход здесь
            {
                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.Escape) 
                {
                    time.Change(0, Timeout.Infinite);
                }
            }
            if (wall.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead())) 
            {
                time.Change(0, Timeout.Infinite);
            }
            else if (snake.CheckFood(food.position))
            {
                food.CreateFood();
            }
            else
            {
                switch (snake.direction)
                {
                    case Snake.Direction.UP:
                        snake.Move(ConsoleKey.UpArrow);
                        break;
                    case Snake.Direction.RIGHT:
                        snake.Move(ConsoleKey.RightArrow);
                        break;
                    case Snake.Direction.DOWN:
                        snake.Move(ConsoleKey.DownArrow);
                        break;
                    case Snake.Direction.LEFT:
                        snake.Move(ConsoleKey.LeftArrow);
                        break;
                }
            }
        }
    }
}
