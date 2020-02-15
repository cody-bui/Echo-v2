using System;

namespace EchoCore
{
    public interface Engine
    {
        /// <summary>
        /// on engine load
        /// </summary>
        /// <param name="args"></param>
        void OnLoad();

        /// <summary>
        /// on engine frame update
        /// </summary>
        /// <param name="args"></param>
        void OnUpdate();

        /// <summary>
        /// on engine unload
        /// </summary>
        /// <param name="args"></param>
        void OnUnload();
    }
}
