using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class SpiderFactory : EnemyFactory
    {
        public override Character CreateEnemy(int stage, World world)
        {
            RandGenerator = new Random();
            int rnd = RandGenerator.Next(1, stage);

            int health = 15 + 2 * stage;
            Stats stats = new Stats(health, health, 2 * rnd, 3 * stage, stage, 6 + stage, 6 + stage);

            bool hasPoison = false;

            if(stage>4)
            {
                hasPoison = true;
            }

            (int, int) cords = GenerateRandomCords(world);

            return new Spider(stats, null,hasPoison, cords.Item1,cords.Item2);
        }
        public override Item CreateItem(int stage)
        {
            RandGenerator = new Random();
            int rnd = RandGenerator.Next(1, 101);
            if(rnd <= 70)
            {
                return new HealthPotion();
            }
            else 
            {
                return new PoisonedFang(stage);
            }        
        }
    }
}
