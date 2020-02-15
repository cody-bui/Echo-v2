namespace Dummy
{
    public class Game : EchoCore.Game
    {
        public Game(int width, int height, string title) : base(width, height, title)
        {
            engine = new Engine();
        }
    }
}