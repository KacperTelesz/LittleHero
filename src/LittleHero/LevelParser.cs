using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LittleHero
{
    class LevelParser
    {
        public static string[,] ParseFileToArray(string filePath)
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, filePath);
            string[] lines = File.ReadAllLines(fullPath);
            string firstline = lines[0];
            int rows = lines.Length;
            int cols = firstline.Length;
            string[,] grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < cols; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }
            return grid;
        }
    }
}
