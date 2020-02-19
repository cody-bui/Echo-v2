using OpenTK.Input;
using System;
using System.Collections.Generic;

namespace EchoCore.Input
{
    public class Input
    {
        private KeyboardInput kb;
        private MouseInput mouse;

        /// <summary>
        /// load input elements, call in GL.OnLoad
        /// </summary>
        /// <param name="game">pointer to game program</param>
        public void OnLoad(Engine game)
        {
            // keyboard
            kb = new KeyboardInput();
            game.KeyDown += kb.OnKeyDown;
            game.KeyUp += kb.OnKeyUp;
            game.KeyPress += kb.OnKeyPress;

            // mouse
            mouse = new MouseInput();
            game.MouseMove += mouse.OnMouseMove;
            game.MouseDown += mouse.OnMouseDown;
            game.MouseUp += mouse.OnMouseUp;
            game.MouseWheel += mouse.OnMouseWheel;

            //kb.KeyboardEventHandler += TestKeyInput;
        }

        /// <summary>
        /// unload input element, call in GL.Unload
        /// </summary>
        /// <param name="game"></param>
        public void OnUnload(Engine game)
        {
            // keyboard
            game.KeyDown -= kb.OnKeyDown;
            game.KeyUp -= kb.OnKeyUp;

            // mouse
            game.MouseMove -= mouse.OnMouseMove;
            game.MouseDown -= mouse.OnMouseDown;
            game.MouseUp -= mouse.OnMouseUp;
            game.MouseWheel -= mouse.OnMouseWheel;
        }

        public void TestKeyInput(object sender, List<Key> e)
        {
            for (int i = 0; i < e.Count; i++)
                Console.Write(e[i] + " ");
            Console.WriteLine(e.Count);
        }
    }
}