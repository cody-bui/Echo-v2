namespace Echo
{
    public abstract class EchoEngine
    {
        public abstract void OnLoad(in Game game);

        public abstract void OnRender(in Game game);

        public abstract void OnUpdate(in Game game);

        public abstract void OnUnload(in Game game);
    }
}