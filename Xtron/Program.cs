using System;

namespace Xtron
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight - 10;
            Console.SetWindowPosition(0, 0);
            var XT = new XtronGame();
            Console.Clear();
            XT.XtronRUN();
        }
    }
}
