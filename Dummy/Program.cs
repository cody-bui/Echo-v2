using Echo;

namespace Dummy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (GameLoop game = new GameLoop(800, 450, "Echo") { engine = new Engine() })
            {
                game.Run();
            }
        }
    }
}