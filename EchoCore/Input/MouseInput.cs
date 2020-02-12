using System;
using OpenTK.Input;

namespace EchoCore.Input
{
    public class MouseInput
    {
        public event EventHandler<MouseEventArgs> mouseEventHandler;
        public event EventHandler<MouseButtonEventArgs> mouseButtonEventHandler;
        public event EventHandler<MouseWheelEventArgs> mouseWheelEventHandler;

        public void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            mouseEventHandler?.Invoke(sender, e);
        }

        public void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseEventHandler?.Invoke(sender, e);
        }

        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseButtonEventHandler?.Invoke(sender, e);
        }

        public void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            mouseWheelEventHandler?.Invoke(sender, e);
        }
    }
}
