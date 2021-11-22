using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoNode;

namespace QuasarPrison
{
    public class PlayerController : Node
    {
        private Entity _entity;
        public PlayerController(string name) : base(name)
        {
            
        }
        protected override void Init()
        {
            _entity = (Entity)Parent;
        }
        protected override void Update(GameTime gameTime)
        {
            if (InputManager.Instance.GetKey(Keys.W))
            {
                _entity.Move(0,-1);
                
            }
        }
    }
}