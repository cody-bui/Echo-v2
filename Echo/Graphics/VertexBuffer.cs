using OpenTK.Graphics.OpenGL4;
using System;

namespace Echo.Graphics
{
    public class VertexBuffer<T> where T : struct
    {
        private int id;

        public VertexBuffer(T[] data, int size, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData<T>(BufferTarget.ArrayBuffer, size, data, hint);
        }

        ~VertexBuffer()
        {
            GL.DeleteBuffer(id);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
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