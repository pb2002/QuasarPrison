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