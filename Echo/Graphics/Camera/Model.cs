using OpenTK;

namespace Echo.Graphics.Camera
{
    public class Model
    {
        public Matrix4 Mat { get; private set; }

        public Model()
            => Mat = Matrix4.Identity;

        public void RotateX(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationX(rad ? angle : MathHelper.DegreesToRadians(angle));

        public void RotateY(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationY(rad ? angle : MathHelper.DegreesToRadians(angle));

        public void RotateZ(float angle, bool rad = false)
            => Mat *= Matrix4.CreateRotationZ(rad ? angle : MathHelper.DegreesToRadians(angle));

        public void Translate(float x, float y, float z = 1.0f)
            => Mat *= Matrix4.CreateTranslation(x, y, z);

        public void Scale(float horizontal, float vertical, float depth = 1.0f)
            => Mat *= Matrix4.CreateScale(horizontal, vertical, depth);

        public void Scale(float scale)
            => Mat *= Matrix4.CreateScale(scale);
    }
}