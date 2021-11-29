using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoNode;

namespace QuasarPrison
{
    public class Player : Entity
    {
        public int health = 100;

        public Player(string name, Point position) : base(name, position)
        {

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            bool collided = false;
            bool moved = false;
            if (InputManager.Instance.GetKeyDown(Keys.W))
            {
                collided = Move(0, -1);
                moved = true;
            }
            if (InputManager.Instance.GetKeyDown(Keys.S))
            {
                collided = Move(0, 1);
                moved = true;
            }
            if (InputManager.Instance.GetKeyDown(Keys.A))
            {
                collided = Move(-1, 0);
                moved = true;
            }
            if (InputManager.Instance.GetKeyDown(Keys.D))
            {
                collided = Move(1, 0);
                moved = true;
            }

            if (moved && !collided) InvokePlayerAction();
            //Die();
        }

        //player death function still needs a level reset function
        //public void Die()
        //{
        //    if (health <= 0)
        //        LocalPosition = Vector2.Zero;
        //
        //}

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