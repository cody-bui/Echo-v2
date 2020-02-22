using System.ComponentModel;

namespace Echo.Event
{
    internal class EventManager
    {
        public EventHandlerList eventHandlers = new EventHandlerList();
    }
}