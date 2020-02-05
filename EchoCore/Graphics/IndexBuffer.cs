using System;
using OpenTK.Graphics.OpenGL4;

namespace EchoCore.Graphics
{
    class IndexBuffer
    {
        private int id;

        /// <summary>
        /// index buffer constructor
        /// </summary>
        /// <param name="data">vertices index</param>
        /// <param name="hint">type of buffer usage hint</param>
        public IndexBuffer(int[] data, BufferUsageHint hint)
        {
            Log.ConsoleLog(Log.LogType.Init, "new index buffer");

            id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Length, data, hint);
        }

        // buffer destructor
        ~IndexBuffer()
        {
            Log.ConsoleLog(Log.LogType.Delete, "delete index buffer");
            GL.DeleteBuffer(id);
        }

        // disposing
        private bool disposed = false;
        
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

        // bind the buffer
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, id);
        }

        // unbind the buffer
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }
    }
}
