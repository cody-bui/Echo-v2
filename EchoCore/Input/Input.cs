namespace EchoCore.Input
{
    public class Input
    {
        private KeyboardInput kb;
        private MouseInput mouse;

        /// <summary>
        /// load input elements, call in GL.OnLoad
        /// </summary>
        /// <param name="game">pointer to game program</param>
        public void OnLoad(Engine game)
        {
            kb = new KeyboardInput();
            game.KeyDown += kb.OnKeyDown;
            game.KeyUp += kb.OnKeyUp;

            mouse = new MouseInput();
            game.MouseMove += mouse.OnMouseMove;

            game.MouseDown += mouse.OnMouseDown;
            game.MouseUp += mouse.OnMouseUp;

            game.MouseWheel += mouse.OnMouseWheel;
        }

        /// <summary>
        /// update all input elements, call in GL.OnUpdateFrame
        /// </summary>
        public void OnUpdate()
        {
            kb.OnUpdate();
        }

        /// <summary>
        /// unload input element, call in GL.Unload
        /// </summary>
        /// <param name="game"></param>
        public void OnUnload(Engine game)
        {
            game.KeyDown -= kb.OnKeyDown;
            game.KeyUp -= kb.OnKeyUp;

            game.MouseMove -= mouse.OnMouseMove;

            game.MouseDown -= mouse.OnMouseDown;
            game.MouseUp -= mouse.OnMouseUp;

            game.MouseWheel -= mouse.OnMouseWheel;
        }
    }
}