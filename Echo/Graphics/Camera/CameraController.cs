using Echo.Input;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;

namespace Echo.Graphics.Camera
{
    public class CameraController
    {
        /* key mapping */
        public Key keyUp;
        public Key keyDown;
        public Key keyForward;
        public Key keyBackward;
        public Key keyLeft;
        public Key keyRight;

        /* values */
        private Vector3 position;

        private Vector3 front;
        private Vector3 up;
        private Vector3 right;

        private float yaw;
        private float pitch;
        private float roll;

        /* position, front, up, right, pitch and yaw properties */
        public Vector3 Position => position;

        public Vector3 Front => front;
        public Vector3 Up => up;
        public Vector3 Right => right;

        public float Pitch => pitch;
        public float Yaw => yaw;
        public float Roll => roll;

        /* camera speed */
        public float Speed { get; set; }

        /* view matrix */
        public Matrix4 View { get; private set; }

        public CameraController(Vector3 position)
        {
            // set position
            this.position = position;

            // set front, up and right vectors
            front = -Vector3.UnitZ;
            up = Vector3.UnitY;
            right = -Vector3.UnitX;

            // prerotate yaw to the right angle
            yaw = MathHelper.PiOver2;

            // subscribe to keymapping update event
            KeyMapping.UpdateKeyMappingEventHandler += OnSetKeyMapping;
        }

        ~CameraController()
        {
            KeyMapping.UpdateKeyMappingEventHandler -= OnSetKeyMapping;
        }

        public void OnSetKeyMapping(object sender, Dictionary<string, Key> e)
        {
            // set keymapping
            keyUp = e["Move Up"];
            keyDown = e["Move Down"];
            keyForward = e["Move Forward"];
            keyBackward = e["Move Backward"];
            keyLeft = e["Move Left"];
            keyRight = e["Move Right"];
        }

        public void OnKeyControl(object sender, KeysEventArgs e)
        {
            // modify value based on key pressed
            if (e.ContainsKey(keyUp))
                position += up * Speed;
            if (e.ContainsKey(keyDown))
                position -= up * Speed;
            if (e.ContainsKey(keyForward))
                position += front * Speed;
            if (e.ContainsKey(keyBackward))
                position -= front * Speed;
            if (e.ContainsKey(keyRight))
                position += right * Speed;
            if (e.ContainsKey(keyLeft))
                position -= right * Speed;

            // update vectors once the camera moves
            Update();
        }

        public void OnMouseControl(object sender, MouseMoveEventArgs e)
        {
            // limit the yaw due to euler angle limitation
            yaw = MathHelper.Clamp(yaw += e.XDelta, -MathHelper.Pi + 0.001f, MathHelper.Pi - 0.001f);
            pitch += e.YDelta;

            Update();
        }

        public void OnMouseWheelControl(object sender, MouseWheelEventArgs e)
        {
            Update();
        }

        public Matrix4 LookAt()
        {
            View = Matrix4.LookAt(position, position + front, up);
            return View;
        }

        private void Update()
        {
            // recalculate the front matrix after pitch or yaw
            front.X = (float)Math.Cos(pitch) * (float)Math.Cos(yaw);
            front.Y = (float)Math.Sin(pitch);
            front.Z = (float)Math.Cos(pitch) * (float)Math.Sin(yaw);

            // normalize the front vector
            front = Vector3.Normalize(front);

            // recalculate up and right vector using cross product
            right = Vector3.Normalize(Vector3.Cross(front, Vector3.UnitY));
            up = Vector3.Normalize(Vector3.Cross(right, front));
        }
    }
}