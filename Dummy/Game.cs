namespace Dummy
{
    public class Game : Echo.Game
    {
        public Game(int width, int height, in string title) : base(width, height, title)
        {
            engine = new Engine();
        }
    }
}