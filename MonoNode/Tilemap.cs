using Microsoft.Xna.Framework;

namespace MonoNode
{
    public class Tilemap : Node
    {
        public Vector2 CellSize;

        public readonly int Width, Height;
        private Tile [,] _tiles;
        
        public Tilemap(string name, int width, int height, Vector2 cellSize) : base(name)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
            _tiles = new Tile[Width, Height];
        }
        public Tilemap(string name, Tile [,] tiles, Vector2 cellSize) : base(name)
        {
            Width = tiles.GetLength(0);
            Height = tiles.GetLength(1);
            CellSize = cellSize;
            _tiles = tiles;
        }
        public Tile GetTile(int x, int y)
        {
            return _tiles[x, y];
        }
        public void SetTile(int x, int y, Tile tile)
        {
            _tiles[x, y].SetActive(false);
            RemoveChild(_tiles[x, y]);
            _tiles[x, y] = tile;
        }
        
    }
}