using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class GooseBoss : Character
    {
        public GooseBoss(List<Item> eq)
            : base("MAD GOOSE!!!", AsciiArt.Goose, Stats.GooseStats, eq,0,0,"G",ConsoleColor.Red)
        {

        }
        private void MASSIVEHONK(Character otherCharacter)
        {
            Console.WriteLine($"{Name} honks aggressively, sound wave deals you {Stats.AttackDmg}hp");
            otherCharacter.TakeDamage(Stats.AttackDmg);
        }
        public override void Fight(Character otherCharacter)
        {
            MASSIVEHONK(otherCharacter);
        }
    }
}
