using OpenTK.Graphics.OpenGL4;

namespace Echo.Graphics
{
    /// <summary>
    /// containing data to construct VertexAttribPointer
    /// </summary>
    internal struct VertexArrayLayout
    {
        internal VertexAttribPointerType Type { private set; get; }
        internal int Data { private set; get; }
        internal int Count { private set; get; }
        internal bool Normalized { private set; get; }

        internal VertexArrayLayout(VertexAttribPointerType type, int byteSize, int count, bool normalized)
        {
            Type = type;
            Data = byteSize;
            Count = count;
            Normalized = normalized;
        }
    }
}