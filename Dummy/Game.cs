﻿using EchoCore;
using EchoCore.Input;
using System;

namespace Dummy
{
    public class Game : Engine
    {
        public Game(int width, int height, string title) : base(width, height, title)
        {
            Log.Info(Loader.EngineDir);
        }

        Input input = new Input();

        protected override void OnLoad(EventArgs e)
        {
            input.OnLoad(this);
            base.OnLoad(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            input.OnUnload(this);
            base.OnUnload(e);
        }
    }
}