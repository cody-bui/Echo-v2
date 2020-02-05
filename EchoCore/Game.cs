using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL4;
using EchoCore.Graphics;

namespace EchoCore
{
    public class Game : GameWindow
    {
        // game constructor
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            EchoCore.Log.ConsoleLog(EchoCore.Log.LogType.Init, "new game window");
        }

        float[] vertices = { -0.5f, 0.5f, -0.5f, -0.5f, 0.5f, 0.5f };
        VertexBuffer vb;
        Shader shader;

        // setup function
        protected override void OnLoad(EventArgs e)
        {
            // default window clear color
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            vb = new VertexBuffer(vertices, BufferUsageHint.StaticDraw);
            ShaderType[] st = { ShaderType.VertexShader, ShaderType.FragmentShader };
            shader = new Shader("basic", st);

            base.OnLoad(e);
        }

        // polling input for each frame update
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            //if (input.IsKeyDown(Key.Escape))
            //{
            //    Exit();
            //}

            base.OnUpdateFrame(e);
        }

        // clear display and swap buffers
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            Context.SwapBuffers();

            base.OnRenderFrame(e);
        }

        // change viewport on resize
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            shader.Dispose();
            vb.Dispose();

            // finish the log and keep the console open
            EchoCore.Log.ConsoleLog(EchoCore.Log.LogType.Delete, "delete game window");
            if (System.Diagnostics.Debugger.IsAttached) Console.ReadLine();

            base.OnUnload(e);
        }
    }
}
