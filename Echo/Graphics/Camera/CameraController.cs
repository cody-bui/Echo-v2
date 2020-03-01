using Newtonsoft.Json.Linq;
using Echo.Input;
using OpenTK.Input;
using System.Collections.Generic;
using OpenTK;

namespace Echo.Graphics.Camera
{
    public class CameraController
    {
        private Shader shader;
        private Model model = new Model();
        private View view = new View();
        private Matrix4 mvp = new Matrix4();

        private Projection proj = new Projection(Projection.ProjectionMode.Orthographic, 1600, 900, 0);

        private Key MoveUpKey;
        private Key MoveDownKey;
        private Key MoveLeftKey;
        private Key MoveRightKey;
        private Key ZoomOutKey;
        private Key ZoomInKey;

        private Vector3 coord = new Vector3(0.0f);

        public CameraController(in Shader shader)
        {
            this.shader = shader;
            KeyMapping.UpdateKeyMappingEventHandler += SetKeyMapping;
        }

        ~CameraController()
        {
            KeyMapping.UpdateKeyMappingEventHandler -= SetKeyMapping;
        }

        public void SetKeyMapping(object sender, Dictionary<string, Key> e)
        {
            MoveUpKey = e["Move Up"];
            MoveDownKey = e["Move Down"];
            MoveLeftKey = e["Move Left"];
            MoveRightKey = e["Move Right"];
            ZoomOutKey = e["Zoom Out"];
            ZoomInKey = e["Zoom In"];
        }

        public void KeyControl(object sender, KeysEventArgs e)
        {
            if (e.ContainsKey(MoveUpKey))
                coord.Y += 0.001f;
            if (e.ContainsKey(MoveDownKey))
                coord.Y -= 0.001f;
            if (e.ContainsKey(MoveLeftKey))
                coord.X -= 0.001f;
            if (e.ContainsKey(MoveRightKey))
                coord.X += 0.001f;
            if (e.ContainsKey(ZoomInKey))
                coord.Z += 0.001f;
            if (e.ContainsKey(ZoomOutKey))
                coord.Z -= 0.001f;

            view.Translate(coord.X, coord.Y, coord.Z);
            mvp = proj.Mat * view.Mat * model.Mat;
            shader.SetUniform("mvp", ref mvp);
        }
    }
}