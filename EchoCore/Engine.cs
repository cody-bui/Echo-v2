namespace EchoCore
{
    public abstract class Engine
    {
        /// <summary>
        /// on engine load
        /// </summary>
        /// <param name="args"></param>
        public abstract void OnLoad();

        /// <summary>
        /// on engine frame update
        /// </summary>
        /// <param name="args"></param>
        public abstract void OnUpdate();

        /// <summary>
        /// on engine unload
        /// </summary>
        /// <param name="args"></param>
        public abstract void OnUnload();
    }
}