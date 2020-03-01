using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echo.Graphics.Mesh
{
    public class Mesh
    {
        public List<Vertex> Vertices { get; set; }
        public List<uint> Indices { get; set; }
        public List<Texture> Textures { get; set; }

        /// <summary>
        /// set vertices, indices and textures
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="indices"></param>
        /// <param name="textures"></param>
        public Mesh(in List<Vertex> vertices, in List<uint> indices, in List<Texture> textures, BufferUsageHint hint = BufferUsageHint.StaticDraw)
        {
            Vertices = vertices;
            Indices = indices;
            Textures = textures;

            // initialize
            Init(hint);
        }

        /// <summary>
        /// render
        /// </summary>
        /// <param name="shader"></param>
        public void Draw(in Shader shader)
        {

        }

        private VertexBuffer<Vertex> vb;
        private VertexArray va;
        private IndexBuffer ib;

        private void Init(BufferUsageHint hint)
        {
            // position vertex buffer
            vb = new VertexBuffer<Vertex>(Vertices.ToArray(), Vertices.Count, hint);

            // vertex array
            va = new VertexArray();
            va.Add<Vertex>(VertexAttribPointerType.Float, 3);   // position
            va.Add<Vertex>(VertexAttribPointerType.Float, 3);   // normal   
            va.Add<Vertex>(VertexAttribPointerType.Float, 2);   // texture
            va.Set();

            // indices index buffer
            ib = new IndexBuffer(Indices.ToArray(), hint);
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                vb.Dispose();
                ib.Dispose();
                va.Dispose();
            }
        }
    }
}
