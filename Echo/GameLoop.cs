using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;

namespace Echo
{
    public sealed class GameLoop : GameWindow
    {
        public EchoEngine engine { private get; set; }

        public GameLoop(int width, int height, in string title) : base(width, height, GraphicsMode.Default, title)
        {
            Log.Init("Game");
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            engine.OnLoad(this);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            engine.OnRenderFrame(this);

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            engine.OnUpdateFrame(this);
            base.OnUpdateFrame(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            engine.OnUnload(this);
            base.OnUnload(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}