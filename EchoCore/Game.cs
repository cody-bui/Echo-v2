using EchoCore.Input;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;

namespace EchoCore
{
    public class Game : GameWindow
    {
        private EchoCore.Input.Input input;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            // enable blending
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            Log.Init("new game window");
        }

        /// <summary>
        /// window setup, run after a new context is created and first frame is rendered
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            input = new EchoCore.Input.Input();
            input.OnLoad(this);

            base.OnLoad(e);
        }

        /// <summary>
        /// polling input for each frame update
        /// </summary>
        /// <param name="e"></param>        
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            input.OnUpdate();

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
            input.OnUnload(this);

            Log.Delete("delete game window");
            base.OnUnload(e);
        }
    }
}