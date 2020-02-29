using OpenTK;
using OpenTK.Input;
using System;

namespace Echo.Input
{
    public class KeyboardInput
    {
        public event EventHandler<KeysEventArgs> KeysEventHandler;

        public event EventHandler<char> KeyTypeEventHandler;

        private KeysEventArgs keys = new KeysEventArgs();

        public void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            keys.Keys.Add(e.Key);
            keys.Alt = e.Alt;
            keys.Shift = e.Shift;
            keys.Control = e.Control;

            KeysEventHandler?.Invoke(this, keys);
        }

        public void OnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            keys.Keys.Remove(e.Key);
            keys.Alt = e.Alt;
            keys.Shift = e.Shift;
            keys.Control = e.Control;

            KeysEventHandler?.Invoke(this, keys);
        }

        public void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            KeyTypeEventHandler?.Invoke(this, e.KeyChar);
        }
    }
}