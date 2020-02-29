using Dummy.Components;
using Echo;

namespace Dummy.Entities
{
    public class Player : Entity
    {
        public Player()
        {
            ComponentManager<TransformComponent>.Add(this);
            ComponentManager<HealthComponent>.Add(this);
        }

        public override void Dispose()
        {
            if (!disposed)
            {
                ComponentManager<TransformComponent>.Remove(this);
                ComponentManager<HealthComponent>.Remove(this);

                disposed = true;
            }
        }
    }
}