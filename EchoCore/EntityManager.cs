using System;
using System.Collections.Generic;

namespace EchoCore
{
    public static class EntityManager
    {
        private static int StaticId = 0;
        private static List<IEntity> entities = new List<IEntity>();
        
        /// <summary>
        /// create a new entity
        /// </summary>
        /// <typeparam name="T">inherited from Entity class</typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : IEntity
        {
            T t = (T)Activator.CreateInstance(typeof(T), StaticId++);
            entities.Add(t);
            return t;
        }

        /// <summary>
        /// destroy an entity based on it's id
        /// </summary>
        /// <param name="id"></param>
        public static void Destroy(int id)
        {
            foreach (IEntity e in entities)
            {
                if (e.Id == id)
                {
                    entities.Remove(e);
                    return;
                }
            }
            Log.Warning($"entity with id {id} not found, nothing will be deleted");
        }

        /// <summary>
        /// get an entity based on its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEntity Get(int id)
        {
            foreach (IEntity e in entities)
                if (e.Id == id)
                    return e;
            Log.Warning($"entity with id {id} not found, return default");
            return default;
        }
    }
}
