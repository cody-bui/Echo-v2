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
        public VertexBuffer(float[] data, BufferUsageHint hint)
        {
            Log.ConsoleLog(Log.LogType.Init, "new vertex buffer");

            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, hint);
        }

        // buffer destructor
        ~VertexBuffer()
        {
            Log.ConsoleLog(Log.LogType.Delete, "delete vertex buffer");
            GL.DeleteBuffer(id);
        }

        // disposing
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Log.ConsoleLog(Log.LogType.Delete, "delete vertex buffer");
                GL.DeleteBuffer(id);
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // bind the buffer
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
        }

        // unbind the buffer
        public void UnBind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}