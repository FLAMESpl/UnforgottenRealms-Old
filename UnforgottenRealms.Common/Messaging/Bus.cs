using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnforgottenRealms.Common.Messaging
{
    public static class Bus
    {
        public static void Publish<T>(T @event, IEnumerable observers) where T : IEvent
        {
            foreach (var observer in observers.OfType<IEventHandler<T>>().ToList())
                observer.Handle(@event);
        }
    }
}
