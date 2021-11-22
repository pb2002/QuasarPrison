using Microsoft.Xna.Framework;
using MonoNode;

namespace QuasarPrison
{
    public class Entity : Node
    {
        protected Grid _grid;
        public Point GridPosition { get; private set; }
        public Entity(string name, Point position) : base(name)
        {
            GridPosition = position;
        }

        public void Move(int x, int y)
        {
            // Todo: check for grid boundaries
            GridPosition = new Point(GridPosition.X + x, GridPosition.Y + y);
        }

        protected override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            LocalPosition = Vector2.Lerp(LocalPosition, GridPosition.ToVector2(), dt * 20);
        }
    }
}