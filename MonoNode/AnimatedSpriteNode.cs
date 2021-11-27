using Microsoft.Xna.Framework;

namespace MonoNode
{
    public class AnimatedSpriteNode : SpriteNode
    {
        public AnimatedSpriteNode(string name, SpriteSheet sheet) : base(name, sheet) { }
        public AnimatedSpriteNode(string name, SpriteSheet sheet, Vector2 scale) : base(name, sheet, scale) { }
    }
}