using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;

namespace Echo.Input
{
    public class KeyboardInput : InputMethod
    {
        public event EventHandler<List<Key>> KeyboardEventHandler;

        private List<Key> keys = new List<Key>();

        public void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (Enabled)
            {
                if (!keys.Contains(e.Key))
                    keys.Add(e.Key);
                KeyboardEventHandler?.Invoke(sender, keys);
            }
        }

        public void OnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            if (Enabled)
            {
                keys.Remove(e.Key);
                KeyboardEventHandler?.Invoke(sender, keys);
            }
        }

        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (Enabled) ;
        }
    }
}