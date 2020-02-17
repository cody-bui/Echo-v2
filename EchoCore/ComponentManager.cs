using System;
using System.Collections.Generic;

namespace EchoCore
{
    public class ComponentManager
    {
        /* component manager memory layout explained
        * basically a giant 2d array
        * when a new component type is added, it expands the dictionary and creates an empty list
        * when a entity with larger id is added, it extends every list
        * just look at the diagram
        Dictionary
        {
            IComponentDerived0: {Entity0, Entity1, Entity2... EntityN}
            IComponentDerived1: {Entity0, Entity1, Entity2... EntityN}
            IComponentDerived2: {Entity0, Entity1, Entity2... EntityN}
            ...
            (most EntityX are default / null)
        }
        */

        /// <summary>
        /// component pool
        /// </summary>
        public Dictionary<Type, List<Component>> Components { get; private set; }

        /// <summary>
        /// number of entities, corresponding to list_Component.Count
        /// </summary>
        private int size = 0;

        public ComponentManager()
        {
            Components = new Dictionary<Type, List<Component>>();
        }

        /// <summary>
        /// add a component into an entity, may cause Components dictionary expansion
        /// </summary>
        /// <typeparam name="T">component type</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add<T>(ref Entity entity) where T : Component, new()
        {
            Type type = typeof(T);

            // if dictionary doesn't contain the type, add it
            if (!Components.ContainsKey(type))
            {
                Components.Add(type, new List<Component>());
                for (int i = 0; i < Components[type].Count; i++)
                {
                    Components[type][i] = default;
                }
            }

            // check the entity id see what is the current top entity being pushed into the component manager
            // and expand the component pool with default values if needed
            if (entity.Id > size)
            {
                int expand = entity.Id - size;
                for (int i = 0; i < expand; i++)
                    foreach (var e in Components)
                        e.Value.Add(default);
            }
            size = entity.Id;
            
            // actual component creation
            Components[type][entity.Id] = new T();

            return (T)Components[type][entity.Id];
        }

        /// <summary>
        /// get component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Get<T>(ref Entity entity) where T : Component
        {
            Type type = typeof(T);

            // entity not found
            if (entity.Id > size)
            {
                Log.Warning($"entity with id ({entity.Id}) does not exist in the component pool, recommend adding it. return default");
                return default;
            }
            // component not found
            else if (!Components.ContainsKey(type))
            {
                Log.Warning($"key {type} does not exist in the component pool recommend adding it. return default");
                return default;
            }
            // valid case
            else
            {
                return (T)Components[type][entity.Id];
            }
        }

        /// <summary>
        /// remove a component from an entity by setting it to default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Remove<T>(ref Entity entity) where T : Component
        {
            Type type = typeof(T);

            // entity not found
            if (entity.Id > size)
            {
                Log.Warning($"entity with id ({entity.Id}) does not exist in the component pool, recommend adding it. delete nothing");
            }
            // component not found
            else if (!Components.ContainsKey(type))
            {
                Log.Warning($"key {type} does not exist in the component pool recommend adding it. delete nothing");
            }
            // valid case
            else
            {
                Components[type][entity.Id] = default;
            }
        }
    }
}