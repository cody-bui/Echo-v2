using System;

namespace Echo
{
    public abstract class Entity
    {
        public int Id { get; set; }

        /*
         * WARNING: this is not the idisposable interface, it just work similar to it
         * 
         * it's only used to force remove its components in the component manager
         * this is to ensure that its components will be removed from the component manager,
         * but whether the components are actually destroyed is not ensured
         * 
         * GC will still be called
         */
        protected bool disposed = false;
        public abstract void Dispose();
    }
}