using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOmetric.Code
{
    /// <summary>
    /// Game world.
    /// </summary>
    public static class Level
    {
        private static Random rnd = new Random();
        public static int[,,] level;

        /// <summary>
        /// Extract level from txt file.
        /// </summary>
        /// <param name="levelName"></param>
        /// <returns></returns>
        public static void CreateLevel(int x, int y, int z)
        {
            level = new int[x, y, z];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (k == 0)
                        {
                            level[i, j, k] = 1;
                        }
                        else
                        {
                            if (level[i, j, k - 1] == 1)
                            {
                                level[i, j, k] = rnd.Next(0, 2);
                            }
                        }
                    }
                }
            }
        }
    }
}
