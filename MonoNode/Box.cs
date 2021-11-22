using System;
using Microsoft.Xna.Framework;
using Rectangle = SharpDX.Rectangle;

namespace MonoNode
{
    /// <summary>
    /// A float-based version of Rectangle
    /// </summary>
    public class Box
    {
        public static Box Empty => new Box();
        
        public float X;
        public float Y;
        public float Width;
        public float Height;

        public Vector2 Position => new Vector2(X, Y);
        public Vector2 Size => new Vector2(Width, Height);
        public Vector2 Center => new Vector2(X + Width / 2, Y + Height / 2);
        
        public float Top => Y;
        public float Bottom => Y + Height;
        public float Left => X;
        public float Right => X + Width;

        public bool IsEmpty => X == 0 && Y == 0 && Width == 0 && Height == 0;
        
        public Box()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
        }
        
        public Box(Vector2 position, Vector2 size)
        {
            (X, Y) = position;
            (Width, Height) = size;
            
        }
        
        public Box(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        
        public bool Contains(Vector2 p) => Contains(p.X, p.Y);
        public bool Contains(Box b) => Contains(b.Top, b.Left) && Contains(b.Bottom, b.Right);
        public bool Contains(float x, float y) => x > Left && x < Right && y > Top && y < Bottom;
        
        public void Deconstruct(out float x, out float y, out float width, out float height)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
        }

        public void Inflate(float hAmount, float vAmount)
        {
            X -= hAmount / 2;
            Y -= vAmount / 2;
            Width += hAmount;
            Height += vAmount;
        }
        public bool Intersects(Box other)
        {
            if (Left >= other.Right || other.Left >= Right) return false;
            if (Bottom >= other.Top || other.Bottom >= Top) return false;
            
            return true;
        }
        public bool Intersects(Box other, out Box overlap)
        {
            overlap = null;
            if (Left >= other.Right || other.Left >= Right) return false;
            if (Bottom <= other.Top || other.Bottom <= Top) return false;
            
            float xmin = MathF.Max(Left, other.Left);
            float xmax = MathF.Min(Right, other.Right);
            float ymin = MathF.Max(Top, other.Top);
            float ymax = MathF.Min(Bottom, other.Bottom);

            overlap = new Box(xmin, ymin, xmax - xmin, ymax - ymin);
            
            return true;
        }
    }
}