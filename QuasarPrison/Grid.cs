using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoNode;

namespace QuasarPrison
{
    public class Grid : Node
    {
        private static Grid _instance;
        public static Grid Instance => _instance ?? throw new UninitializedSingletonException();
        
        public event Action OnTurn;
        
        public int Width { get; }
        public int Height { get; }
        public Grid(string name, int width, int height) : base(name)
        {
            Width = width;
            Height = height;
            
            _instance = this;
        }
        public void AddEntity(Entity entity)
        {
            AddChild(entity);
            OnTurn += entity.OnTurn;
        }
        public void InvokeTurn()
        {
            OnTurn?.Invoke();
        }
        public List<Entity> GetEntities(Point position)
        {
            var result = new List<Entity>();
            if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height) return result;
            foreach (Node node in Children)
            {
                var entity = (Entity)node;
                if (entity.GridPosition == position) result.Add(entity);
            }
            return result;
        }
    }
}