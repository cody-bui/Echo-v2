using OpenTK.Input;
using System;

namespace Echo.Input
{
    public class MouseInput : InputMethod
    {
        public event EventHandler<MouseEventArgs> MouseEventHandler;

        public event EventHandler<MouseButtonEventArgs> MouseButtonEventHandler;

        public event EventHandler<MouseWheelEventArgs> MouseWheelEventHandler;

        public void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            if (Enabled)
                MouseEventHandler?.Invoke(sender, e);
        }

        public void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Enabled)
                MouseEventHandler?.Invoke(sender, e);
        }

        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Enabled)
                MouseButtonEventHandler?.Invoke(sender, e);
        }

        public void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Enabled)
                MouseWheelEventHandler?.Invoke(sender, e);
        }
    }
}