using OpenTK;

namespace EchoCore.Graphics.Camera
{
    public class Projection
    {
        public Matrix4 ProjectionMatrix { private set; get; }

        public void Perspective(float left, float right, float bottom, float top, float zNear, float zFar)
        {
            ProjectionMatrix = Matrix4.CreatePerspectiveOffCenter(left, right, bottom, top, zNear, zFar);
        }
    }
}