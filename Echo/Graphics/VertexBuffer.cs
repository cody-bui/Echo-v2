using OpenTK.Graphics.OpenGL4;
using System;

namespace Echo.Graphics
{
    public class VertexBuffer
    {
        private int id;

        /// <summary>
        /// for meshing coordinate system
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        /// <param name="hint"></param>
        public VertexBuffer(IntPtr data, int size, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, size, data, hint);
        }

        /// <summary>
        /// for normal coordination system
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hint"></param>
        public VertexBuffer(in float[] data, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * data.Length, data, hint);
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