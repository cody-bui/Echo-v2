﻿using Echo;
using Dummy.Test;
using Echo.Graphics;
using OpenTK.Graphics.OpenGL4;
using Echo.Input;
using Echo.Graphics.Camera;

namespace Dummy
{
    public class Engine : EchoEngine
    {
        SimpleRenderTest srt = new SimpleRenderTest();

        public override void OnLoad(in Game game)
        {
            srt.OnLoad(game);
        }

        public override void OnRender(in Game game)
        {
            srt.OnRender(game);
        }

        public override void OnUpdate(in Game game)
        {
        }

        public override void OnUnload(in Game game)
        {
            srt.OnUnload(game);
        }
    }
}