namespace Echo.Input
{
    public class InputLayer
    {
        public readonly string Id;

        public KeyboardInput Keyboard { get; private set; }
        public MouseInput Mouse { get; private set; }

        public InputLayer(string id)
        {
            Id = id;

            Keyboard = new KeyboardInput();
            Mouse = new MouseInput();
        }

        internal void Subscribe(in Game game)
        {
            game.KeyDown += Keyboard.OnKeyDown;
            game.KeyUp += Keyboard.OnKeyUp;
            game.KeyPress += Keyboard.OnKeyPress;

            game.MouseMove += Mouse.OnMouseMove;
            game.MouseDown += Mouse.OnMouseDown;
            game.MouseUp += Mouse.OnMouseUp;
            game.MouseWheel += Mouse.OnMouseWheel;
        }

        internal void Unsubscribe(in Game game)
        {
            game.KeyDown += Keyboard.OnKeyDown;
            game.KeyUp += Keyboard.OnKeyUp;
            game.KeyPress += Keyboard.OnKeyPress;

            game.MouseMove += Mouse.OnMouseMove;
            game.MouseDown += Mouse.OnMouseDown;
            game.MouseUp += Mouse.OnMouseUp;
            game.MouseWheel += Mouse.OnMouseWheel;
        }
    }
}