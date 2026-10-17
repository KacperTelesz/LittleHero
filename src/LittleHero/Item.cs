using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class Item
    {
        public string Name { get; protected set; }     
        public Stats itemStats { get; protected set; }
        public string Description { get; protected set; }
        public Item()
        {

        }
        public void ItemInfo()
        {
            Console.WriteLine(Name+" Lvl: "+itemStats.Level);
            Console.WriteLine(Description);
        }
    }
}
