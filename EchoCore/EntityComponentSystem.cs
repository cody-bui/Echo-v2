using System;
using System.Collections.Generic;

namespace EchoCore
{
    public abstract class EntityComponentSystem
    {
        protected abstract bool OnInit();
        public abstract void OnUpdate(double timeStep);
    }
}
