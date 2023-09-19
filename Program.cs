using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jalgpallinaide;
namespace Jalgpallinaide
{

    public class Program
    {
        public static void Main()
        {

            Team t1 = new Team("Esimene");

            Player p1 = new Player("Mängija1");
            t1.AddPlayer(p1);
            Player p2 = new Player("Mängija2");
            t1.AddPlayer(p2);

            Team t2 = new Team("Teine");

            Player p3 = new Player("Mängija1");
            t2.AddPlayer(p3);
            Player p4 = new Player("Mängija2");
            t2.AddPlayer(p4);

            Stadium s = new Stadium(600, 400);
            Game g = new Game(t1, t2, s);
            g.Start();
        }
    }
}
