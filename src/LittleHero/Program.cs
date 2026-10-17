using System;
using System.Text;

namespace LittleHero
{
    class Program
    {
        static void Main(string[] args)
        {           
            // Make box-drawing / block characters render correctly on any Windows console code page
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Little Hero";

            Game g1 = new Game();
            g1.StartTheGame();        
        }
    }
}
