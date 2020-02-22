using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;

namespace Echo.Graphics
{
    public class VertexBuffer
    {
        private int id;

        public VertexBuffer(in float[] data, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            Log.Init("new vertex buffer");

            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, hint);
        }

        ~VertexBuffer()
        {
            Log.Delete("delete vertex buffer");
            GL.DeleteBuffer(id);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Log.Delete("delete vertex buffer");
                GL.DeleteBuffer(id);
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
        }

        public void UnBind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}