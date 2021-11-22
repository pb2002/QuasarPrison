using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoNode
{
    /// <summary>
    /// Handles asset loading
    /// </summary>
    public class AssetManager
    {
        private static AssetManager _instance;
        public static AssetManager Instance => _instance ?? throw new UninitializedSingletonException();
        
        private ContentManager _contentManager;
        
        public AssetManager(ContentManager content)
        {
            _contentManager = content;
            _instance = this;
        }
        
        /// <summary>
        /// Loads a sprite with the given asset name
        /// </summary>
        public Texture2D LoadSprite(string assetName)
        {
            return _contentManager.Load<Texture2D>(assetName);
        }

        /// <summary>
        /// Loads a font with the given asset name
        /// </summary>
        public SpriteFont LoadFont(string assetName)
        {
            return _contentManager.Load<SpriteFont>(assetName);
        }
        
        
    }
}