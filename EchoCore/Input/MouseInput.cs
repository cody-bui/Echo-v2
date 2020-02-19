using OpenTK.Input;
using System;

namespace EchoCore.Input
{
    public class MouseInput
    {
        public event EventHandler<MouseEventArgs> MouseEventHandler;

        public event EventHandler<MouseButtonEventArgs> MouseButtonEventHandler;

        public event EventHandler<MouseWheelEventArgs> MouseWheelEventHandler;

        public void OnMouseMove(object sender, MouseMoveEventArgs e)
            => MouseEventHandler?.Invoke(sender, e);

        public void OnMouseUp(object sender, MouseButtonEventArgs e)
            => MouseEventHandler?.Invoke(sender, e);

        public void OnMouseDown(object sender, MouseButtonEventArgs e)
            => MouseButtonEventHandler?.Invoke(sender, e);

        public void OnMouseWheel(object sender, MouseWheelEventArgs e)
            => MouseWheelEventHandler?.Invoke(sender, e);
    }
}