using Echo;

namespace Dummy
{
    /// <summary>
    /// main program
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (Engine game = new Engine(1600, 900, "Dummy App"))
            {
                game.Run();
            }
        }
    }
}