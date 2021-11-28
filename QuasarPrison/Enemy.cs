using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoNode;

namespace QuasarPrison
{
    class Enemy : Entity
    {
        bool detected = false;

        int spottingRange = 5;
        int shootingRange = 3;
        int damage = 20;
        
        public Enemy(string name, Point position) : base(name, position)
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (InRange(GridPosition, LevelScene.player.GridPosition, spottingRange))
            {
                detected = true;

            }

            if ((InputManager.Instance.GetKeyDown(Keys.W) || InputManager.Instance.GetKeyDown(Keys.S) || InputManager.Instance.GetKeyDown(Keys.A) || InputManager.Instance.GetKeyDown(Keys.D)) && detected)
            {
                if (!InRange(GridPosition, LevelScene.player.GridPosition, shootingRange))
                    MoveToCordinate(GridPosition, LevelScene.player.GridPosition);

                if (InRange(GridPosition, LevelScene.player.GridPosition, shootingRange))
                    Shoot();
            }

        }

        public void MoveToCordinate(Point location, Point goal)
        {
            Point direction = goal - location;

            if (direction.X > 0 && direction.X > direction.Y && direction.X > -direction.Y)
                Move(1, 0);
            else if (direction.X < 0 && direction.X < direction.Y && direction.X < -direction.Y)
                Move(-1, 0);
            else if (direction.Y > 0)
                Move(0, 1);
            else if (direction.Y < 0)
                Move(0, -1);
        }

        public bool InRange(Point location, Point player, int range)
        {
            Point direction = player - location;
            if (direction.X < 0)
                direction.X = -direction.X;
            if (direction.Y < 0)
                direction.Y = -direction.Y;


            if (direction.X + direction.Y <= range)
                return true;
            else 
                return false;

        }

        public void Shoot()
        {
            LevelScene.player.health -= damage;

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
