using System;
using System.Collections.Generic;

namespace Echo
{
    public class EntityManager
    {
        /* component manager memory layout explained
        * entities: a dictionary that maps list of IEntity to it's 'type'
        * type is the entity class inherited from IEntity
        * when a new entity of a new type is added, it maps a new list to that type
        * when a new entity of an existing type is added, it just add that into the right list
        * diagram:
        Dictionary
        {
            IEntityDerived0: {Entity0, Entity1, Entity3, Entity9...}
            IEntityDerived1: {Entity2, Entity4, Entity5...}
            IEntityDerived2: {...}
            ...
        }
        * when the engine requests the engine manager to create a new entity, that entity
          will request the component manager to allocate the components to it as desired
          (components might also be added or removed from an entity during run-time)
        */

        private static int StaticId = 0;

        /// <summary>
        /// entity pool
        /// </summary>
        private Dictionary<Type, List<Entity>> entities = new Dictionary<Type, List<Entity>>();

        /// <summary>
        /// create a new entity of a specific type
        /// may allocate a new entity pool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Add<T>() where T : Entity
        {
            Type type = typeof(T);

            // create new entity pool if it's not yet existed
            if (!entities.ContainsKey(type))
            {
                Log.Init($"new entity pool type {type.FullName}");
                entities.Add(type, new List<Entity>());
            }

            // create new T
            T t = (T)Activator.CreateInstance(type, StaticId++);
            entities[type].Add(t);
            return t;
        }

        /// <summary>
        /// remove an entity based on it's id by checking every pool
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            foreach (var entry in entities)
            {
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    if (entry.Value[i].Id == id)
                    {
                        entities[entry.Key].RemoveAt(i);
                        return;
                    }
                }
            }
            Log.Warning($"no entity with such id ({id}) found, remove nothing");
        }

        /// <summary>
        /// get an entity based on it's id by checking every pool
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity Get(int id)
        {
            foreach (var entry in entities)
            {
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    if (entry.Value[i].Id == id)
                    {
                        return entry.Value[i];
                    }
                }
            }
            Log.Warning($"no entity with such id ({id}) found, return default");
            return default;
        }
    }
}