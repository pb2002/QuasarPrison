using System;

namespace MonoNode
{
    public class UninitializedSingletonException : Exception
    {
        public UninitializedSingletonException() : base("Singleton referenced before initialization.", new NullReferenceException())
        {
            
        }
    }
}