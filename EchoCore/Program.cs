﻿namespace EchoCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (Game game = new Game(1280, 720, "Echo"))
            {
                game.Run();
            }
        }
    }
}