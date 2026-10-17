using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class Player : Character
    {
        public bool declareToRun = false;
        public Player(string _name, Stats _stats , List<Item> _equipment,int _initialX,int _initialY)
            : base(_name, AsciiArt.Player, _stats, _equipment,_initialX,_initialY,"O",ConsoleColor.Blue)
        {
            Stats.EnemiesDefeated = 0;
            Stats.MaxExperience = Stats.Level * Stats.Level;
        }
        private void Attack(Character otherCharacter)
        {
            int rnd = RandGenerator.Next(1, 101);
            if(rnd <= 50 + Stats.AttackSpeed)
            {
                Console.WriteLine($"You deal {Stats.AttackDmg} damage");
                otherCharacter.TakeDamage(Stats.AttackDmg);
            }
            else
            {
                Console.WriteLine($"{Name} Miss");
            }
        }
        public override void Fight(Character otherCharacter)
        {            
            Console.WriteLine($@"
1) Attack
2) Block
3) Run away");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.Clear();
            if (keyInfo.Key == ConsoleKey.D1)
            {
                Attack(otherCharacter);
            }
            else if(keyInfo.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Blok");
            }
            else if(keyInfo.Key == ConsoleKey.D3)
            {
                declareToRun = true;
            }
            else
            {
                Console.WriteLine($"{Name} uses! nothing... really?");              
            }         
        }
        public override void DisplayEquipment()
        {
            List<string> names = new List<string>();
            List<string> eqNames = new List<string>();

            for (int i = 0; i < Equipment.Count; i++)
            {
                if (names.Contains(Equipment[i].Name) == false)
                {
                    Console.Write(Equipment[i].Name);
                    int amountOfItemsOf1Type = 0;
                    for (int j = 0; j < Equipment.Count; j++)
                    {
                        if (Equipment[i].Name == Equipment[j].Name)
                        {
                            amountOfItemsOf1Type++;
                        }
                    }
                    Console.WriteLine(" x" + amountOfItemsOf1Type.ToString());
                    names.Add(Equipment[i].Name);
                    eqNames.Add(Equipment[i].Name + " x" + amountOfItemsOf1Type.ToString());
                }
            }
            Menu BackPack = new Menu(eqNames,"Your Backpack:");
            if(Equipment.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Your Backpack is empty");
                Console.ReadKey(true);
            }
            else
            {
                int selectedIndex = BackPack.Run();
                if (names[selectedIndex] == "Health potion")
                {
                    Stats.Health += 10;
                    if (Stats.Health > 100)
                    {
                        Stats.Health = 100;
                    }
                    Equipment.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
