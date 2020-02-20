namespace Echo.Input
{
    public class Input
    {
        private KeyboardInput kb = default;
        private MouseInput mouse = default;

        /* 
         * add / get/ enable / disable keyboard 
         * no remove because input callback should only be set during engine's load / unload function
        */
        public void AddKeyboard()
        {
            kb = new KeyboardInput();
        }

        public KeyboardInput Keyboard
        {
            get => kb;
        }

        public void EnableKeyboard()
        {
            if (kb != default) kb.Enabled = true;
        }

        public void DisableKeyboard()
        {
            if (kb != default) kb.Enabled = false;
        }

        /* add / get / enable / disable mouse */
        public void AddMouse()
        {
            mouse = new MouseInput();
        }

        public MouseInput Mouse
        {
            get => mouse;
        }

        public void EnableMouse()
        {
            if (mouse != default) mouse.Enabled = false;
        }

        public void DisableMouse()
        {
            if (mouse != default) mouse.Enabled = false;
        }

        /// <summary>
        /// enable layer
        /// </summary>
        public void Enable()
        {
            if (kb != default) kb.Enabled = true;
            if (mouse != default) mouse.Enabled = true;
        }

        /// <summary>
        /// disable layer
        /// </summary>
        public void Disable()
        {
            if (kb != default) kb.Enabled = false;
            if (mouse != default) mouse.Enabled = false;
        }

        /// <summary>
        /// load input elements, call in GL.OnLoad
        /// </summary>
        /// <param name="game">pointer to game program</param>
        public void OnLoad(Game game)
        {
            if (kb != default)
            {
                game.KeyDown += kb.OnKeyDown;
                game.KeyUp += kb.OnKeyUp;
                game.KeyPress += kb.OnKeyPress;
            }

            if (mouse != default)
            {
                game.MouseMove += mouse.OnMouseMove;
                game.MouseDown += mouse.OnMouseDown;
                game.MouseUp += mouse.OnMouseUp;
                game.MouseWheel += mouse.OnMouseWheel;
            }
        }

        /// <summary>
        /// unload input element, call in GL.Unload
        /// </summary>
        /// <param name="game"></param>
        public void OnUnload(Game game)
        {
            if (kb != default)
            {
                game.KeyDown -= kb.OnKeyDown;
                game.KeyUp -= kb.OnKeyUp;
                game.KeyPress -= kb.OnKeyPress;
            }

            if (mouse != default)
            {
                game.MouseMove -= mouse.OnMouseMove;
                game.MouseDown -= mouse.OnMouseDown;
                game.MouseUp -= mouse.OnMouseUp;
                game.MouseWheel -= mouse.OnMouseWheel;
            }
        }
    }
}