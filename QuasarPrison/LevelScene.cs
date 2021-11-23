using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoNode;

namespace QuasarPrison
{
    public class LevelScene : RootNode
    {
        public LevelScene()
        {
            // initialize your scene here
            var grid = new Tilemap("grid",24,16, Vector2.One);
            AddChild(grid);
            
            var player = new Entity("player", Point.Zero);
            grid.AddChild(player);
            
            player.AddChild(new PlayerController("player-controller"));
            
            
        }
    }
}