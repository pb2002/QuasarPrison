using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoNode
{
    public class SpriteNode : Node
    {
        public Texture2D Sprite { get; set; }
        public Vector2 UnscaledSize { get; }
        public Vector2 Scale { get; set; }
        
        public Vector2 Size => Scale * UnscaledSize;
        
        public float Depth { get; set; }

        public SpriteNode(string name, Texture2D sprite) : base(name)
        {
            Sprite = sprite;
            UnscaledSize = sprite.Bounds.Size.ToVector2() / Camera.PixelsPerUnit;
            Scale = Vector2.One;
        }
        public SpriteNode(string name, Texture2D sprite, Vector2 scale) : base(name)
        {
            Sprite = sprite;
            Scale = scale;
        }
        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Camera.Current.GetSpriteRect(GlobalPosition, Size), Color.White);
        }
    }
}