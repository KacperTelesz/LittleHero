using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHero
{
    class Stats
    {
        public int Health { get; set;}
        public int MaxHealth { get; set;}
        public int Gold { get; set;}
        public int Experience { get; set;}
        public int MaxExperience { get; set; }
        public int Level { get; set;}
        public int AttackDmg { get; set;}
        public int AttackSpeed { get; set;}
        public int EnemiesDefeated { get; set; }

        public Stats(int _health, int _maxHealth, int _gold, int _exp, int _lvl, int _attackDmg, int _attackSpeed)
        {
            Health = _health;
            MaxHealth = _maxHealth;
            Gold = _gold;
            Experience = _exp;
            Level = _lvl;
            AttackDmg = _attackDmg;
            AttackSpeed = _attackSpeed;
            MaxExperience = Experience;
        }
        public static Stats BasicWolfStats = new Stats(50, 100, 5, 5, 5, 5, 5);
        public static Stats BasicPlayerStats = new Stats(100, 100 ,10, 0, 1, 5, 10);
        public static Stats GooseStats = new Stats(100, 100, 100, 100, 100, 10, 10);
        public void WolfStatsScaling()
        {

        }
        public string StatsInfo()
        {
            string Info  = "This Item gives you:";                      
            if (Health != 0)
            {
                Info = Info + $"\n +{Health} Health";
            }
            if (AttackDmg != 0)
            {
                Info = Info + $"\n +{AttackDmg} AttackDamage";
            }
            if (AttackSpeed != 0)
            {
                Info = Info + $"\n +{AttackSpeed} AttackSpeed";
            }
            if (Gold != 0)
            {
                Info = Info + $"\n Value: {Gold} gold";
            }
            return Info;
        }
    }
}
