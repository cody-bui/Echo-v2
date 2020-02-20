
namespace Echo
{
    public abstract class Engine
    {
        /// <summary>
        /// call when the engine program is initiailzed
        /// </summary>
        public abstract void OnLoad();

        /// <summary>
        /// call before the frame is rendered
        /// </summary>
        public abstract void OnRender();

        /// <summary>
        /// call before the frame is updated
        /// </summary>
        public abstract void OnUpdate();

        /// <summary>
        /// call when the engine program is completed
        /// </summary>
        public abstract void OnUnload();
    }
}