using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoNode
{
    public class SpriteNode : Node
    {
        public SpriteSheet Sheet { get; set; }
        public Vector2 UnscaledSize { get; }
        public Vector2 Scale { get; set; }
        
        public Vector2 Size => Scale * UnscaledSize;
        
        public float Depth { get; set; }

        public SpriteNode(string name, SpriteSheet sheet) : base(name)
        {
            Sheet = sheet;
            UnscaledSize = sheet.Size.ToVector2() / Camera.PixelsPerUnit;
            Scale = Vector2.One;
        }
        public SpriteNode(string name, SpriteSheet sheet, Vector2 scale) : base(name)
        {
            Sheet = sheet;
            Scale = scale;
        }
        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Sheet.Draw(spriteBatch, Camera.Current.GetSpriteRect(GlobalPosition, Size));
        }
    }
}