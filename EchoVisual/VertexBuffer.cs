using System;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace EchoVisual
{
    class VertexBuffer
    {
        private int id;

        public VertexBuffer(float[] data, BufferUsageHint flag)
        {
            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * data.Length, data, flag);
        }
    }
}
