using System;
using OpenTK;

namespace Echo
{
    public class TransformComponent : Component
    {
        public Matrix4 Transform { get; set; }
        public Matrix4 Rotate { get; set; }
        public Matrix4 Scale { get; set; }
    }
}
