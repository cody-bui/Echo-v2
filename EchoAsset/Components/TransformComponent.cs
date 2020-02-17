using EchoCore;
using OpenTK;

namespace EchoAsset.Components
{
    public abstract class TransformComponent : Component
    {
        Matrix4 Position { get; set; }
        Matrix4 Rotation { get; set; }
        Matrix4 Scale { get; set; }
    }
}