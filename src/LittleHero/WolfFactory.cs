using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class WolfFactory : EnemyFactory
    {
        public override Character CreateEnemy(int stage,World world)
        {
            RandGenerator = new Random();
            int rnd = RandGenerator.Next(1, stage);

            int health = 10 + 2 * stage;
            Stats stats = new Stats(health,health,rnd,2 * stage,stage,5+stage,5+stage);
            (int, int) cords = GenerateRandomCords(world);      
           
            return new Wolf(stats, null, cords.Item1, cords.Item2);
        }
        public override Item CreateItem(int stage)
        {
            RandGenerator = new Random();
            int rnd = RandGenerator.Next(1, 101);
            if (rnd <= 70)
            {
                return new HealthPotion();
            }
            else
            {
                return new ShortSword(stage);
            }
        }
    }
}
