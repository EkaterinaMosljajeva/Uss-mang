

namespace Uss_mäng
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            p1.x = 1;
            p1.y = 3;
            p1.sym = '*';
            Draw(p1.x, p1.y, p1.sym);

            Point p2 = new Point();
            p2.x = 4;
            p2.y = 5;
            p2.sym = '#';
            Draw(p1.x, p1.y, p1.sym);

            Console.ReadLine();
        }
    }
}