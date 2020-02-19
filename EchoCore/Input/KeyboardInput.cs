using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;

namespace EchoCore.Input
{
    public class KeyboardInput
    {
        public event EventHandler<List<KeyboardKeyEventArgs>> KeyboardEventHandler;

        private List<KeyboardKeyEventArgs> keys = new List<KeyboardKeyEventArgs>();

        public void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (!keys.Contains(e))
                keys.Add(e);
            KeyboardEventHandler?.Invoke(sender, keys);
        }

        public void OnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            keys.Remove(e);
            KeyboardEventHandler?.Invoke(sender, keys);
        }

        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}