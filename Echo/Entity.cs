using System;

namespace Echo
{
    public class Entity
    {
        public int Id { get; private set; }
        public Entity(int _id) => Id = _id;
    }
}