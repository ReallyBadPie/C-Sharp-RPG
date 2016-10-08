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

        static void GenGiant()
        {
            Random rnd = new Random();
            int pwrLvl = rnd.Next(1, 6);
            Monster giant = new RPG.Monster("Giant", player.getLevel()+pwrLvl, giant.getLevel );
        }
    
    }
}
