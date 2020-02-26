namespace Echo.Input
{
    public class Input
    {
        /*
         * add / get/ enable / disable keyboard
         * no remove because input callback should only be set during engine's load / unload function
        */
        public KeyboardInput Keyboard { get; private set; } = default;

        public void AddKeyboard()
        {
            Keyboard = new KeyboardInput();
        }

        public void EnableKeyboard()
        {
            if (Keyboard != default) Keyboard.Enabled = true;
        }

        public void DisableKeyboard()
        {
            if (Keyboard != default) Keyboard.Enabled = false;
        }

        /* add / get / enable / disable mouse */
        public MouseInput Mouse { get; private set; } = default;

        public void AddMouse()
        {
            Mouse = new MouseInput();
        }

        public void EnableMouse()
        {
            if (Mouse != default) Mouse.Enabled = false;
        }

        public void DisableMouse()
        {
            if (Mouse != default) Mouse.Enabled = false;
        }

        /// <summary>
        /// enable layer
        /// </summary>
        public virtual void Enable()
        {
            if (Keyboard != default) Keyboard.Enabled = true;
            if (Mouse != default) Mouse.Enabled = true;
        }

        /// <summary>
        /// disable layer
        /// </summary>
        public virtual void Disable()
        {
            if (Keyboard != default) Keyboard.Enabled = false;
            if (Mouse != default) Mouse.Enabled = false;
        }

        /// <summary>
        /// load input elements, call in GL.OnLoad
        /// </summary>
        /// <param name="game">pointer to game program</param>
        public virtual void OnLoad(in GameLoop game)
        {
            if (Keyboard != default)
            {
                game.KeyDown += Keyboard.OnKeyDown;
                game.KeyUp += Keyboard.OnKeyUp;
                game.KeyPress += Keyboard.OnKeyPress;
            }

            if (Mouse != default)
            {
                game.MouseMove += Mouse.OnMouseMove;
                game.MouseDown += Mouse.OnMouseDown;
                game.MouseUp += Mouse.OnMouseUp;
                game.MouseWheel += Mouse.OnMouseWheel;
            }
        }

        /// <summary>
        /// unload input element, call in GL.Unload
        /// </summary>
        /// <param name="game"></param>
        public virtual void OnUnload(in GameLoop game)
        {
            if (Keyboard != default)
            {
                game.KeyDown -= Keyboard.OnKeyDown;
                game.KeyUp -= Keyboard.OnKeyUp;
                game.KeyPress -= Keyboard.OnKeyPress;
            }

            if (Mouse != default)
            {
                game.MouseMove -= Mouse.OnMouseMove;
                game.MouseDown -= Mouse.OnMouseDown;
                game.MouseUp -= Mouse.OnMouseUp;
                game.MouseWheel -= Mouse.OnMouseWheel;
            }
        }
    }
}