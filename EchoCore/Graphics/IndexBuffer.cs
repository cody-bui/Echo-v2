using OpenTK.Graphics.OpenGL4;
using System;

namespace EchoCore.Graphics
{
    internal class IndexBuffer
    {
        private int id;

        /// <summary>
        /// index buffer constructor
        /// </summary>
        /// <param name="data">vertices index</param>
        /// <param name="hint">type of buffer usage hint</param>
        public IndexBuffer(in uint[] data, BufferUsageHint hint)
        {
            Log.ConsoleLog(Log.LogType.Init, "new index buffer");

            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Length * sizeof(uint), data, hint);
        }

        ~IndexBuffer()
        {
            Log.ConsoleLog(Log.LogType.Delete, "delete index buffer");
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
                Log.ConsoleLog(Log.LogType.Delete, "delete index buffer");
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