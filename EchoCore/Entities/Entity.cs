using System.Collections.Generic;

namespace EchoCore
{
    public abstract class Entity
    {
        private static int StaticID = 0;
        public int ID
        {
            get { return ID; }
            private set { ID = StaticID++; }
        }

        private void LogEntity()
        {
            Log.Init($"init {this.GetType().Name} entity with ID: {ID}");
        }

        // add / remove entity
    }
}
