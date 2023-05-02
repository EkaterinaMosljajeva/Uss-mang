

namespace Uss_mäng
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 13, '*');
            p1.Draw();

            Point p2 = new Point(14,15,'#');
            p2.Draw();

            Console.ReadLine();
        }
    }
}