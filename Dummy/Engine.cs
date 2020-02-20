using System;
using System.Collections.Generic;
using Echo;
using Echo.Input;
using Echo.Test;
using Echo.Graphics;

using OpenTK.Graphics.OpenGL4;

namespace Dummy
{
    public class Engine : Echo.Engine
    {
        private float[] vertices = { -0.5f, 0.5f, -0.5f, -0.5f, 0.5f, 0.5f };

        private VertexBuffer vb;
        private VertexBufferLayout vbl;
        private VertexArray va;
        private Shader shader;

        private KeyboardInputTest kbt;

        public override void OnLoad()
        {
            kbt = new KeyboardInputTest();

            vb = new VertexBuffer(vertices, BufferUsageHint.StaticDraw);

            vbl = new VertexBufferLayout();
            vbl.Add<float>(2);

            va = new VertexArray();
            va.AddBuffer(vb, vbl);

            shader = new Shader("color", new ShaderType[] { ShaderType.VertexShader, ShaderType.FragmentShader });
            shader.Bind();
        }

        public override void OnRender()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public override void OnUpdate()
        {
        }

        public override void OnUnload()
        {
            vb.Dispose();
            va.Dispose();
            shader.Dispose();
        }
    }
}
