using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOmetric.Code.Drawables.Movables
{
    public abstract class Character : Movable
    {
        private readonly int maxHealth = 0;
        private int currentHealth = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="nbVertices"></param>
        /// <param name="speed"></param>
        protected Character(float posX, float posY, uint nbVertices, float speed, int health)
            :base(posX, posY, nbVertices, speed)
        {
            maxHealth = health;
            currentHealth = health;
        }
    }
}
