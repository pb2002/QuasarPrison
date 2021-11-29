using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoNode;

namespace QuasarPrison
{
    class Enemy : Entity
    {
        // edit: remember to stick to official C# naming convention!
        // - private fields: _nameOfMember
        // - public / protected fields: NameOfMember
        // - methods: NameOfMember
        private bool _detected = false;

        private int _spottingRange = 5;
        private int _shootingRange = 3;
        private int _damage = 20;
        
        public Enemy(string name, Point position) : base(name, position)
        {
            
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
            LevelScene.player.health -= _damage;
        }

        public override void OnTurn()
        {
            if (InRange(GridPosition, LevelScene.player.GridPosition, _spottingRange))
            {
                _detected = true;
            }
            
            if (!InRange(GridPosition, LevelScene.player.GridPosition, _shootingRange))
                MoveToCordinate(GridPosition, LevelScene.player.GridPosition);

            if (InRange(GridPosition, LevelScene.player.GridPosition, _shootingRange))
                Shoot();
        }
        public override void OnInteract(Entity other, out bool isCollision)
        {
            isCollision = true;
            return;
        }
    }
}
