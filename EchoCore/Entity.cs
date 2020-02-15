using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoCore
{
    public abstract class Entity
    {
        public readonly int Id;

        public Entity(int id)
        {
            Id = id;
        }
    }
}