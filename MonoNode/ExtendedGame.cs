using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoNode
{
    public abstract class ExtendedGame : Game
    {
        
        protected SpriteBatch SprBatch;

        public static string ContentRootDirectory => "Content";

        protected ExtendedGame()
        {
            Content.RootDirectory = ContentRootDirectory;
            _ = new AssetManager(Content);
            _ = new InputManager();
            Screen.Init(new GraphicsDeviceManager(this));
            
        }
        protected override void Initialize()
        {
            base.Initialize();
            PreInit();
        }
        /// <summary>
        /// Use this method to load your root nodes.
        /// </summary>
        protected abstract void PreInit();
        protected override void LoadContent()
        {
            SprBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
            Node.InvokeUpdate(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SprBatch.Begin(transformMatrix: Camera.Current.ViewMatrix);
            Node.InvokeDraw(gameTime, SprBatch);
            SprBatch.End();
        }


    }
}