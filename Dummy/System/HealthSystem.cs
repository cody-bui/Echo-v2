using Echo;
using Dummy.Components;
using System;
using System.Collections.Generic;
namespace Dummy.System
{
    public class HealthSystem : EntityComponentSystem
    {
        public override void OnInit()
        {
        }

        public override void OnUpdate(uint timeStep)
        {
            HealthRegen(timeStep);
        }

        public void HealthRegen(uint timeStep)
        {
        }
    }
}