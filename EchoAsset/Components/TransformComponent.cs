using Echo;
using OpenTK;

namespace EchoAsset.Components
{
    public class TransformComponent : Component
    {
        private Matrix4 Transform { get; set; }
        private Matrix4 Rotate { get; set; }
        private Matrix4 Scale { get; set; }
    }
}