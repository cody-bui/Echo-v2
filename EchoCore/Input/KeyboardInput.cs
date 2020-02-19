using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;

namespace EchoCore.Input
{
    public class KeyboardInput
    {
        public event EventHandler<List<Key>> KeyboardEventHandler;

        private List<Key> keys = new List<Key>();

        public void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (!keys.Contains(e.Key))
                keys.Add(e.Key);
            KeyboardEventHandler?.Invoke(sender, keys);
        }

        public void OnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            keys.Remove(e.Key);
            KeyboardEventHandler?.Invoke(sender, keys);
        }

        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}