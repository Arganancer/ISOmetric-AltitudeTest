using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace ISOmetric.Code.Drawables
{
    public class Wall : Drawable
    {
        private float cartPosX = 0;
        private float cartPosY = 0;
        private float size = 0;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="nbVertices"></param>
        public Wall(float posX, float posY, float posZ, uint nbVertices, bool isLeftWall)
            : base(posX, posY, nbVertices)
        {
            size = 30;
            Color = new Color(63, 167,  63);
            shape.OutlineThickness = 1;
            shape.OutlineColor = new Color(87, 76, 57);
            cartPosX = posX;
            cartPosY = posY;
            CartToIsoPos(posZ);
            // Top center
            this[0] = new Vector2f(0, -size);
            // Bottom center
            this[1] = new Vector2f(0, size);
            if (isLeftWall)
            {
                Color = new Color(50, 127, 50);
                // Bottom left
                this[2] = new Vector2f(-2*size, 0);
                // Top left
                this[3] = new Vector2f(-2*size, -2*size);
            }
            else
            {
                Color = new Color(31, 79, 31);
                // Bottom right
                this[2] = new Vector2f(2 * size, 0);
                // Top right
                this[3] = new Vector2f(2 * size, -2 * size);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CartToIsoPos(float posZ)
        {
            float isoPosX = (cartPosX - cartPosY) * size * 2;
            float isoPosY = (cartPosX + cartPosY) * size + size*2 - (posZ * 2 * size);
            Position = new Vector2f(isoPosX, isoPosY);
        }
    }
}
