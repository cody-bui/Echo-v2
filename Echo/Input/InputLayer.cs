using System.Collections.Generic;

namespace Echo.Input
{
    public class InputLayer
    {
        /// <summary>
        /// * warning: only the top input layer will receive the callback input
        /// other layers will be ignored until it's pushed to the top
        /// * warning 2: input fires or not depends on the input method implementation
        /// input layer will simply set the InputMethod.Enabled property to false
        /// by calling Input.Enable / Input.Disable function
        /// </summary>
        private List<(string, Input)> layers = new List<(string, Input)>();

        /// <summary>
        /// load all inputs
        /// </summary>
        /// <param name="game"></param>
        public void OnLoad(in GameLoop game)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].Item2.OnLoad(game);
            }
        }

        /// <summary>
        /// unload all inputs
        /// </summary>
        /// <param name="game"></param>
        public void OnUnload(in GameLoop game)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].Item2.OnUnload(game);
            }
        }

        /// <summary>
        /// add input layer to the back
        /// </summary>
        /// <param name="name"></param>
        /// <param name="layer"></param>
        public void Add(in string name, Input layer)
        {
            // check for duplicate and only add if not
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Item1 == name)
                {
                    Log.Warning($"input layer {name} already existed, nothing is added");
                    break;
                }
            }
            layers.Add((name, layer));

            // disable input (enable if top layer)
            if (layers.Count > 1)
                layers[layers.Count - 1].Item2.Disable();
            else
                layers[0].Item2.Enable();
        }

        /// <summary>
        /// add input layer to the top (active layer)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="layer"></param>
        public void AddTop(in string name, Input layer)
        {
            // check for duplicate and only add if not
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Item1 == name)
                {
                    Log.Warning($"input layer {name} already existed, nothing is added");
                    break;
                }
            }
            layers.Insert(0, (name, layer));

            // enable top layer
            layers[0].Item2.Enable();

            // disable second layer
            if (layers.Count > 1)
                layers[1].Item2.Disable();
        }

        /// <summary>
        /// remove input layer
        /// </summary>
        /// <param name="name"></param>
        /// <param name="layer"></param>
        public void Remove(in string name)
        {
            // find the layer and delete it
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Item1 == name)
                {
                    // enable the next input layer if the top layer is deleted and there is the next layer
                    if (i == 0 && layers.Count > 1)
                        layers[1].Item2.Enable();

                    layers.RemoveAt(i);
                    return;
                }
            }
            Log.Warning($"input layer {name} does not exist, delete nothing");
        }

        /// <summary>
        /// remove top (active) input layer
        /// </summary>
        public void RemoveTop()
        {
            layers.RemoveAt(0);

            if (layers.Count > 0)
                layers[0].Item2.Enable();
        }

        /// <summary>
        /// get input layer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Input Get(in string name)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Item1 == name)
                {
                    return layers[i].Item2;
                }
            }
            Log.Warning($"input layer {name} does not exist, return default");
            return default;
        }

        /// <summary>
        /// get the top (active) input layer
        /// </summary>
        /// <returns></returns>
        public Input GetTop()
        {
            if (layers.Count > 0)
            {
                return layers[0].Item2;
            }
            else
            {
                Log.Warning("no input layer found, return default");
                return default;
            }
        }

        /// <summary>
        /// get the top (active) input layer name
        /// </summary>
        /// <returns></returns>
        public string GetTopName()
        {
            if (layers.Count > 0)
            {
                return layers[0].Item1;
            }
            else
            {
                Log.Warning("no input layer found, return default");
                return default;
            }
        }

        /// <summary>
        /// push a layer to the top
        /// </summary>
        /// <param name="name"></param>
        public void PushTop(in string name)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Item1 == name)
                {
                    // copy the layer, delete it and add the copy to the front
                    (string, Input) temp = layers[i];
                    layers.RemoveAt(i);
                    layers.Insert(0, temp);
                    layers[0].Item2.Enable();

                    // disable the next layer if exist
                    if (layers.Count > 1)
                        layers[1].Item2.Disable();

                    return;
                }
            }
            Log.Warning($"layer {name} not exist");
        }
    }
}