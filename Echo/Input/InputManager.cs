using System;
using System.Collections.Generic;

namespace Echo.Input
{
    public static class InputManager
    {
        private static Dictionary<string, InputLayer> input = new Dictionary<string, InputLayer>();

        /// <summary>
        /// current active layer
        /// </summary>
        public static string ActiveLayer { get; private set; }

        /// <summary>
        /// create new layer and NOT set it to active
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static InputLayer Add(in string name)
        {
            InputLayer layer = new InputLayer(name);
            input.Add(name, layer);
            return layer;
        }

        /// <summary>
        /// create a new layer and SET it to active
        /// </summary>
        /// <param name="name"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static InputLayer Add(in string name, in Game game)
        {
            InputLayer layer = Add(name);
            SetActiveLayer(name, game);
            return layer;
        }

        /// <summary>
        /// remove a layer and unsub all of it's event
        /// </summary>
        /// <param name="name"></param>
        /// <param name="game"></param>
        public static void Remove(in string name, in Game game)
        {
            if (input.ContainsKey(name))
            {
                input[name].Unsubscribe(game);
                input[name] = null;
                input.Remove(name);
            }
            else
            {
                Log.Error($"input layer {name} not found");
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// set new active layer and unsub all other layers
        /// </summary>
        /// <param name="name"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static InputLayer SetActiveLayer(in string name, in Game game)
        {
            if (input.ContainsKey(name))
            {
                ActiveLayer = name;
                foreach (var layer in input)
                {
                    if (layer.Key == name)
                        layer.Value.Subscribe(game);
                    else
                        layer.Value.Unsubscribe(game);
                }
                return input[name];
            }
            else
            {
                Log.Error($"input layer {name} not found");
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// get a layer, use in conjunction with active layer to get active layer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static InputLayer Get(in string name)
        {
            if (!input.ContainsKey(name))
            {
                Log.Error($"layer {name} not found");
                throw new ArgumentException();
            }
            else
            {
                return input[name];
            }
        }
    }
}