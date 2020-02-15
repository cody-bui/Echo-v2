using EchoCore.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Dummy
{
    public class Engine : EchoCore.Engine
    {
        private VertexBuffer vb;
        private VertexArray va;
        private VertexBufferLayout vbl;
        private Shader shader;

        private float[] position = { 0.5f, -0.5f, 0.5f, 0.5f, -0.5f, 0.5f };

        public override void OnLoad()
        {
            vb = new VertexBuffer(position, BufferUsageHint.StaticDraw);

            vbl = new VertexBufferLayout();
            vbl.Add<float>(2);

            va = new VertexArray();
            va.AddBuffer(vb, vbl);

            shader = new Shader("basic", new ShaderType[] { ShaderType.VertexShader, ShaderType.FragmentShader });
            shader.Bind();
        }

        public override void OnUpdate()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public override void OnUnload()
        {
            vb.Dispose();
            va.Dispose();
            shader.Dispose();
        }
    }
}