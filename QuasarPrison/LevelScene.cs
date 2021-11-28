using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoNode;

namespace QuasarPrison
{
   

    public class LevelScene : RootNode
    {
        public static Player player = new Player("player", Point.Zero);

        public static readonly int levelWidth = 12, levelHeight = 8;
        
        public static Point enemypos = new Point (10, 5);


        public LevelScene()
        {
            var cam = new Camera("camera", 10);
            cam.SetAsCurrent();
            // initialize your scene here
            var placeholder = AssetManager.Instance.LoadSprite("test-thing");

            var grid = new Grid("grid", levelWidth, levelHeight);
            AddChild(grid);
           
            var enemy = new Enemy("enemy", enemypos);

            player.AddChild(new SpriteNode("player-sprite", placeholder));
            enemy.AddChild(new SpriteNode("enemy_sprite", placeholder));
            grid.AddEntity(enemy);
            grid.AddEntity(player);
            
            
        }
        protected override void Update(GameTime gameTime)
        {
            
        }
    }
}