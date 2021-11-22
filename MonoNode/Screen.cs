using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoNode
{
    public static class Screen
    {
        private static Point _windowedResolution = new Point(1280, 720);
        
        public static bool FullScreen { get; private set; } 
        public static Point Resolution { get; private set; } = _windowedResolution;
        public static int Width => Resolution.X;
        public static int Height => Resolution.Y;

        public static GraphicsDeviceManager Graphics { get; private set; }

        public static void SetFullscreen(bool fullscreen)
        {
            FullScreen = fullscreen;
            ApplyResolutionSettings();
        }
        public static void Init(GraphicsDeviceManager graphics)
        {
            Graphics = graphics;
            ApplyResolutionSettings();
        }
        public static void SetResolution(int width, int height)
        {
            _windowedResolution = new Point(width, height);
            ApplyResolutionSettings();
        }
        
        static void ApplyResolutionSettings()
        {
            // make the game full-screen or not
            Graphics.IsFullScreen = FullScreen;

            // get the size of the screen to use: either the window size or the full screen size
            Resolution = FullScreen 
                ? new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height) 
                : new Point(_windowedResolution.X, _windowedResolution.Y);

            // scale the window to the desired size
            Graphics.PreferredBackBufferWidth = Resolution.X;
            Graphics.PreferredBackBufferHeight = Resolution.Y;
            Graphics.ApplyChanges();
        }
    }
}