using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoNode
{
    public class KinematicBody : Node
    {
        public Vector2 Velocity { get; set; }
        
        private Collider _collider;

        public KinematicBody(string name) : base(name)
        {
            
        }
        protected override void Init()
        {
            _collider = FindChildOfType<Collider>();
        }
        public Vector2 MoveAndCollide(Vector2 scaledVelocity)
        {
            LocalPosition += scaledVelocity;
            
            if (!_collider.IsEnabled) return scaledVelocity;
            
            Vector2 normalizedVelocity = Vector2.Normalize(scaledVelocity);


            foreach (Collider other in Root.GetColliders())
            {
                if (_collider == other) continue; // don't check against your own collider
                if (!other.IsEnabled) continue; // ignore disabled colliders
                
                if (_collider.CheckCollision(other, out Box overlap))
                {

                    // if the velocity is proportional to the overlapping area, we have corner-on-corner
                    // collision. So based on the proportions of the overlapping area with respect to the velocity
                    // we can deduce which side the collision occured on.
                    
                    if (overlap.Width > overlap.Height)
                    {
                        LocalPosition.Y += (overlap.Height + 0.001f) * (GlobalPosition.Y > other.GlobalPosition.Y ? 1 : -1);
                        scaledVelocity.Y = 0;
                    }

                    else
                    {
                        LocalPosition.X += (overlap.Width + 0.001f) * (GlobalPosition.X > other.GlobalPosition.X ? 1 : -1);
                        scaledVelocity.X = 0;
                    }
                        
                }
            }
            return scaledVelocity;
        }
       
    }
}