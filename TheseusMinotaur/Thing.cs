using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusMinotaur
{

    class Thing
    {
        public Point Coordinate;
        public Game2 myGame;

        public Thing(int x, int y)
        {
            Coordinate = new Point(x, y);
        }
        internal void SetGame(Game2 aGame)
        {
            myGame = aGame;
        }
    }
}