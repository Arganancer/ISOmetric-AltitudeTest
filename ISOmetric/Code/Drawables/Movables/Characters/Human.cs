using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOmetric.Code.Drawables.Movables.Characters
{
    public class Human : Character
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="nbVertices"></param>
        /// <param name="speed"></param>
        /// <param name="health"></param>
        public Human(float posX, float posY, uint nbVertices, float speed, int health)
            :base(posX, posY, nbVertices, speed, health)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            return true;
        }
    }
}
