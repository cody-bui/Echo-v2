using System;
using System.Collections.Generic;

namespace EchoCore
{
    public class ComponentManager
    {
        /// <summary>
        /// component pool
        /// </summary>
        private Dictionary<Type, List<IComponent>> components = new Dictionary<Type, List<IComponent>>();

        /// <summary>
        /// number of entities, corresponding to list_IComponent.Count
        /// </summary>
        private int size = 0;

        public T Add<T>(ref IEntity entity) where T : IComponent
        {
            Type type = typeof(T);

            // if dictionary doesn't contain the type, add it
            if (!components.ContainsKey(type))
            {
                components.Add(type, new List<IComponent>());
                for (int i = 0; i < components[type].Count; i++)
                {
                    components[type][i] = default;
                }
            }

            // check the entity id see what is the current top entity being pushed into the component manager
            // and expands the component pool with default values if needed
            if (entity.Id > size)
            {
                int expand = entity.Id - size;
                for (int i = 0; i < expand; i++)
                    foreach (var e in components)
                        e.Value.Add(default);
            }
            return default;
        }
    }
}