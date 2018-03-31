using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOmetric.Code.Drawables
{
    public abstract class Movable : Drawable
    {

        private float speed;
        
        /// <summary>
        /// Constructor of the Movable class.
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="nbVertices"></param>
        protected Movable(float posX, float posY, uint nbVertices, float speed)
            : base(posX, posY, nbVertices)
        {
            this.speed = speed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool Update();

        /// <summary>
        /// 
        /// </summary>
        public void Advance()
        {
            
        }
    }
}
