using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace EchoCore.Input
{
    static public class Keyboard
    {
        static public event EventHandler<List<Key>> keyboardEventHandler;

        /// <summary>
        /// current keys
        /// </summary>
        static public List<Key> keys = new List<Key>();

        /// <summary>
        /// keys from the previous frame
        /// </summary>
        static public List<Key> pKeys = new List<Key>();

        /// <summary>
        /// add key into the list if it's not yet in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static public void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            // find and add key
            bool find = false;
            foreach (Key k in keys)
                if (k == e.Key)
                {
                    find = true;
                    break;
                }
            if (!find)
                keys.Add(e.Key);

            // raise event
            keyboardEventHandler?.Invoke(sender, keys);
        }

        /// <summary>
        /// remove key from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static public void OnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            // remove key (always find)
            foreach (Key k in keys)
                if (k == e.Key)
                {
                    keys.Remove(k);
                    break;
                }

            // raise event
            keyboardEventHandler?.Invoke(sender, keys);
        }

        static public void OnUpdate()
        {
            keys = pKeys;
        }
    }
}
