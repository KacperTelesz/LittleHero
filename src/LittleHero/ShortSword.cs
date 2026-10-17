using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class ShortSword : Item
    {
        private Stats stats = new Stats(10,0,0,0,1,10,10);
        public ShortSword(int level)
        {
            itemStats = stats;
            itemStats.Level = level; 
            Name = $"Short Sword";
            Description = @$"{Name} is a short range metal small arms
{itemStats.StatsInfo()}";
        }
    }
}
