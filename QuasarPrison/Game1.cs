using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoNode;

namespace QuasarPrison
{
    public class Game1 : ExtendedGame
    {
        public Game1()
        {
            IsMouseVisible = true;
        }
        protected override void PreInit()
        {
            Node.Root = new LevelScene();
            
        }
    }
}