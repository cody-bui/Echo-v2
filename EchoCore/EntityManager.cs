using System;
using System.Collections.Generic;

namespace EchoCore
{
    public static class EntityManager
    {
        private static int StaticId = 0;

        private static Dictionary<string, List<IEntity>> entities = new Dictionary<string, List<IEntity>>();

        /// <summary>
        /// create a new entity of a specific type
        /// may allocate a new entity pool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Add<T>() where T : IEntity
        {
            var type = typeof(T);

            // create new entity pool if it's not yet existed
            if (!entities.ContainsKey(type.FullName))
            {
                Log.Init($"new entity pool type {type.FullName}");
                entities.Add(type.FullName, new List<IEntity>());
            }

            // create new T
            T t = (T)Activator.CreateInstance(type, StaticId++);
            entities[type.FullName].Add(t);
            return t;
        }

        /// <summary>
        /// remove an entity based on it's id by checking every pool
        /// riskier since may remove entity of unwanted type
        /// </summary>
        /// <param name="id"></param>
        public static void Remove(int id)
        {
            foreach (var entry in entities)             // iterate through dictionary
            {
                foreach (var entity in entry.Value)     // iterate through list
                {
                    if (entity.Id == id)                // compare id
                    {
                        entities[entry.Key].Remove(entity);
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
        public static void Remove<T>(int id) where T : IEntity
        {
            var type = typeof(T);
            if (entities.ContainsKey(type.FullName))            // if entity pool of such type exists
            {
                foreach (var entity in entities[type.FullName])  // iterate through entire list
                {
                    if (entity.Id == id)
                    {
                        entities[type.FullName].Remove(entity);
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
        public static IEntity Get(int id)
        {
            foreach (var entry in entities)             // iterate through dictionary
            {
                foreach (var entity in entry.Value)     // iterate through list
                {
                    if (entity.Id == id)                // compare id
                    {
                        Log.Delete($"return entity type {entry.Key}");
                        return entity;
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
        public static IEntity Get<T>(int id) where T : IEntity
        {
            var type = typeof(T);
            if (entities.ContainsKey(type.FullName))            // if entity pool of such type exists
            {
                foreach (var entity in entities[type.FullName]) // iterate through entire list
                {
                    if (entity.Id == id)
                    {
                        return entity;
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