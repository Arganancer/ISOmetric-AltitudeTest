using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace ISOmetric.Code
{
    /// <summary>
    /// Any shape that will be drawn to the screen will inherit from this class.
    /// </summary>
    public abstract class Drawable
    {
        #region Variables
        protected static Random rnd = new Random();
        protected ConvexShape shape = null;
        #endregion

        #region Properties
        /// <summary>
        /// The position of the shape's origin.
        /// </summary>
        public Vector2f Position { get; set; }

        /// <summary>
        /// The object's fill color.
        /// </summary>
        public Color Color
        {
            get { return shape.FillColor; }
            set { shape.FillColor = value; }
        }

        /// <summary>
        /// The object's visual orientation.
        /// </summary>
        public virtual float Angle
        {
            get { return shape.Rotation; }
            set { shape.Rotation = value; }
        }

        /// <summary>
        /// The object's points.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector2f this[uint index]
        {
            get { return shape.GetPoint(index); }
            set { shape.SetPoint(index, value); }
        }

        /// <summary>
        /// Retourne la boîte englobante associée à la forme.  Utilisée pour les collisions.
        /// </summary>
        public FloatRect BoundingBox
        {
            get { return shape.GetGlobalBounds(); }
        }
        #endregion

        /// <summary>
        /// Drawable Constructor
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="nbVertices"></param>
        /// <param name="color"></param>
        protected Drawable(float posX, float posY, uint nbVertices)
        {
            Position = new Vector2f(posX, posY);
            shape = new ConvexShape(nbVertices);
            Angle = 0;
        }

        /// <summary>
        /// Draw the object to the game view.
        /// </summary>
        /// <param name="window"></param>
        public virtual void Draw(RenderWindow window)
        {
            shape.Position = Position;
            window.Draw(shape);
        }


        /// <summary>
        /// Vérifie si deux éléments affichés s'entrecoupent
        /// </summary>
        /// <param name="m">Le second élément avec lequel vérifier la collision</param>
        /// <returns>true s'il y a collision, false sinon.</returns>
        public bool Intersects(Drawable m)
        {
            FloatRect r = m.BoundingBox;
            r.Left = m.Position.X;
            r.Top = m.Position.Y;
            return BoundingBox.Intersects(r);
        }

        /// <summary>
        /// Vérifie si l'objet contient le point où se trouve l'élément reçu en paramètre
        /// </summary>
        /// <param name="m">L'élément dont il faut vérifier la position</param>
        /// <returns>true si la boîte englobante de l'objet courant contient le point (la position) où se
        /// trouve l'objet reçu en paramètre</returns>
        public bool Contains(Drawable m)
        {
            return BoundingBox.Contains(m.Position.X, m.Position.Y);
        }
    }
}
