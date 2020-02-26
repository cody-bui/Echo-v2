namespace Echo
{
    public abstract class EchoEngine
    {
        public abstract void OnLoad(in GameLoop game);
        public abstract void OnRenderFrame(in GameLoop game);
        public abstract void OnUpdateFrame(in GameLoop game);
        public abstract void OnUnload(in GameLoop game);
    }
}