using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class LegendaryGoldenFeather : Item
    {
        private Stats stats = new Stats(10, 10, 10, 10, 10, 10, 10);
        public LegendaryGoldenFeather()
        {
            Name = "Legendary golden feather";
            itemStats = stats;
            Description = @$"This {Name}... idk what is doing you are first hero who deafeated the goose";
        }
    }
}
