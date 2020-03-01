﻿using OpenTK;

namespace Echo.Graphics.Camera
{
    internal class Projection
    {
        internal enum ProjectionMode
        {
            Orthographic = 0,
            Perspective,
        }

        internal Matrix4 Mat { get; private set; }

        internal Projection(ProjectionMode mode, float x, float y, float z)
        {
            switch (mode)
            {
                case ProjectionMode.Orthographic:
                    Mat = Matrix4.CreateOrthographic(x, y, 0.0f, z);
                    return;

                case ProjectionMode.Perspective:
                    Mat = Matrix4.CreatePerspectiveOffCenter(0.0f, x, 0.0f, y, 0.0f, z);
                    return;
            }
        }
    }
}