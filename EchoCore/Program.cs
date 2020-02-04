namespace EchoCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(1280, 720, "Echo"))
            {
                game.Run(120.0);
            }
        }
    }
}
