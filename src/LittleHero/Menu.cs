using System;
using System.Collections.Generic;

namespace LittleHero
{
    class Menu
    {
        private int SelectedIndex;
        private List<string> Options;
        private string Prompt;

        public Menu(List<string> options, string prompt)
        {
            Options = options;
            Prompt = prompt;
            SelectedIndex = 0;
        }
        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Count; i++)
            {
                string currentOption = Options[i];
                
                if (i == SelectedIndex)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(">" + currentOption + "<");

                }
                else
                {
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(" "+currentOption );
                }
                Console.ResetColor();
                    
            }
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Count - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Count)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
