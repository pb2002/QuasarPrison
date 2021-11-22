using System.Collections.Generic;

namespace MonoNode
{
    /// <summary>
    /// Enum mask for the different collision layers.
    /// Use '|' to combine layers to form a mask.
    /// </summary>
    public enum CollisionLayer
    {
        Layer0 = 1,
        Layer1 = 1 << 1,
        Layer2 = 1 << 2,
        Layer3 = 1 << 3,
        Layer4 = 1 << 4,
        Layer5 = 1 << 5,
        Layer6 = 1 << 6,
        Layer7 = 1 << 7,
        Layer8 = 1 << 8,
        Layer9 = 1 << 9,
        Layer10 = 1 << 10,
        Layer11 = 1 << 11,
        Layer12 = 1 << 12,
        Layer13 = 1 << 13,
        Layer14 = 1 << 14,
        Layer15 = 1 << 15
    }
    /// <summary>
    /// Abstract definition of a collider.
    /// </summary>
    public abstract class Collider : Node
    {
        public CollisionLayer Layer { get; }
        public int LayerMask { get; }
        /// <summary>
        /// Abstract definition of a collider.
        /// </summary>
        /// <param name="name">the name of the node.</param>
        /// <param name="layer">the layer of this collider</param>
        /// <param name="layerMask">the layers this collider will scan for collisions.</param>
        protected Collider(string name, CollisionLayer layer, int layerMask = 1) : base(name)
        {
            Layer = layer;
            LayerMask = layerMask;
            
        }
        protected override void Init()
        {
            Root.RegisterCollider(this);
        }
        public virtual bool CheckCollision(Collider other, out Box overlap)
        {
            overlap = null;
            if (((int)Layer & other.LayerMask) == 0) return false;
    
            return true;
        }
    }
}