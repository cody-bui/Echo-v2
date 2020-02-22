using System;
using Echo; 

namespace Dummy.Components
{
    public class HealthComponent : Component
    {
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
        public float RegenRate { get; set; }
    }
}
