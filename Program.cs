namespace Uss_mäng
{
    class Program
    {
        static ConsoleColor snakeColor = ConsoleColor.Green;
        static void Main(string[] args)
        {
            snakeColor=Menu();

            Console.Write("Sisestage oma nimi: ");
            string n = Console.ReadLine();

            List<Point> poisons = new List<Point>();

            Sound gameOverSound = new Sound("../../../sdoh.mp3");
            Sound BGSound = new Sound("../../../fon.mp3");
            BGSound.SetVolume(0.2f);
            BGSound.Play();

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

            Walls walls = new Walls(80, 25);
            walls.Draw();

            int speed = 100;


            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            Console.ForegroundColor = snakeColor;
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
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    using (StreamWriter writer = new StreamWriter("../../../Scores.txt", true))
                    {
                        writer.WriteLine(player.Name + ": " + player.Score);
                    }
                    break;
                }
                else if (snake.IsPoisoned(poison))
                {
                    break;
                }
                else if (snake.Eat(food))
                {
                    Sound nyam = new Sound("../../../nyam.mp3");
                    nyam.Play();

                    Console.ForegroundColor = ConsoleColor.Red;
                    food = foodCreator.CreateFood();
                    food.Draw();

                    Console.ForegroundColor = ConsoleColor.White;
                    poisonCreator = new FoodCreator(80, 25, '#');
                    poison = poisonCreator.CreateFood();
                    poison.Draw();

                    player.Score++;

                    speed = Speed(player.Score, speed);
                }
                else
                {
                    Console.ForegroundColor = snakeColor;
                    snake.Move();
                }
                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            BGSound.Stop();
            gameOverSound.Play();
            gameOverSound.SetVolume(0.2f);
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

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        static ConsoleColor Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.WriteLine("----------\n1 - Mäng\n2 - Parimad mängijad\n3 - Madu värvus (GREEN standard)\n----------");
                int v = int.Parse(Console.ReadLine());
                if (v == 1)
                {
                    break;
                }
                else if (v == 2)
                {
                    string[] lines = File.ReadAllLines("../../../Scores.txt");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else if (v == 3)
                {
                    snakeColor = ChooseSnakeColor();
                }
            }
            return snakeColor;
        }

        public static ConsoleColor ChooseSnakeColor()
        {
            Console.WriteLine("Valige madu värvus:\n1 - Lilla:\n2 - Kollane:\n3 - Punane:\n4 - Sinine:\n5 - Roheline");

            int varv = int.Parse(Console.ReadLine());
            ConsoleColor snakeColor;

            switch (varv)
            {
                case 1:
                    snakeColor = ConsoleColor.Magenta;
                    break;
                case 2:
                    snakeColor = ConsoleColor.Yellow;
                    break;
                case 3:
                    snakeColor = ConsoleColor.Red;
                    break;
                case 4:
                    snakeColor = ConsoleColor.Blue;
                    break;
                case 5:
                    snakeColor = ConsoleColor.Green;
                    break;
                default:
                    snakeColor = ConsoleColor.Green;
                    break;
            }

            return snakeColor;
        }

        public static int Speed(int score, int speed)
        {
            if (score == 5)
            {
                speed -= 15;
            }
            else if (score == 10)
            {
                speed -= 15;
            }
            else if (score == 15)
            {
                speed -= 15;
            }
            else if (score == 20)
            {
                speed -= 15;
            }
            return speed;
        }
    }
}