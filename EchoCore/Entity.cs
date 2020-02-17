namespace EchoCore
{
    public abstract class Entity
    {
        public int Id { get; private set; }

        protected Entity(int id)
        {
            Id = id;
        }
    }
}