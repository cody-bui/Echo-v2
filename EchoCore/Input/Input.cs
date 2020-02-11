using System;

namespace EchoCore.Input
{
    static public class Input
    {
        /// <summary>
        /// load input elements, call in GL.OnLoad
        /// </summary>
        /// <param name="game">pointer to game program</param>
        static public void OnLoad(Game game)
        {
            game.KeyDown += Keyboard.OnKeyDown;
            game.KeyUp += Keyboard.OnKeyUp;
        }

        /// <summary>
        /// update all input elements, call in GL.OnUpdateFrame
        /// </summary>
        static public void OnUpdate()
        {
            Keyboard.OnUpdate();
        }

        /// <summary>
        /// unload input element, call in GL.Unload
        /// </summary>
        /// <param name="game"></param>
        static public void OnUnload(Game game)
        {
            game.KeyDown -= Keyboard.OnKeyDown;
            game.KeyUp -= Keyboard.OnKeyUp;
        }
    }
}
