using Dummy.Entities;
using System;
using System.Collections.Generic;

namespace Echo.Test
{
    public static class EntityComponentSystemTest
    {
        /// <summary>
        /// EntityComponentManagerTest will creates 3 components, print their id
        /// remove one entity then check to see if its components are also destroyed
        /// </summary>
        public static void ECMTest()
        {
            Player p1 = EntityManager<Player>.Add();
            Player p2 = EntityManager<Player>.Add();
            Player p3 = EntityManager<Player>.Add();

            IEnumerable<Player> players = EntityManager<Player>.EntityIterator();
            foreach (Player p in players)
                Console.WriteLine("id " + p.Id);

            // note: CM<T>.components has been made private, so it's no longer accessible
            //Console.WriteLine("count " + ComponentManager<TransformComponent>.components[typeof(Player)].Count);
            //Console.WriteLine("count " + ComponentManager<HealthComponent>.components[typeof(Player)].Count);

            EntityManager<Player>.Remove(p2.Id);

            players = EntityManager<Player>.EntityIterator();
            foreach (Player p in players)
                Console.WriteLine("id " + p.Id);

            Console.WriteLine(p2.Id);

            //Console.WriteLine("count " + ComponentManager<TransformComponent>.components[typeof(Player)].Count);
            //Console.WriteLine("count " + ComponentManager<HealthComponent>.components[typeof(Player)].Count);
        }
    }
}