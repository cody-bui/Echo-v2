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
        VertexArray va;
        VertexBufferLayout vbl;
        Shader shader;

        // setup function
        protected override void OnLoad(EventArgs e)
        {
            // default window clear color
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            vb = new VertexBuffer(vertices, BufferUsageHint.StaticDraw);

            vbl = new VertexBufferLayout();
            vbl.Add<float>(2);

            va = new VertexArray();
            va.AddBuffer(vb, vbl);

            ShaderType[] st = { ShaderType.VertexShader, ShaderType.FragmentShader };
            shader = new Shader("basic", st);
            shader.Bind();

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
            // clear
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // render
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            // swap
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
            va.Dispose();

            // finish the log
            EchoCore.Log.ConsoleLog(EchoCore.Log.LogType.Delete, "delete game window");

            base.OnUnload(e);
        }
    }
}
