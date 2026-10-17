using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    abstract class EnemyFactory
    {
        public abstract Character CreateEnemy(int stage,World world);
        public abstract Item CreateItem(int stage);
        public Random RandGenerator { get; protected set; }
        public (int,int) GenerateRandomCords(World world)
        {
            RandGenerator = new Random();
            int x;
            int y;
            do
            {
                x = RandGenerator.Next(0, 27);
                y = RandGenerator.Next(0, 9);                
            }
            while(world.IsPositionEmpty(x,y) == false);
            (int, int) cords = (x,y);                       
            return cords;
        }      
    }
}
