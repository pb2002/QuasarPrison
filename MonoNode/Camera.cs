using Microsoft.Xna.Framework;

namespace MonoNode
{
    public class Camera : Node
    {
        public static Camera Current { get; private set; }

        /// <summary>
        /// The height of the camera, in units
        /// </summary>
        public float Scale { get; set; }
        
        public bool PixelPerfect { get; set; }

        public const int PixelsPerUnit = 16;
        
        public Vector2 Size => Scale * Screen.Resolution.ToVector2() / Screen.Resolution.Y;

        public Matrix ViewMatrix => Matrix.CreateScale(Screen.Resolution.Y / (Scale * PixelsPerUnit), Screen.Resolution.Y / (Scale * PixelsPerUnit), 0) 
                                    * Matrix.CreateTranslation(-GlobalPosition.X, -GlobalPosition.Y, 0);
                                    

        private Vector2 _minBounds;
        private Vector2 _maxBounds;
        private bool _useBounds = false;
        
        public Camera(string name, float scale = 20) : base(name)
        {
            Scale = scale;
        }
        public void SetAsCurrent()
        {
            Current = this;
        }
        public void CenterAt(Vector2 p)
        {
            LocalPosition = p - Size / 2;
            ClampToBounds();
        }
        public void MoveTo(Vector2 p)
        {
            LocalPosition = p;
            ClampToBounds();
        }

        public void SetBounds()
        {
            _useBounds = false;
        }
        public void SetBounds(Vector2 min, Vector2 max)
        {
            _useBounds = true;
            _minBounds = min;
            _maxBounds = max;
        }

        private void ClampToBounds()
        {
            LocalPosition = Vector2.Clamp(LocalPosition, _minBounds, _maxBounds - Size);
        }
        public Rectangle GetSpriteRect(Vector2 position, Vector2 size)
        {
            Vector2 scaledPos = PixelPerfect ? Vector2.Round(PixelsPerUnit * position) : PixelsPerUnit * position;
            Vector2 scaledSize = PixelPerfect ? Vector2.Round(PixelsPerUnit * size) : PixelsPerUnit * size;
            return new Rectangle(scaledPos.ToPoint(), scaledSize.ToPoint());
        }
            
        
        public Vector2 ScreenToWorldSpace(Vector2 p) => Scale * p / Screen.Resolution.Y + GlobalPosition;
        public Vector2 ScreenToWorldSpace(Point p) => ScreenToWorldSpace(p.ToVector2());
        public Point WorldToScreenSpace(Vector2 p) => ((p - GlobalPosition) * Screen.Resolution.Y / Scale).ToPoint();
    }
}