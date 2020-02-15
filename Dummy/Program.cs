using EchoCore;

namespace Dummy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (Game game = new Game(1600, 900, "Dummy App"))
            {
                game.Run();
            }
        }
    }
}