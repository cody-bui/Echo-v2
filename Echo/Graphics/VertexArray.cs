using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Echo.Graphics
{
    public class VertexArray
    {
        private int id;

        private List<VertexArrayLayout> element = new List<VertexArrayLayout>();
        private int stride = 0;

        public VertexArray()
        {
            id = GL.GenVertexArray();
        }

        /// <summary>
        /// extend the vertex array layout
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="count"></param>
        public void Add<T>(VertexAttribPointerType type, int count) where T : struct
        {
            element.Add(new VertexArrayLayout(type, Marshal.SizeOf<T>(), count, false));
            stride += sizeof(float) * count;
        }

        /// <summary>
        /// set the final layout using previous additions
        /// </summary>
        public void Set()
        {
            GL.BindVertexArray(id);
            int offset = 0;

            for (int i = 0; i < element.Count; i++)
            {
                GL.EnableVertexAttribArray(i);
                GL.VertexAttribPointer(
                    i,
                    element[i].Count,
                    element[i].Type,
                    element[i].Normalized,
                    stride,
                    offset
                );
                offset += element[i].Count * element[i].Data;
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

        ~VertexArray()
        {
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
                GL.DeleteVertexArray(id);
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}