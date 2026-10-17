using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class PoisonedFang : Item
    {
        private Stats stats = new Stats(10, 0, 0, 0, 1, 10, 10);
        public PoisonedFang(int level)
        {
            itemStats = stats;
            itemStats.Level = level;
            Name = $"Posoned Swang";
            Description = @$"{Name} is item dropped by ONLY monsters witch have poison
It gives you:
{itemStats.StatsInfo()}";
        }
    }
}
