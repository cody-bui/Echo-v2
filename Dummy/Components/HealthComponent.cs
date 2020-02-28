using Echo;

namespace Dummy.Components
{
    [Component]
    public class HealthComponent
    {
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        public float RegenRate { get; set; }
    }
}