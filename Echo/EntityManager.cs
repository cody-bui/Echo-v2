using System;
using System.Collections.Generic;

namespace Echo
{
    public static class EntityManager
    {
        private static List<Entity> entities = new List<Entity>();

        public static Entity Add<T>() where T : Entity
        {
            Entity t = (Entity)Activator.CreateInstance(typeof(T), entities.Count);
            entities.Add(t);
            return t;
        }

        public static void Remove(int id)
        {
            if (id >= entities.Count)
            {
                Log.Warning($"{id} out of bound, delete nothing");
            }
            else
            {
                entities.RemoveAt(id);
            }
        }

        public static Entity Get(int id)
        {
            if (id >= entities.Count)
            {
                Log.Warning($"{id} out of bound, return default");
                return default;
            }
            else
            {
                return entities[id];
            }
        }
    }
}