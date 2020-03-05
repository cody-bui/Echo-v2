using OpenTK;
using System;

namespace Echo.Graphics.Camera
{
    public static class Projection
    {
        public static Matrix4 Mat { get; private set; }

        /// <summary>
        /// set orthographic projection
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static Matrix4 SetOrthoProjection(float width, float height, float depth)
        {
            // throw if z < 0.1f
            if (depth < 0.1f)
            {
                Log.Error("z must be greater than 0.1f");
                throw new ArgumentException();
            }

            Mat = Matrix4.CreateOrthographic(width, height, 0.1f, depth);
            return Mat;
        }

        /// <summary>
        /// create field of view perspective projection
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="fov">field of view</param>
        /// <param name="rad">if fov is in radian</param>
        /// <returns></returns>
        public static Matrix4 SetPovProjection(int width, int height, float depth, float fov, bool rad = false)
        {
            // throw if depth < 0.1f
            if (depth < 0.1f)
            {
                Log.Error("depth must be greater than 0.1f");
                throw new ArgumentException();
            }

            fov = rad ? fov : MathHelper.DegreesToRadians(fov);

            // throw if pov > pi or < 0
            if (fov > MathHelper.Pi || fov < 0)
            {
                Log.Error("pov must be from 0 - 180 degrees / 0 - pi radians");
                throw new ArgumentException();
            }

            Mat = Matrix4.CreatePerspectiveFieldOfView(fov, width / (float)height, 0.1f, depth);
            return Mat;
        }
    }
}