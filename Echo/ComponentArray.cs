using System;
using System.Collections.Generic;
using System.Reflection;

namespace Echo
{
    /* component array explained

     * ComponentArray takes a struct with Component attribute as generic argument

     * entity will be the index to access the data inside the component

     * components are divided into pools based on the type of entity that hold them:
     * EntityType1 | component, component, component...
       EntityType2 | component, component, component, component...
       EntityType3 | component...

     * looping by going through every component of a type then every type

     * to remove a component, replace it with the final component of the same type then remove
       that final component, same way with the entity manager -> sync up with it
    */

    public class ComponentArray<T> where T : new()
    {
        private Dictionary<Type, List<T>> components;

        /// <summary>
        /// check if T is a component attribute
        /// </summary>
        public ComponentArray()
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
        public IEnumerable<T> ComponentIterator()
        {
            // loop through every entity of each entity type
            foreach (KeyValuePair<Type, List<T>> component in components)
                for (int m = 0; m < component.Value.Count; m++)
                    yield return component.Value[m];
        }

        /// <summary>
        /// add a new component based for an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(in Entity entity)
        {
            Type type = entity.GetType();

            // if type not yet existed
            if (!components.ContainsKey(type))
            {
                Log.Warning($"new type of entity {type.FullName} added");
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
        public T Get(in Entity entity)
        {
            Type type = entity.GetType();

            // type does not exist
            if (!components.ContainsKey(type))
            {
                Log.Warning($"{type.FullName} not exist");
                throw new ArgumentException();
            }

            // id out of bound
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
        internal void Remove(in Entity entity)
        {
            Type type = entity.GetType();

            // type does not exist
            if (!components.ContainsKey(type))
            {
                Log.Warning($"{type.FullName} not exist");
                throw new ArgumentException();
            }

            // id out of bound
            if (entity.Id >= components[type].Count)
            {
                Log.Warning($"{entity.Id} out of bound");
                throw new IndexOutOfRangeException();
            }

            // replace that entity's component with the final entity of that type
            components[type][entity.Id] = components[type][components[type].Count - 1];

            // delete the final entity's component
            components[type].RemoveAt(components[type].Count - 1);
        }
    }
}