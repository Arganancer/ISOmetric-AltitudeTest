using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ISOmetric.Code.Drawables
{
    class Cube
    {
        private int i = 0;
        private int j = 0;
        private int k = 0;

        private Tile tile;
        private Wall leftWall;
        private Wall rightWall;

        /// <summary>
        /// Cube Constructor.
        /// </summary>
        public Cube(int i, int j, int k)
        {
            this.i = i;
            this.j = j;
            this.k = k;
            tile = new Tile(i, j, k, 4);
            leftWall = new Wall(i, j, k, 4, true);
            rightWall = new Wall(i, j, k, 4, false);
        }

        /// <summary>
        /// Drawing the cubes.
        /// </summary>
        /// <param name="window"></param>
        public void Draw(RenderWindow window)
        {
            if (Level.level.GetLength(0) != j + 1)
            {
                if (Level.level[i, j + 1, k] == 0)
                {
                    leftWall.Draw(window);
                }
            }
            else
            {
                leftWall.Draw(window);
            }
            if (Level.level.GetLength(0) != i + 1)
            {
                if (Level.level[i + 1, j, k] == 0)
                {
                    rightWall.Draw(window);
                }
            }
            else
            {
                rightWall.Draw(window);
            }
            if (Level.level.GetLength(2) != k + 1)
            {
                if (Level.level[i, j, k + 1] == 0)
                {
                    tile.Draw(window);
                }
            }
            else
            {
                tile.Draw(window);
            }
        }
    }
}
