using Echo;
using Echo.Graphics;
using Echo.Graphics.Camera;
using Echo.Input;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Dummy.Test
{
    internal class SimpleRenderTest
    {
        //private float[] vertices = {
        //    1200.0f,675.0f, 0.0f, 1.0f, 1.0f,
        //    1200.0f,225.0f, 0.0f, 1.0f, 0.0f,
        //    400.0f, 225.0f, 0.0f, 0.0f, 0.0f,
        //    400.0f, 675.0f, 0.0f, 0.0f, 1.0f
        //};

        private float[] vertices = {
             0.5f,  0.5f, 0.0f, 1.0f, 1.0f,
             0.5f, -0.5f, 0.0f, 1.0f, 0.0f,
            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f,
            -0.5f,  0.5f, 0.0f, 0.0f, 1.0f
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
        private float blend = 0.001f;

        private InputLayer il;
        private CameraController cc;

        internal void OnLoad(in Game game)
        {
            // rendering
            shader = new Shader("texture", new ShaderType[] { ShaderType.VertexShader, ShaderType.FragmentShader });
            shader.Bind();
            //Matrix4 proj = Projection.SetOrthoProjection(game.Width, game.Height, 100.0f);
            //shader.SetUniform("proj", ref proj);

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

            // input and camera control
            ib = new IndexBuffer(indices, BufferUsageHint.StaticDraw);

            cc = new CameraController(new Vector3(0.0f, 0.0f, 3.0f));
            cc.Speed = 0.5f;

            il = InputManager.Add("test", game);
            il.Keyboard.KeysEventHandler += cc.OnKeyControl;
            il.Mouse.MouseMoveEventHandler += cc.OnMouseControl;

            KeyMapping.UpdateKeyMapping();
        }

        internal void OnRender(in Game game)
        {
            shader.SetUniform("blend", blend += 0.001f);
            //Matrix4 pos = cc.LookAt();
            //shader.SetUniform("view", ref pos);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        internal void OnUnload(in Game game)
        {
            il.Keyboard.KeysEventHandler -= cc.OnKeyControl;

            vb.Dispose();
            ib.Dispose();
            va.Dispose();
            shader.Dispose();
            texture1.Dispose();
            texture2.Dispose();
        }
    }
}