using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class Character
    {
        public string Name { get; protected set; }
        public string Image { get; protected set; }
        public Stats Stats { get; protected set; }
        public List<Item> Equipment { get; protected set; }
        public Random RandGenerator { get; protected set; }
        public bool IsDead { get => Stats.Health <= 0; }
        public bool IsAlive { get => Stats.Health > 0; }
        public int X { get; set; }
        public int Y { get; set; }
        public string CharacterMarker { get; protected set; }
        public ConsoleColor CharacterColor { get; protected set; }
        private EnemyFactory enemyFactory;

        public Character(string _name, string _image, Stats _stats, 
            List<Item> _equipment, int _initialX, int _initialY, string _characterMarker,
            ConsoleColor _characterColor)
        {
            Name = _name;
            Image = _image;
            Stats = _stats;
            Equipment = _equipment;
            RandGenerator = new Random();
            X = _initialX;
            Y = _initialY;
            CharacterMarker = _characterMarker;
            CharacterColor = _characterColor;
        }
        public Character(EnemyFactory _enemyFactory)
        {
            enemyFactory = _enemyFactory;
        }
        
        public Character GenerateEnemy(int stage, World world)
        {
            Character enemy = enemyFactory.CreateEnemy(stage, world);
            Item item = enemyFactory.CreateItem(stage);
            List<Item> eq = new List<Item>();
            eq.Add(item);
            enemy.Equipment = eq;
            enemy.CharacterColor = ConsoleColor.Red;
            return enemy;
        }        
        public void Draw()
        {
            Console.ForegroundColor = CharacterColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(CharacterMarker);
            Console.ResetColor();
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"{Name} Level: {Stats.Level}");
            DisplayExperience();
            Console.WriteLine($"{Image}");
            DisplayHealth();        
        }
        public virtual void DisplayEquipment()
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
        }
        public virtual void Fight(Character otherCharacter)
        {
            RandGenerator = new Random();
            Console.WriteLine("Enemy is Fighting");
        }
        public void TakeDamage(int damage)
        {
            Stats.Health -= damage;
            if (Stats.Health < 0)
            {
                Stats.Health = 0;
            }
        }
        public void DisplayHealth()
        {
            DisplayBar(Stats.Health,Stats.MaxHealth,ConsoleColor.Red,"Health");      
        }
        public void DisplayExperience()
        {
            DisplayBar(Stats.Experience, Stats.MaxExperience, ConsoleColor.Blue,"Exp");
        }
        public void DisplayBar(int value, int maxValue,ConsoleColor color,string whatItShows)
        {
            Console.Write("|");
            Console.BackgroundColor = color;
            for (int i = 1; i <= value; i++)
            {
                if (i % 50 == 0 && i != maxValue && i != 0)
                {
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("|");
                    Console.Write("|");
                    Console.BackgroundColor = color;
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = value + 1; i <= maxValue; i++)
            {
                if (i % 50 == 0 && i != 0 && i!=maxValue)
                {
                    Console.Write(" ");
                    Console.WriteLine("|");
                    Console.Write("|");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine($"| {value}/{maxValue} {whatItShows}");
        }
    }
}
