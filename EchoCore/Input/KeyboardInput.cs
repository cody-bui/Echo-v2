using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace EchoCore.Input
{
    public class KeyboardInput
    {
        public event EventHandler<List<KeyboardKeyEventArgs>> keyboardEventHandler;

        /// <summary>
        /// current keys
        /// </summary>
        private List<KeyboardKeyEventArgs> keys = new List<KeyboardKeyEventArgs>();

        /// <summary>
        /// keys from the previous frame
        /// </summary>
        private List<KeyboardKeyEventArgs> pKeys = new List<KeyboardKeyEventArgs>();

        /// <summary>
        /// add key into the list if it's not yet in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            // find and add key
            bool find = false;
            foreach (KeyboardKeyEventArgs k in keys)
                if (k == e)
                {
                    find = true;
                    break;
                }
            if (!find)
                keys.Add(e);

            // raise event
            keyboardEventHandler?.Invoke(sender, keys);
        }

        /// <summary>
        /// remove key from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            // remove key (always find)
            foreach (KeyboardKeyEventArgs k in keys)
                if (k == e)
                {
                    keys.Remove(k);
                    break;
                }

            // raise event
            keyboardEventHandler?.Invoke(sender, keys);
        }

        /// <summary>
        /// swap old keys with new keys and clear the keys
        /// </summary>
        public void OnUpdate()
        {
            pKeys = keys;
            keys.Clear();
        }
    }
}
