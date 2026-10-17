using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class Wolf : Character
    {
        
        public Wolf(Stats _stats, List<Item> _equipment,int _initialX,int _initialY)
            : base("Wild Wolf",AsciiArt.Wolf,_stats,_equipment,_initialX,_initialY,"W",ConsoleColor.Red)
        {
            
        }
        private void Bite(Character otherCharacter)
        {
            int rnd = RandGenerator.Next(1, 101);
            if(rnd <= 50 + Stats.AttackSpeed)
            {
                Console.WriteLine($"{Name} Bites you for {Stats.AttackDmg}hp!");
                otherCharacter.TakeDamage(Stats.AttackDmg);
            }
            else
            {
                Console.WriteLine($"{Name} Miss");
            }
            
        }
        private void Scratch(Character otherCharacter)
        {
            int rnd = RandGenerator.Next(1, 101);
            if(rnd <= 50)
            {
                Console.WriteLine($"{Name} Scratch you for {Stats.AttackDmg / 2}hp!");
                otherCharacter.TakeDamage(Stats.AttackDmg/2);
            }
            else
            {
                Console.WriteLine($"{Name} Miss");
            }
        }
        public override void Fight(Character otherCharacter)
        {
            int rand = RandGenerator.Next(1, 101);
            if (rand <= 50)
            {
                Bite(otherCharacter);
            }
            else 
            {
                Scratch(otherCharacter);
            }
        }
    }
}
