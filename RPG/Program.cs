using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {
        private static Player player;

        static void Main(string[] args)
        {
            player = new Player();
        }

        static void GenMonster()
        {
            Random rnd = new Random();
            int powerLevel = rnd.Next(1, 6);

            int monsterLevel = player.getLevel() + powerLevel;
            int monsterHealth = 100;

            Monster giant = new Monster("Giant", player.getLevel()+powerLevel, giant.getLevel );
        }
    
    }
}
