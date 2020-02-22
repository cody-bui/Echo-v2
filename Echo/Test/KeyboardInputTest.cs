using Echo.Input;
using OpenTK.Input;
using System;
using System.Collections.Generic;

namespace Echo.Test
{
    public class KeyboardInputTest
    {
        private InputLayer input;
        private Input.Input layer1;
        private Input.Input layer2;

        public KeyboardInputTest()
        {
            input = new InputLayer();

            layer1 = new Input.Input();
            layer1.AddKeyboard();
            layer1.Keyboard.KeyboardEventHandler += Layer1Test;

            layer2 = new Input.Input();
            layer2.AddKeyboard();
            layer2.Keyboard.KeyboardEventHandler += Layer2Test;

            input.Add("layer 1", layer1);
            input.Add("layer 2", layer2);
        }

        public void Layer1Test(object sender, List<Key> e)
        {
            Console.Write("layer 1: ");
            for (int i = 0; i < e.Count; i++)
                Console.Write($"{e[i]} ");
            Console.WriteLine("");
        }

        public void Layer2Test(object sender, List<Key> e)
        {
            Console.Write("layer 2: ");
            for (int i = 0; i < e.Count; i++)
                Console.Write($"{e[i]} ");
            Console.WriteLine("");
        }
    }
}