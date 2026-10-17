using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class HealthPotion : Item
    {
        private Stats stats = new Stats(10, 0, 0, 0, 0, 0, 0);
        public HealthPotion()
        {
            Name = "Health potion";
            itemStats = stats;
            Description = @$"This {Name} heals you for {itemStats.Health} imidietly";
        }
    }
}
