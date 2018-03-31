using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace ISOmetric.Code.Drawables
{
    public class Tile : Drawable
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
        public Tile(float posX, float posY, float posZ, uint nbVertices)
            : base(posX, posY, nbVertices)
        {
            size = 30;
            Color = new Color(63, 167, 63);
            shape.OutlineThickness = 1;
            shape.OutlineColor = new Color(87, 76, 57);
            cartPosX = posX;
            cartPosY = posY;
            CartToIsoPos(posZ);
            // Top point
            this[0] = new Vector2f(0, -size);
            // Right point
            this[1] = new Vector2f(size * 2f, 0);
            // Bottom point
            this[2] = new Vector2f(0, size);
            // Left point
            this[3] = new Vector2f(-size * 2f, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        private void CartToIsoPos(float posZ)
        {
            float isoPosX = (cartPosX - cartPosY) * size * 2;
            float isoPosY = (cartPosX + cartPosY) * size - (posZ * 2 * size);
            Position = new Vector2f(isoPosX, isoPosY);
        }
    }
}
