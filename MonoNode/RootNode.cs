using System.Collections.Generic;

namespace MonoNode
{
    public class RootNode : Node
    {
        public RootNode() : base("root") { }
        public void SetAsCurrentRoot()
        {
            Node.Root = this;
        }
        private List<Collider> _colliders = new List<Collider>();

        internal void RegisterCollider(Collider collider) => _colliders.Add(collider);
        
        public Collider [] GetColliders() => _colliders.ToArray();
    }
}