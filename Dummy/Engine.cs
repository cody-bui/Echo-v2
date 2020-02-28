using System;
using System.Collections.Generic;
using Dummy.Components;
using Dummy.Entities;
using Dummy.System;
using Echo;

namespace Dummy
{
    public class Engine : EchoEngine
    {
        public override void OnLoad(in GameLoop game)
        {
            Player p1 = EntityManager<Player>.Add();
            Player p2 = EntityManager<Player>.Add();
            Player p3 = EntityManager<Player>.Add();

            IEnumerable<Player> players = EntityManager<Player>.EntityIterator();
            foreach (Player p in players)
                Console.WriteLine("id " + p.Id);

            Console.WriteLine("count " + ComponentManager<TransformComponent>.components[typeof(Player)].Count);
            Console.WriteLine("count " + ComponentManager<HealthComponent>.components[typeof(Player)].Count);

            EntityManager<Player>.Remove(p2.Id);

            players = EntityManager<Player>.EntityIterator();
            foreach (Player p in players)
                Console.WriteLine("id " + p.Id);

            Console.WriteLine(p2.Id);

            Console.WriteLine("count " + ComponentManager<TransformComponent>.components[typeof(Player)].Count);
            Console.WriteLine("count " + ComponentManager<HealthComponent>.components[typeof(Player)].Count);
        }

        public override void OnRenderFrame(in GameLoop game)
        {
        }

        public override void OnUnload(in GameLoop game)
        {
        }

        public override void OnUpdateFrame(in GameLoop game)
        {
        }
    }
}
