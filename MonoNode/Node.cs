using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoNode
{
    public class Node
    {
        private static RootNode _root;
        public static RootNode Root
        {
            get => _root ?? throw new Exception("Root node accessed before assignment, did you forget to set the root node in initialization?");
            set => _root = value;
        }
        
        public static event Action<GameTime> OnUpdate;
        public static event Action<GameTime, SpriteBatch> OnDraw;

        public Vector2 LocalPosition;
        public Vector2 GlobalPosition => Parent?.GlobalPosition + LocalPosition ?? LocalPosition;

        public readonly string Name; 
        public Node Parent { get; protected set; }

        public bool IsEnabled { get; private set; } = true;

        private bool _initialized;
        
        public void SetActive(bool active)
        {
            if (active == IsEnabled) return;

            IsEnabled = active;
            if (active)
                OnEnable();
            else 
                OnDisable();
            
        }

        protected List<Node> Children = new List<Node>();
        
        public Node(string name)
        {
            Name = name;
            OnUpdate += _ =>
            {
                if (_initialized) return;

                Init();
                _initialized = true;
            };
            OnUpdate += Update;
            OnDraw += Draw;
        }

        protected virtual void OnEnable()
        {
            OnUpdate += Update;
            OnDraw += Draw;
        }
        protected virtual void OnDisable()
        {
            OnUpdate -= Update;
            OnDraw -= Draw;
        }

        protected virtual void Init()
        {
            
        }
        protected virtual void Update(GameTime gameTime)
        {
            
        }
        protected virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }

        public void Destroy()
        {
            Parent?.RemoveChild(this);
            SetActive(false);
        }
        
        
        public void AddChild(Node child)
        {
            if (Children.Contains(child)) return;
            Children.Add(child);
            child.Parent = this;
        }
        public void RemoveChild(Node child)
        {
            if (!Children.Contains(child)) return;
            Children.Remove(child);
            child.Parent = null;
        }
        public Node FindChild(string name)
        {
            foreach (Node child in Children)
            {
                if (child.Name == name) return child;

                Node c = child.FindChild(name);
                if (c != null) return c;
            }
            return null;
        }
        
        public T FindChildOfType<T>() where T : Node
        {
            foreach (Node child in Children)
            {
                if (child is T node) return node;

                var c = child.FindChildOfType<T>();
                if (c != null) return c;
            }
            return null;
        }
        
        public bool FindChildrenOfType<T>(out List<T> result) where T : Node
        {
            result = new List<T>();
            foreach (Node child in Children)
            {
                if (child is T node)
                {
                    result.Add(node);
                }
            }
            return result.Count > 0;
        }
        public static void InvokeUpdate(GameTime gameTime)
        {
            OnUpdate?.Invoke(gameTime);
        }
        public static void InvokeDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            OnDraw?.Invoke(gameTime, spriteBatch);
        }
    }
}