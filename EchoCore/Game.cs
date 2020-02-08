using EchoCore.Graphics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System;

namespace EchoCore
{
    public class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            EchoCore.Log.ConsoleLog(EchoCore.Log.LogType.Init, "new game window");
        }

        float[] vertices =
        {
             0.5f,  0.5f, 0.0f, 1.0f, 1.0f,
             0.5f, -0.5f, 0.0f, 1.0f, 0.0f,
            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f,
            -0.5f,  0.5f, 0.0f, 0.0f, 1.0f
        };

        uint[] indices = {
            0, 1, 3,
            1, 2, 3
        };

        private VertexBuffer vb;
        private IndexBuffer ib;
        private VertexArray va;
        private VertexBufferLayout vbl;
        private Shader shader;
        private Texture texture;

        /// <summary>
        /// window setup, run after a new context is created and first frame is rendered
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // default window clear color
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            vb = new VertexBuffer(in vertices, BufferUsageHint.StaticDraw);

            vbl = new VertexBufferLayout();
            vbl.Add<float>(3);

            va = new VertexArray();
            va.AddBuffer(in vb, in vbl);

            ib = new IndexBuffer(in indices, BufferUsageHint.StaticDraw);

            shader = new Shader("basic", new ShaderType[] { ShaderType.VertexShader, ShaderType.FragmentShader });
            shader.Bind();

            texture = new Texture("texture.jpg", TextureWrapMode.ClampToBorder, TextureWrapMode.ClampToBorder, TextureMinFilter.Nearest, TextureMagFilter.Linear);

            base.OnLoad(e);
        }

        /// <summary>
        /// polling input for each frame update
        /// </summary>
        /// <param name="e"></param>        
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            base.OnUpdateFrame(e);
        }

        /// <summary>
        /// program loop, include display clearing, rendering and buffer swapping
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // render
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

            // swap
            Context.SwapBuffers();

            base.OnRenderFrame(e);
        }

        /// <summary>
        /// change viewport on resize
        /// </summary>
        /// <param name="e"></param>        
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            base.OnResize(e);
        }

        /// <summary>
        /// cleanup program, run after the last frame and before the context is destroyed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUnload(EventArgs e)
        {
            vb.Dispose();
            va.Dispose();
            ib.Dispose();
            shader.Dispose();

            // finish the log
            EchoCore.Log.ConsoleLog(EchoCore.Log.LogType.Delete, "delete game window");

            base.OnUnload(e);
        }
    }
}