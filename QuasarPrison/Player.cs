using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoNode;

namespace QuasarPrison
{
    public class Player : Entity
    {
        public Player(string name, Point position) : base(name, position)
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (InputManager.Instance.GetKeyDown(Keys.W))
            {
                Move(0, -1);
            }
            if (InputManager.Instance.GetKeyDown(Keys.S))
            {
                Move(0, 1);
            }
            if (InputManager.Instance.GetKeyDown(Keys.A))
            {
                Move(-1, 0);
            }
            if (InputManager.Instance.GetKeyDown(Keys.D))
            {
                Move(1, 0);
            }
        }
        public override void OnTurn()
        {
            
        }
        public override void OnInteract(Entity other, out bool isCollision)
        {
            isCollision = true;
            return;
        }
    }
}