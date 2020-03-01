using Echo;
using Echo.Graphics;
using Echo.Graphics.Camera;
using Echo.Input;
using OpenTK.Graphics.OpenGL4;

namespace Dummy.Test
{
    internal static class SimpleRenderTest
    {
        private static float[] vertices = {
             0.5f,  0.5f, 0.0f, 1.0f, 1.0f,
             0.5f, -0.5f, 0.0f, 1.0f, 0.0f,
            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f,
            -0.5f,  0.5f, 0.0f, 0.0f, 1.0f
        };

        private static uint[] indices = {
            0, 1, 3,
            1, 2, 3
        };

        private static VertexBuffer<float> vb;
        private static IndexBuffer ib;
        private static VertexArray va;
        private static Shader shader;
        private static Texture texture1;
        private static Texture texture2;
        private static float blend = 0.001f;

        private static InputLayer il;
        private static CameraController cc;

        internal static void OnLoad(in Game game)
        {
            shader = new Shader("texture", new ShaderType[] { ShaderType.VertexShader, ShaderType.FragmentShader });
            shader.Bind();

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

            cc = new CameraController(shader);
            il = InputManager.Add("test", game);

            KeyMapping.UpdateKeyMappingEventHandler += cc.SetKeyMapping;
            KeyMapping.UpdateKeyMapping();

            il.Keyboard.KeysEventHandler += cc.KeyControl;
        }

        internal static void OnRender(in Game game)
        {
            shader.SetUniform("blend", blend += 0.001f);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        internal static void OnUnload(in Game game)
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