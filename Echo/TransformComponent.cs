using OpenTK;

namespace Echo
{
    [Component]
    public struct TransformComponent
    {
        public Matrix4 Transform { get; set; }
        public Matrix4 Rotate { get; set; }
        public Matrix4 Scale { get; set; }
    }
}
