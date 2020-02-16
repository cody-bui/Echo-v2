using System;
using System.Collections.Generic;

namespace EchoCore
{
    /// <summary>
    /// i know this should either be static or a singleton, but come on, be reasonable
    /// create one instance only
    /// </summary>
    public class EntityManager
    {
        private static int StaticId = 0;

        /// <summary>
        /// entity pool
        /// </summary>
        private Dictionary<Type, List<IEntity>> entities = new Dictionary<Type, List<IEntity>>();

        /// <summary>
        /// create a new entity of a specific type
        /// may allocate a new entity pool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Add<T>() where T : IEntity
        {
            Type type = typeof(T);

            // create new entity pool if it's not yet existed
            if (!entities.ContainsKey(type))
            {
                Log.Init($"new entity pool type {type.FullName}");
                entities.Add(type, new List<IEntity>());
            }

            // create new T
            T t = (T)Activator.CreateInstance(type, StaticId++);
            entities[type].Add(t);
            return t;
        }

        /// <summary>
        /// remove an entity based on it's id by checking every pool
        /// riskier since may remove entity of unwanted type
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
                        Log.Delete($"delete entity type {entry.Key}");
                        return;
                    }
                }
            }
            Log.Warning($"no entity with such id ({id}) found, remove nothing");
        }

        /// <summary>
        /// remove an entity based on it's type and id
        /// safer since only remove entity from the specific type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public void Remove<T>(int id) where T : IEntity
        {
            var type = typeof(T);
            if (entities.ContainsKey(type))             // if entity pool of such type exists
            {
                for (int i = 0; i < entities[type].Count; i++)  // iterate through entire list
                {
                    if (entities[type][i].Id == id)
                    {
                        entities[type].RemoveAt(i);
                        return;
                    }
                }
                Log.Warning($"entity with id ({id}) cannot be found in {type.FullName}. remove nothing");
            }
            else
            {
                Log.Warning($"cannot find {type.FullName} entity type, remove nothing");
            }
        }

        /// <summary>
        /// get an entity based on it's id by checking every pool
        /// riskier since may get entiy from unwanted type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEntity Get(int id)
        {
            foreach (var entry in entities)
            {
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    if (entry.Value[i].Id == id)
                    {
                        Log.Delete($"return entity type {entry.Key}");
                        return entry.Value[i];
                    }
                }
            }
            Log.Warning($"no entity with such id ({id}) found, return default");
            return default;
        }

        /// <summary>
        /// get entity based on it's id and type
        /// will always get the right type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEntity Get<T>(int id) where T : IEntity
        {
            var type = typeof(T);
            if (entities.ContainsKey(type))
            {
                for (int i = 0; i < entities[type].Count; i++)
                {
                    if (entities[type][i].Id == id)
                    {
                        return entities[type][i];
                    }
                }
                Log.Warning($"entity with id ({id}) cannot be found in {type.FullName}. return default");
            }
            else
            {
                Log.Warning($"cannot find {type.FullName} entity type, return default");
            }
            return default;
        }
    }
}