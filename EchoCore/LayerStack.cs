using System.Collections.Generic;

namespace EchoCore
{
    internal class LayerStack
    {
        private List<Layer> layers;

        /// <summary>
        /// add layer to the layer stack if it's not yet exist in the layer stack
        /// if exist, warn the user
        /// </summary>
        /// <param name="layer"></param>
        public void Add(ref Layer layer)
        {
            if (layers.Contains(layer))
                Log.Warning("layer already existed in the layer stack");
            else
                layers.Add(layer);
        }

        /// <summary>
        /// remove the layer from the layer stack if it exists in the layer stack
        /// if not, warn the user
        /// </summary>
        /// <param name="layer"></param>
        public void Remove(ref Layer layer)
        {
            if (layers.Contains(layer))
                layers.Remove(layer);
            else
                Log.Warning("layer doesn't exist in the layer stack");
        }

        public void PushToTop(ref Layer layer)
        {
        }
    }
}