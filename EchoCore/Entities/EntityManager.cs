using System.Collections.Generic;

namespace EchoCore
{
    public class EntityManager<T> where T : Entity
    {
        public List<T> entities = new List<T>();
    }
}