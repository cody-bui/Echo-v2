using OpenTK.Input;
using System.Collections.Generic;

namespace Echo.Input
{
    public class KeysEventArgs
    {
        public List<Key> Keys { get; internal set; }
        public bool Alt { get; internal set; }
        public bool Shift { get; internal set; }
        public bool Control { get; internal set; }

        public bool ContainsKey(Key key)
        {
            for (int i = 0; i < Keys.Count; i++)
                if (Keys[i] == key)
                    return true;
            return false;
        }
    }
}