using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoNode
{
    public class Tile : SpriteNode
    {
        public Point GridPosition { get; }
        public Tile(Point gridPosition, string name, Texture2D sprite) : base(name, sprite)
        {
            GridPosition = gridPosition;
            LocalPosition += GridPosition.ToVector2();
        }
        public Tile(Point gridPosition, string name, Texture2D sprite, Vector2 scale) : base(name, sprite, scale)
        {
            GridPosition = gridPosition;
            LocalPosition += GridPosition.ToVector2();
        }
        
    }
}