using System;
using System.Collections.Generic;
using EchoCore;
using OpenTK;

namespace EchoAsset.Components
{
    public class TransformComponent : Component
    {
        Matrix4 Transform { get; set; }
        Matrix4 Rotate { get; set; }
        Matrix4 Scale { get; set; }
    }
}
