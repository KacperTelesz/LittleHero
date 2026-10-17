using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LittleHero
{
    class Game
    {
        private Player currentPlayer;
        public void StartTheGame()
        {
            RunMainMenu();
            StartGameplay();
        }
        private void RunMainMenu()
        {
            string headline = AsciiArt.MainLogo;
            List<string> list = new List<string>{ "Start", "Options", "Leave" };
            Menu mainMenu = new Menu(list, headline);
            int selectedIndex = mainMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    StartOptions();
                    break;
                case 1:
                    OptionsInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }
        private void ExitGame()
        {
            List<string> options = new List<string> { "Stay", "Leave Game" };
            string prompt = "Are you sure you want to quit the game?";
            Menu leaveMenu = new Menu(options,prompt);
            int selectedIndex = leaveMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
                case 1:
                    Environment.Exit(0);
                    break;
            }
        }
        private void OptionsInfo()
        {
            Console.Clear();
            Console.WriteLine("Options");
            Console.ReadKey(true);
            RunMainMenu();
        }

        private void StartOptions()
        {
            List<string> options = new List<string> { "New Game", "Load Game", "Go Back to Main Menu" };
            string prompt = "Choose:";
            Menu startMenu = new Menu(options, prompt);
            int selectedIndex = startMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    StartGameplay();
                    break;
                case 1:
                    RunMainMenu();
                    break;
                case 2:
                    RunMainMenu();
                    break;
            }
        }
        
        private void StartGameplay()
        {
            RunIntro();
            new MiniGame().Start(currentPlayer);                                                                               
        }
        private void RunIntro()
        {
            Console.Clear();
            Console.WriteLine("Enter nickname: ");
            string name = Console.ReadLine();
            Console.Clear();
            List<Item> eq = new List<Item>();
            for(int i = 0; i<3;i++)
            {
                HealthPotion p = new HealthPotion();
                eq.Add(p);
            }
            ShortSword s = new ShortSword(1);
            eq.Add(s);
            currentPlayer = new Player(name, Stats.BasicPlayerStats, eq,1,5);               
        }
        public void IntroCurrentEnemy(Character enemy)
        {
            Console.Clear();
            Console.WriteLine($"New Enemy!");
            enemy.DisplayInfo();
            Console.ReadKey(true);
            Console.Clear();
        }
        private void RunGameOver(Player player)
        {
            Console.WriteLine(AsciiArt.GameOver);
            FinalStats(player);
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        public void FinalStats(Player player)
        {
            Console.WriteLine($"Level gained: {player.Stats.Level}");
            Console.WriteLine($"Enemies defeated: {player.Stats.EnemiesDefeated}");
            Console.WriteLine($"Gold gained: {player.Stats.Gold}");
        }
        private void DropScreen(Character enemy)
        {
            Console.WriteLine($"Good Job! You have deafeted {enemy.Name}");
            Console.WriteLine("It drops:");
            enemy.DisplayEquipment();
            Console.WriteLine($@"{enemy.Stats.Gold} Gold
{enemy.Stats.Experience} Exp");
            Console.ReadKey();
        }
        private void UpdatePlayerStats(Player player, Character enemy)
        {
            player.Stats.EnemiesDefeated += 1;
            foreach (Item item in enemy.Equipment)
            {
                player.Equipment.Add(item);
            }
            player.Stats.Gold += enemy.Stats.Gold;
            player.Stats.Experience += enemy.Stats.Experience;
            if (player.Stats.Experience > player.Stats.MaxExperience)
            {
                while (player.Stats.Experience > player.Stats.MaxExperience)
                {
                    player.Stats.Experience = player.Stats.Experience - player.Stats.MaxExperience;
                    player.Stats.Level += 1;
                    player.Stats.MaxExperience = player.Stats.Level * player.Stats.Level;
                }
                Console.Clear();
                Console.WriteLine("Level UP!");
                Console.WriteLine($"Current Level: {player.Stats.Level}");
                player.Stats.AttackDmg = player.Stats.AttackDmg + player.Stats.Level;
                Console.ReadKey(true);
            }
        }
        private void FirstEnemyDefeatedScreen()
        {
            Console.Clear();
            Console.WriteLine(@"Good Job! You have defeated your 1st enemy in game!
Try to press E button to check your updated stats and inventory");
            Console.ReadKey(true);
        }
        public void BattleCurrentEnemy(Character enemy,Player player)
        {
            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine($"{enemy.Name}'s Health: " ); 
                enemy.DisplayHealth();
                Console.WriteLine($"{player.Name}'s Health: ");
                player.DisplayHealth();

                player.Fight(enemy);
                if (enemy.IsDead || player.IsDead || player.declareToRun)
                {                    
                    break;
                }

                Console.WriteLine($"{enemy.Name}'s Health: ");
                enemy.DisplayHealth();
                Console.WriteLine($"{player.Name}'s Health: ");
                player.DisplayHealth();

                Console.ReadKey(true);
                Console.Clear();

                enemy.Fight(player);
                if (enemy.IsDead || player.IsDead)
                {
                    break;
                }
            }
            Console.Clear();
            if(player.IsAlive && player.declareToRun == false)
            {
                DropScreen(enemy);
                UpdatePlayerStats(player,enemy);
                if(player.Stats.EnemiesDefeated == 1)
                {
                    FirstEnemyDefeatedScreen();
                }
            }
            else if(player.IsAlive && player.declareToRun == true)
            {
                player.declareToRun = false;
                Console.WriteLine("pff coward");
                Console.ReadKey(true);
            }
            else
            {
                RunGameOver(player);             
            }
        }
        public void OpenInventory(Player player)
        {
            while (1 == 1)
            {
                Console.Clear();
                player.DisplayInfo();
                Console.WriteLine($"Gold: {player.Stats.Gold}");
                Console.WriteLine("Press B to open Backpack");
                ConsoleKeyInfo keyPressed;
                keyPressed = Console.ReadKey(true);
                if (keyPressed.Key == ConsoleKey.B)
                {
                    player.DisplayEquipment();
                        
                }
                else if(keyPressed.Key == ConsoleKey.E)
                {
                    break;
                }
            } 
        }
    }
}
