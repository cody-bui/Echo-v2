using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Echo.Event
{
    public static class EventManager
    {
        /// <summary>
        /// delegates
        /// </summary>
        public static EventHandlerList EventHandlers { get; set; }

        static EventManager()
        {
            EventHandlers = new EventHandlerList();
        }

        /// <summary>
        /// all keys
        /// </summary>
        private static Dictionary<string, object> eventHandlerKeys = new Dictionary<string, object>();

        public static object AddKey(in string key)
        {
            if (eventHandlerKeys.ContainsKey(key))
            {
                object keyObject = new object();
                eventHandlerKeys.Add(key, keyObject);
                return keyObject;
            }
            else
            {
                Log.Warning($"key {key} already exist");
                return default;
            }
        }

        public static void RemoveKey(in string key)
        {
            if (eventHandlerKeys.ContainsKey(key))
                eventHandlerKeys.Remove(key);
            else
                Log.Warning($"key {key} not found");
        }

        public static object GetKey(in string key)
        {
            if (eventHandlerKeys.ContainsKey(key))
            {
                return eventHandlerKeys[key];
            }
            else
            {
                Log.Warning($"key {key} not found");
                return default;
            }
        }
    }
}