using Echo;

namespace Dummy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (Game game = new Game(1600, 900, "Echo") { engine = new Engine() })
            {
                game.Run();
            }
        }
    }
}