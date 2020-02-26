using System;
using System.Collections.Generic;

namespace Echo
{
    /* entity manager explained
     * entity manager takes in an entity class as generic argument
     * to remove an entity, replace it with the final entity in the list
     * this in turn, calls the component managers to replace the components the same way
    */

    public static class EntityManager<T> where T : Entity
    {
        private static List<T> entities = new List<T>();

        /// <summary>
        /// to iterate through every entity
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> EntityIterator()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                yield return entities[i];
            }
        }

        /// <summary>
        /// add new enitty
        /// </summary>
        /// <returns></returns>
        public static T Add()
        {
            T t = (T)Activator.CreateInstance(typeof(T), entities.Count);
            entities.Add(t);
            return t;
        }

        /// <summary>
        /// remove and entity by replacing the last entity with it and delete the last one
        /// also delete the components attached to it
        /// </summary>
        /// <param name="id"></param>
        public static void Remove(int id)
        {
            if (id >= entities.Count)
            {
                Log.Warning($"{id} out of bound");
                throw new IndexOutOfRangeException();
            }
            else
            {
            }
        }

        /// <summary>
        /// return an entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Get(int id)
        {
            if (id >= entities.Count)
            {
                Log.Warning($"{id} out of bound");
                throw new IndexOutOfRangeException();
            }
            else
            {
                return entities[id];
            }
        }
    }
}