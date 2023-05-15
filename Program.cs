

namespace Uss_mäng
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);

            //int score;

            Walls walls = new Walls(80, 25);
            walls.Draw();

            //Точки
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            Console.ForegroundColor = ConsoleColor.Green;
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '¤');
            Console.ForegroundColor = ConsoleColor.Red;
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    food = foodCreator.CreateFood();
                    food.Draw();
                    //score += 1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    snake.Move();
                }
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            WriteGameOver();
            Console.ReadLine();
    }


        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("===========================", xOffset, yOffset++);
            WriteText("Mäng Läbi", xOffset + 9, yOffset++);
            yOffset++;
            WriteText("Autor: Ekaterina Mõsljajeva", xOffset, yOffset++);
            WriteText("===========================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

    }
}