namespace Echo
{
    public abstract class EntityComponentSystem
    {
        protected abstract bool OnInit();

        public abstract void OnUpdate(double timeStep);
    }
}