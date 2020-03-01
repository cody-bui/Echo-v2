using OpenTK.Input;
using System;

namespace Echo.Input
{
    public class MouseInput
    {
        public EventHandler<MouseMoveEventArgs> MouseMoveEventHandler;
        public EventHandler<MouseButtonEventArgs> MouseButtonEventHandler;
        public EventHandler<MouseWheelEventArgs> MouseWheelEventHandler;

        internal void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            MouseMoveEventHandler?.Invoke(this, e);
        }

        internal void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEventHandler?.Invoke(this, e);
        }

        internal void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEventHandler?.Invoke(this, e);
        }

        internal void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            MouseWheelEventHandler?.Invoke(this, e);
        }
    }
}