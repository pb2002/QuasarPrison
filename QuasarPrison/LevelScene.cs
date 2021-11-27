using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoNode;

namespace QuasarPrison
{
    public class LevelScene : RootNode
    {


        public static readonly int levelWidth = 12, levelHeight = 8;
        
        public LevelScene()
        {
            var cam = new Camera("camera", 10);
            cam.SetAsCurrent();
            // initialize your scene here
            var placeholder = new SpriteSheet("test-thing");
            
            var grid = new Grid("grid", levelWidth, levelHeight);
            AddChild(grid);
            
            var player = new Player("player", Point.Zero);
            player.AddChild(new SpriteNode("player-sprite", placeholder));
            grid.AddEntity(player);
            
            
        }
        protected override void Update(GameTime gameTime)
        {
            
        }
    }
}