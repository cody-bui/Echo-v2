namespace Echo
{
    public abstract class EntityComponentSystem
    {
        public abstract void OnInit();
        public abstract void OnUpdate(uint timeStep);
    }
}