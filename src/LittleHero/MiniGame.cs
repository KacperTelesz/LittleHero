using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class MiniGame : Game
    {
        private World myWorld;
        private Player currentPlayer;
        private Character currentEnemy;
        private List<Character> currentEnemies = new List<Character>();
        private static int currentLevel = 1;
        private string[,] currentGrid = LevelParser.ParseFileToArray("Level" + currentLevel.ToString() + ".txt");
        public void Start(Player player)
        {
            Console.CursorVisible = false;
            currentEnemy = new Character(new WolfFactory());          
            myWorld = new World(currentGrid);
            currentPlayer = player;
            currentEnemy = currentEnemy.GenerateEnemy(currentLevel,myWorld);
            
            currentEnemies.Add(currentEnemy);
                                                    
            RunGameLoop();
        }
        private void GenerateEnemiesInLevel()
        {
            currentEnemies = new List<Character>();
            int numberOfEnemies = 5;
            if(currentLevel == 2)
            {
                numberOfEnemies = 1;
            }
            for (int i = 1; i <= numberOfEnemies; i++)
            {
                currentEnemy = new Character(new WolfFactory());
                currentEnemy = currentEnemy.GenerateEnemy(currentLevel, myWorld);
                currentEnemies.Add(currentEnemy);
            }
            if(currentLevel > 3)
            {
                for (int i = 1; i <= numberOfEnemies; i++)
                {
                    currentEnemy = new Character(new SpiderFactory());
                    currentEnemy = currentEnemy.GenerateEnemy(currentLevel, myWorld);
                    currentEnemies.Add(currentEnemy);
                }
            }
        }
        private void DrawFrame()
        {
            Console.Clear();
            myWorld.Draw();           
            for(int i = 0; i < currentEnemies.Count;i++)
            {
                if (currentEnemies[i].IsAlive && currentLevel != 1)
                {
                    currentEnemies[i].Draw();
                }
            }
            currentPlayer.Draw();          
        }
        private void HandlePlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            } while (Console.KeyAvailable);
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (myWorld.IsPositionWalkable(currentPlayer.X, currentPlayer.Y - 1))
                    {
                        currentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (myWorld.IsPositionWalkable(currentPlayer.X, currentPlayer.Y + 1))
                    {
                        currentPlayer.Y++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (myWorld.IsPositionWalkable(currentPlayer.X + 1, currentPlayer.Y))
                    {
                        currentPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (myWorld.IsPositionWalkable(currentPlayer.X - 1, currentPlayer.Y))
                    {
                        currentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.E:
                    {
                        Console.Clear();
                        OpenInventory(currentPlayer);
                    }
                    break;
                default:
                    break;
            }
        }
        private void RunGameLoop()
        {            
            while (true)
            {
                DrawFrame();
                HandlePlayerInput();

                string elementAtPlayerPos = myWorld.GetElementAt(currentPlayer.X, currentPlayer.Y);
                
                if (elementAtPlayerPos == ">")
                {
                    GoToNextLevel();
                    GenerateEnemiesInLevel();
                }
                if (elementAtPlayerPos == "<")
                {
                    GoToPreviousLevel();                   
                    if(currentLevel == 1)
                    {
                        currentEnemies = new List<Character>();
                    }
                    else
                    {
                        GenerateEnemiesInLevel();
                    }                    
                }               
                for(int i = 0; i<currentEnemies.Count;i++)
                {
                    if(currentEnemies[i].X == currentPlayer.X && currentEnemies[i].Y == currentPlayer.Y && currentEnemies[i].IsAlive && currentLevel != 1)
                    {
                        IntroCurrentEnemy(currentEnemies[i]);
                        BattleCurrentEnemy(currentEnemies[i], currentPlayer);
                    }
                    if(elementAtPlayerPos == "B")
                    {
                        currentEnemy = new GooseBoss(new List<Item>());
                        currentEnemy.Stats.Health = currentEnemy.Stats.MaxHealth;
                        IntroCurrentEnemy(currentEnemy);
                        BattleCurrentEnemy(currentEnemy, currentPlayer);
                        if(currentEnemy.IsDead)
                        {
                            Console.Clear();
                            Console.WriteLine(AsciiArt.YouWon);
                            FinalStats(currentPlayer);
                            Console.ReadKey(true);
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }
        private void GoToNextLevel()
        {
            currentLevel = currentLevel + 1;
            currentGrid = LevelParser.ParseFileToArray("Level" + currentLevel.ToString() + ".txt");
            myWorld = new World(currentGrid);
            currentPlayer.X = 1;
            currentPlayer.Y = 5;
        }
        private void GoToPreviousLevel()
        {
            currentLevel = currentLevel - 1;
            currentGrid = LevelParser.ParseFileToArray("Level" + currentLevel.ToString() + ".txt");
            myWorld = new World(currentGrid); 
            if(currentLevel == 5)
            {
                currentPlayer.X = 21;
                currentPlayer.Y = 5;
            }
            else
            {
                currentPlayer.X = 26;
                currentPlayer.Y = 5;
            }
        }        
    }
}
