using System;
using OpenTK.Graphics.OpenGL4;

namespace EchoCore.Graphics
{
    class VertexArray
    {
        private int id;

        // constructor generates vertex array
        public VertexArray()
        {
            Log.ConsoleLog(Log.LogType.Init, "new vertex array");
            id = GL.GenVertexArray();
        }


        public void AddBuffer(VertexBuffer vb, VertexBufferLayout vbl)
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

        // bind
        public void Bind()
        {
            GL.BindVertexArray(id);
        }

        // unbind
        public void Unbind()
        {
            GL.BindVertexArray(0);
        }
    }
}
