using System.Collections.Generic;

namespace EchoCore
{
    public abstract class Entity
    {
        private static int StaticID = 0;
        public int ID
        {
            get { return ID; }
            private set { ID = StaticID++; }
        }

        /// <summary>
        /// add a new component into it's component list
        /// </summary>
        /// <param name="component">ref to it's component list</param>
        public abstract void Add(ref List<Component> component);

        /// <summary>
        /// remove a component from it's component list
        /// </summary>
        /// <param name="component">ref to it's component list</param>
        /// <param name="remove">component to be removed</param>
        public abstract void Remove(ref List<Component> component, Component remove);
    }
}
