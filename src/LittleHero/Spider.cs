using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class Spider : Character
    {
        private bool HasPoison;
        public Spider(Stats _stats, List<Item> _equipment, bool _hasPoison,int _initialX,int _initialY)
            : base("Giant Spider", AsciiArt.Spider, _stats, _equipment,_initialX,_initialY,"S",ConsoleColor.Red)
        {
            HasPoison = _hasPoison;
        }
        public void Bite(Character otherCharacter)
        {
            int rnd = RandGenerator.Next(1, 101);
            if (rnd <= 50 + Stats.AttackSpeed)
            {
                if(HasPoison == true)
                {
                    Console.WriteLine($"{Name} bites you for {Stats.AttackDmg}hp!");
                    otherCharacter.TakeDamage(Stats.AttackDmg);
                }
                else
                {
                    Console.WriteLine($"{Name} bites you for {Stats.AttackDmg/2}hp!");
                    otherCharacter.TakeDamage(Stats.AttackDmg/2);
                }
            }
            else
            {
                Console.WriteLine($"{Name} Miss");
            }
        }
        public override void Fight(Character otherCharacter)
        {
            Bite(otherCharacter);
        }
    }
}
