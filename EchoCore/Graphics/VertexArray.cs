using OpenTK.Graphics.OpenGL4;
using System;

namespace EchoCore.Graphics
{
    internal class VertexArray
    {
        private int id;

        public VertexArray()
        {
            Log.Init("new vertex array");
            id = GL.GenVertexArray();
        }

        ~VertexArray()
        {
            Log.Delete("delete vertex array");
            GL.DeleteVertexArray(id);
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
                Log.Delete("delete vertex array");
                GL.DeleteVertexArray(id);
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// add buffer
        /// </summary>
        /// <param name="vb">vertex buffer</param>
        /// <param name="vbl">vertex buffer layout</param>
        public void AddBuffer(in VertexBuffer vb, in VertexBufferLayout vbl)
        {
            GL.BindVertexArray(id);
            vb.Bind();

            var element = vbl.Element;
            int offset = 0;

            for (int i = 0; i < element.Count; i++)
            {
                GL.EnableVertexAttribArray(i);
                GL.VertexAttribPointer(
                    i,
                    element[i].Count,
                    element[i].Type,
                    element[i].Normalized,
                    vbl.Stride,
                    offset
                );
                offset += element[i].Count * element[i].ByteSize;
            }
        }

        public void Bind()
        {
            GL.BindVertexArray(id);
        }

        public void Unbind()
        {
            GL.BindVertexArray(0);
        }
    }
}