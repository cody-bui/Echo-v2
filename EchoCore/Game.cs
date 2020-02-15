using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;

namespace EchoCore
{
    public class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            Log.Init("new game window");
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // main loop

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            Log.Delete("delete game window");
            base.OnUnload(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}