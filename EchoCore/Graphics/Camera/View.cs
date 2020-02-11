using OpenTK;

namespace EchoCore.Graphics.Camera
{
    public class View
    {
        public Matrix4 ViewMatrix { private set; get; }

        public View()
        {
            // create a default matrix
            ViewMatrix = Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f);
        }

        public void Rotate(float xAngle, float yAngle, bool rad = false)
        {
            if (!rad)
            {
                xAngle = MathHelper.DegreesToRadians(xAngle);
                yAngle = MathHelper.DegreesToRadians(yAngle);
            }
            ViewMatrix *= Matrix4.CreateRotationX(xAngle) * Matrix4.CreateRotationY(yAngle);
        }

        public void RotateX(float angle, bool rad = false)
        {
            ViewMatrix *= Matrix4.CreateRotationX(rad ? angle : MathHelper.DegreesToRadians(angle));
        }

        public void RotateY(float angle, bool rad = false)
        {
            ViewMatrix *= Matrix4.CreateRotationY(rad ? angle : MathHelper.DegreesToRadians(angle));
        }

        public void Translation(float x, float y)
        {
            ViewMatrix *= Matrix4.CreateTranslation(x, y, 0.0f);
        }

        public void Scale(float scale)
        {
            ViewMatrix *= Matrix4.CreateScale(scale);
        }
    }
}
