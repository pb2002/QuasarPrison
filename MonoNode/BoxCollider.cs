using Microsoft.Xna.Framework;

namespace MonoNode
{
    /// <summary>
    /// A 2D Box Collider.
    /// </summary>
    public class BoxCollider : Collider
    {
        public Vector2 Size;
        public Box Bounds => new Box(GlobalPosition, Size);
        
        /// <summary>
        /// A 2D Box Collider.
        /// </summary>
        /// <param name="name">the name of the node.</param>
        /// <param name="size">the size of the collision box.</param>
        /// <param name="layer">the layer of this collider</param>
        /// <param name="layerMask">the layers this collider will scan for collisions.</param>
        public BoxCollider(string name, Vector2 size, CollisionLayer layer, int layerMask = 1) : base(name, layer, layerMask)
        {
            Size = size;
        }

        public override bool CheckCollision(Collider other, out Box overlap)
        {
            if(!base.CheckCollision(other, out overlap)) return false;

            if (other.GetType() == typeof(BoxCollider))
            {
                
                if (Bounds.Intersects(((BoxCollider)other).Bounds, out overlap))
                {
                    return true;
                }
            }
            return false;
        }
    }
}