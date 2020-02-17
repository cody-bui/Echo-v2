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
        * when the manager receives a request from the entity, it will carry out the desired commands
        */

        /// <summary>
        /// component pool
        /// </summary>
        private Dictionary<Type, List<Component>> components = new Dictionary<Type, List<Component>>();

        /// <summary>
        /// number of entities, corresponding to list_Component.Count
        /// </summary>
        private int size = 0;

        /// <summary>
        /// add a component into an entity, may cause components dictionary expansion
        /// use 'in' keyword because you don't actually do anything to the entity itself
        /// </summary>
        /// <typeparam name="T">component type</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Component Add<T>(in Entity entity) where T : Component, new()
        {
            Type type = typeof(T);

            // if dictionary doesn't contain the type, add it
            if (!components.ContainsKey(type))
            {
                components.Add(type, new List<Component>());
                for (int i = 0; i < components[type].Count; i++)
                {
                    components[type][i] = default;
                }
            }

            // check the entity id see what is the current top entity being pushed into the component manager
            // and expand the component pool with default values if needed
            if (entity.Id > size)
            {
                int expand = entity.Id - size;
                for (int i = 0; i < expand; i++)
                    foreach (var e in components)
                        e.Value.Add(default);
            }
            size = entity.Id;
            
            // actual component creation
            components[type][entity.Id] = new T();

            return components[type][entity.Id];
        }

        /// <summary>
        /// get component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Component Get<T>(in Entity entity) where T : Component
        {
            Type type = typeof(T);

            // entity not found
            if (entity.Id > size)
            {
                Log.Warning($"entity with id ({entity.Id}) does not exist in the component pool, recommend adding it. return default");
                return default;
            }
            // component not found
            else if (!components.ContainsKey(type))
            {
                Log.Warning($"key {type.FullName} does not exist in the component pool recommend adding it. return default");
                return default;
            }
            // valid case
            else
            {
                return components[type][entity.Id];
            }
        }

        /// <summary>
        /// remove a component from an entity by setting it to default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Remove<T>(in Entity entity) where T : Component
        {
            Type type = typeof(T);

            // entity not found
            if (entity.Id > size)
            {
                Log.Warning($"entity with id ({entity.Id}) does not exist in the component pool, recommend adding it. delete nothing");
            }
            // component not found
            else if (!components.ContainsKey(type))
            {
                Log.Warning($"key {type.FullName} does not exist in the component pool recommend adding it. delete nothing");
            }
            // valid case
            else
            {
                components[type][entity.Id] = default;
            }
        }

        /// <summary>
        /// iterator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Component> Iterator<T>() where T : Component
        {
            Type type = typeof(T);

            // component not found
            if (!components.ContainsKey(type))
            {
                Log.Warning($"key {type.FullName} does not exist in the component pool, recommend adding it. return default");
                yield return default;
            }

            // looping and return non-default values
            for (int i = 0; i < components[type].Count; i++)
            {
                if (!Equals(components[type][i], default(T)))
                {
                    yield return components[type][i];
                }
            }
        }
    }
}