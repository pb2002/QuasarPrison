using Microsoft.Xna.Framework;
using MonoNode;

namespace QuasarPrison
{
    public abstract class Entity : Node
    {
        public Point GridPosition { get; private set; }
        public Entity(string name, Point position) : base(name)
        {
            GridPosition = position;
        }

        public void Move(int x, int y)
        {
            var entities = ((Grid)Parent).GetEntities(new Point(x,y));
            foreach (var entity in entities)
            {
                bool isCollision;
                entity.OnInteract(this, out isCollision);
                if (isCollision) return;
            }
            GridPosition = new Point(GridPosition.X + x, GridPosition.Y + y);
        }
        public abstract void OnTurn();
        public abstract void OnInteract(Entity other, out bool isCollision);

        
        protected override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            LocalPosition = Vector2.Lerp(LocalPosition, GridPosition.ToVector2(), dt * 20);
        }
    }
}