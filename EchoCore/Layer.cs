using System;

namespace EchoCore
{
    public abstract class Layer
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public abstract void OnUpdate();

        public abstract void OnEvent(object sender, EventArgs e);
    }
}