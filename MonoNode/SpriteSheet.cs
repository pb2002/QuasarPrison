using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoNode
{
    public class SpriteSheet
    {
        private readonly Texture2D _sprite;

        private readonly int _cols,
            _rows,
            _width,
            _height;

        private int _sheetIndex,
            _columnIndex,
            _rowIndex;

        private Rectangle _spriteRect;

        public int SheetIndex
        {
            get => _sheetIndex;
            set
            {
                if (_sheetIndex < 0 || _sheetIndex >= _rows * _cols)
                    throw new System.IndexOutOfRangeException();

                _sheetIndex = value;
                _columnIndex = _sheetIndex % _cols;
                _rowIndex = _sheetIndex / _cols;
                _spriteRect = new Rectangle(_columnIndex * _width, _rowIndex * _height, _width, _height);
            }
        }
        public int Width => _width;
        public int Height => _height;
        public Point Size => _spriteRect.Size;
        
        public SpriteSheet(string assetName)
        {
            var el = assetName.Split("@");
            _sprite = AssetManager.Instance.LoadSprite(el[0]);

            if (el.Length > 1)
            {
                var dimensions = el[1].Split("x");
                if (dimensions.Length == 2 && int.TryParse(dimensions[0], out int w) && int.TryParse(dimensions[1], out int h))
                { 
                    _cols = w;
                    _rows = h;
                }
                else throw new System.FormatException($"'{el[1]}' is not a valid sheet size descriptor");
                 
            }
            else
            {
                _cols = 1;
                _rows = 1;
            }
            
            _width = _sprite.Width / _cols;
            _height = _sprite.Height / _rows;

            SheetIndex = 0;
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle dest)
        {
            spriteBatch.Draw(_sprite, dest, _spriteRect, Color.White);
        }
    }
}