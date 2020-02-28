using System;
using System.Collections.Generic;
using System.Reflection;

namespace Echo
{
    /* component manager explained
     * component manager takes a struct with Component attribute as generic argument
     * entity will be the index to access the data inside the component
     * components are divided into pools based on the type of entity that hold them:
     * EntityType1 | component, component, component...
       EntityType2 | component, component, component, component...
       EntityType3 | component...
     * looping by going through every component of a type then every type
     * to remove a component, replace it with the final component of the same type then remove
       that final component, same way with the entity manager -> sync up with it
    */

    public static class ComponentManager<T> where T : new()
    {
        public static Dictionary<Type, List<T>> components;

        /// <summary>
        /// check if T is a component attribute
        /// </summary>
        static ComponentManager()
        {
            Type type = typeof(T);
            if (!type.IsDefined(typeof(Component)))
            {
                Log.Error($"{type.FullName} is not a component");
                throw new ArgumentException();
            }
            else
            {
                components = new Dictionary<Type, List<T>>();
            }
        }

        /// <summary>
        /// iterator loops through every component of one entity type
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> ComponentIterator()
        {
            foreach (KeyValuePair<Type, List<T>> component in components)
                for (int m = 0; m < component.Value.Count; m++)
                    if (!component.Value[m].Equals(default))
                        yield return component.Value[m];
        }

        /// <summary>
        /// add a new component based for an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T Add(in Entity entity)
        {
            Type type = entity.GetType();

            // if type not yet existed
            if (!components.ContainsKey(type))
            {
                Log.Info($"new type of entity {type.FullName} added");
                components.Add(type, new List<T>());
            }

            T t = new T();
            components[type].Add(t);
            return t;
        }

        /// <summary>
        /// get component from specific type
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T Get(in Entity entity)
        {
            Type type = entity.GetType();

            // type does not exist
            if (!components.ContainsKey(type))
            {
                Log.Warning($"{type.FullName} not exist");
                throw new ArgumentException();
            }

            // bound check
            if (entity.Id >= components[type].Count)
            {
                Log.Warning($"{entity.Id} out of bound");
                throw new IndexOutOfRangeException();
            }

            return components[type][entity.Id];
        }

        /// <summary>
        /// remove the component by replacing it with the final component of that entity type
        /// then delete the final component
        /// </summary>
        /// <param name="entity"></param>
        public static void Remove(in Entity entity)
        {
            Type type = entity.GetType();

            // type does not exist
            if (!components.ContainsKey(type))
            {
                Log.Warning($"{type.FullName} not exist");
                throw new ArgumentException();
            }

            var cp = components[type];

            // bound check
            if (entity.Id >= cp.Count)
            {
                Log.Warning($"{entity.Id} out of bound");
                throw new IndexOutOfRangeException();
            }

            cp[entity.Id] = default;                // null it to delete it
            cp[entity.Id] = cp[cp.Count - 1];       // replace it
            cp.RemoveAt(cp.Count - 1);              // pop back
        }
    }
}