using OpenTK;

namespace EchoCore.Graphics.Camera
{
    public class View
    {
        public Matrix4 Mat { get; private set; }

        public View()
            => Mat = Matrix4.Identity;

        public void RotateX(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationX(rad ? angle : MathHelper.DegreesToRadians(angle));

        public void RotateY(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationY(rad ? angle : MathHelper.DegreesToRadians(angle));

        public void RotateZ(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationZ(rad ? angle : MathHelper.DegreesToRadians(angle));

        public void Translate(float x, float y, float z = 1.0f)
            => Mat *= Matrix4.CreateTranslation(x, y, z);

        public void Scale(float horizontal, float vertical, float depth)
            => Mat *= Matrix4.CreateScale(horizontal, vertical, depth);

        public void Scale(float horizontal, float vertical)
            => Mat *= Matrix4.CreateScale(horizontal, vertical, 1.0f);

        public void Scale(float scale)
            => Mat *= Matrix4.CreateScale(scale);
    }
}