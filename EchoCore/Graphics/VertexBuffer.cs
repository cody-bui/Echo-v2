using OpenTK.Graphics.OpenGL4;
using System;

namespace EchoCore.Graphics
{
    internal class VertexBuffer
    {
        private int id;

        /// <summary>
        /// vertex buffer constructor
        /// </summary>
        /// <param name="data">vertices postion array</param>
        /// <param name="flag">type of buffer usage hint</param>
        public VertexBuffer(in float[] data, BufferUsageHint hint)
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

        /// <summary>
        /// dispose function
        /// </summary>
        /// <param name="disposing">to distinguish from public dispose function</param>
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