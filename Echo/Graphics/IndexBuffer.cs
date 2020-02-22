using OpenTK.Graphics.OpenGL4;
using System;

namespace Echo.Graphics
{
    internal class IndexBuffer
    {
        private int id;

        public IndexBuffer(in uint[] data, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            Log.Init("new index buffer");

            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Length * sizeof(uint), data, hint);
        }

        ~IndexBuffer()
        {
            Log.Delete("delete index buffer");
            GL.DeleteBuffer(id);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Log.Delete("delete index buffer");
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
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, id);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }
    }
}