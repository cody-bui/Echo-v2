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
        private Dictionary<Type, List<(int, Component)>> components = new Dictionary<Type, List<(int, Component)>>();

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
                components.Add(type, new List<(int, Component)>());
            }

            // actual component creation
            components[type].Add((entity.Id, new T()));

            return components[type][components[type].Count - 1].Item2;
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

            // component not found
            if (!components.ContainsKey(type))
            {
                Log.Warning($"key {type.FullName} not found. return default");
            }
            // valid case
            else
            {
                for (int i = 0; i < components[type].Count; i++)
                    if (components[type][i].Item1 == entity.Id)
                        return components[type][i].Item2;

                Log.Warning($"entity id {entity.Id} not found. return default");
            }
            return default;
        }

        /// <summary>
        /// remove a component from an entity by setting it to default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Remove<T>(in Entity entity) where T : Component
        {
            Type type = typeof(T);

            // component not found
            if (!components.ContainsKey(type))
            {
                Log.Warning($"key {type.FullName} not found. delete nothing");
            }
            // valid case
            else
            {
                for (int i = 0; i < components[type].Count; i++)
                {
                    if (components[type][i].Item1 == entity.Id)
                    {
                        components[type].RemoveAt(i);
                        return;
                    }
                }
                Log.Warning($"entity id {entity.Id} not found. delete nothing");
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
                Log.Warning($"key {type.FullName} not found. yield return default");
                yield return default;
            }

            // looping and return non-default values
            for (int i = 0; i < components[type].Count; i++)
                yield return components[type][i].Item2;
        }
    }
}