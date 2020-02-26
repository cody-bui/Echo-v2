using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echo
{
    public class EntityManager
    {
        private Dictionary<Type, EntityArray<Entity>> entities = new Dictionary<Type, EntityArray<Entity>>();
    }
}
