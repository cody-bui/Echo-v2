using Echo;
using Echo.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Runtime.InteropServices;

namespace Dummy
{
    public class Engine : EchoEngine
    {
        private float[] vertices = {
             1.0f,  1.0f, 0.0f, 1.0f, 1.0f,
             1.0f, -1.0f, 0.0f, 1.0f, 0.0f,
            -1.0f, -1.0f, 0.0f, 0.0f, 0.0f,
            -1.0f,  1.0f, 0.0f, 0.0f, 1.0f
        };

        private uint[] indices = {
            0, 1, 3,
            1, 2, 3
        };

        private VertexBuffer<float> vb;
        private IndexBuffer ib;
        private VertexArray va;
        private Shader shader;
        private Texture texture1;
        private Texture texture2;

        public override void OnLoad(in Game game)
        {
            shader = new Shader("texture", new ShaderType[] { ShaderType.VertexShader, ShaderType.FragmentShader });
            shader.Bind();

            Loader.UseProjectPath();
            texture1 = new Texture("texture1.png");
            texture1.Bind(0);
            shader.SetUniform("tex0", 0);

            texture2 = new Texture("texture2.png");
            texture2.Bind(1);
            shader.SetUniform("tex1", 1);

            vb = new VertexBuffer<float>(vertices, sizeof(float) * 20);

            va = new VertexArray();
            va.Add<float>(VertexAttribPointerType.Float, 3);
            va.Add<float>(VertexAttribPointerType.Float, 2);
            va.Set();

            ib = new IndexBuffer(indices, BufferUsageHint.StaticDraw);
        }

        public override void OnRender(in Game game)
        {
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public override void OnUpdate(in Game game)
        {
        }

        public override void OnUnload(in Game game)
        {
            vb.Dispose();
            ib.Dispose();
            va.Dispose();
            shader.Dispose();
            texture1.Dispose();
            texture2.Dispose();
        }
    }
}