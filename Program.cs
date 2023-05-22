

namespace Uss_mäng
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Sisestage oma nimi: ");
            string n = Console.ReadLine();

            List<Point> poisons = new List<Point>();

            while (n.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nimi peab olema pikem kui 3 märki");
                Console.ForegroundColor = ConsoleColor.Gray;                                               
                Console.Write("Sisestage oma nimi: ");
                n = Console.ReadLine();
            }
            Player player = new Player { Name = n, Score = 0 };

            Console.Clear();

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

            FoodCreator poisonCreator = new FoodCreator(80, 25, '#');
            Console.ForegroundColor = ConsoleColor.White;
            Point poison = poisonCreator.CreateFood();
            poison.Draw();

            poisons.Add(poison);

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail()) //|| snake.IsPoisoned(poison)
                {
                    break;
                }
                else if (snake.IsPoisoned(poison))
                {
                    break;
                }
                else if (snake.Eat(food))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    food = foodCreator.CreateFood();
                    food.Draw();

                    Console.ForegroundColor = ConsoleColor.White;
                    poisonCreator = new FoodCreator(80, 25, '#');
                    poison = poisonCreator.CreateFood();
                    poison.Draw();
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

            //StreamWriter to_file = new StreamWriter("Scores.txt", true);
            //to_file.WriteLine(scores);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

    }
}