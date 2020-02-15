using System;
using EchoAsset.Entities;

namespace Dummy.Entities
{
    public class Player : IControllable
    {
        public int Id { get; set; }
        
        public Player(int id)
        {
            Id = id;
        }
    }
}
