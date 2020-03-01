﻿using OpenTK;

namespace Echo.Graphics.Camera
{
    internal class View
    {
        internal Matrix4 Mat { get; private set; }

        internal View()
            => Mat = new Matrix4();

        internal void RotateX(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationX(rad ? angle : MathHelper.DegreesToRadians(angle));

        internal void RotateY(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationY(rad ? angle : MathHelper.DegreesToRadians(angle));

        internal void RotateZ(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationZ(rad ? angle : MathHelper.DegreesToRadians(angle));

        internal void Translate(float x, float y, float z = 1.0f)
            => Mat *= Matrix4.CreateTranslation(x, y, z);

        internal void Scale(float horizontal, float vertical, float depth)
            => Mat *= Matrix4.CreateScale(horizontal, vertical, depth);

        internal void Scale(float horizontal, float vertical)
            => Mat *= Matrix4.CreateScale(horizontal, vertical, 1.0f);

        internal void Scale(float scale)
            => Mat *= Matrix4.CreateScale(scale);
    }
}