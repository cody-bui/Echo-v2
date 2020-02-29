using OpenTK;

namespace Echo.Graphics.Mesh
{
    public struct Vertex
    {
        public Vector4 Position { get; set; }
        public Vector4 Normal { get; set; }
        public Vector2 TexCoord { get; set; }
    }
}