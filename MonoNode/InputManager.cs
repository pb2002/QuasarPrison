using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace MonoNode
{
    public class InputManager
    {
        // Singleton
        private static InputManager _instance;
        public static InputManager Instance => _instance ?? throw new UninitializedSingletonException();
        // ------------------------------------------------------------------
        public Point MousePosition => _currentMouseState.Position;
        public Vector2 WorldMousePosition => Camera.Current.ScreenToWorldSpace(_currentMouseState.Position);
        public Point MouseDeltaPosition => _currentMouseState.Position - _previousMouseState.Position;
        public int MouseScroll => _currentMouseState.ScrollWheelValue - _previousMouseState.ScrollWheelValue;
        
        private KeyboardState _currentKeyboardState, _previousKeyboardState;
        private MouseState _currentMouseState, _previousMouseState;
        
        public InputManager()
        {
            _instance = this;
        }
        
        #region GetKey Methods
        
        /// <summary>
        /// Is the given key currently being held down?
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>Whether or not this key is currently being held down.</returns>
        public bool GetKey(Keys key) => _currentKeyboardState.IsKeyDown(key);
        
        /// <summary>
        /// Was the given key pressed this frame?
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>Whether or not this key was pressed this frame.</returns>
        public bool GetKeyDown(Keys key) => _currentKeyboardState.IsKeyDown(key) && !_previousKeyboardState.IsKeyDown(key);
        
        /// <summary>
        /// Was the given key released this frame?
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>Whether or not this key was released this frame.</returns>
        public bool GetKeyUp(Keys key) => !_currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyDown(key);
        
        #endregion
        
        #region GetMouseButton Methods
        
        /// <summary>
        /// Is the given mouse button currently being held down?
        /// </summary>
        /// <param name="button">The index of the mouse button. 0: left, 1: right, 2: middle</param>
        /// <returns>Whether or not this mouse button is currently being held down.</returns>
        public bool GetMouseButton(int button) => button switch
        {
            0 => _currentMouseState.LeftButton == ButtonState.Pressed,
            1 => _currentMouseState.RightButton == ButtonState.Pressed,
            2 => _currentMouseState.MiddleButton == ButtonState.Pressed,
            _ => false
        };
        
        /// <summary>
        /// Was the given mouse button pressed this frame?
        /// </summary>
        /// <param name="button">The index of the mouse button. 0: left, 1: right, 2: middle</param>
        /// <returns>Whether or not this mouse button was pressed this frame.</returns>
        public bool GetMouseButtonDown(int button) => button switch
        {
            0 => _currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton != ButtonState.Pressed,
            1 => _currentMouseState.RightButton == ButtonState.Pressed && _previousMouseState.RightButton != ButtonState.Pressed,
            2 => _currentMouseState.MiddleButton == ButtonState.Pressed && _previousMouseState.MiddleButton != ButtonState.Pressed,
            _ => false
        };
        
        /// <summary>
        /// Was the given mouse button released this frame?
        /// </summary>
        /// <param name="button">The index of the mouse button. 0: left, 1: right, 2: middle</param>
        /// <returns>Whether or not this mouse button was released this frame.</returns>
        public bool GetMouseButtonUp(int button) => button switch
        {
            0 => _currentMouseState.LeftButton != ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Pressed,
            1 => _currentMouseState.RightButton != ButtonState.Pressed && _previousMouseState.RightButton == ButtonState.Pressed,
            2 => _currentMouseState.MiddleButton != ButtonState.Pressed && _previousMouseState.MiddleButton == ButtonState.Pressed,
            _ => false
        };
        
        #endregion
        
        public void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
            
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
        }
    }
}