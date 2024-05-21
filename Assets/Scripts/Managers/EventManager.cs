using System.Collections.Generic;
using System;

namespace PersonalLibrary.Utilities
{
    /// <summary>
    /// EventManager manages publishing raised events to subscribing/listening classes.
    ///
    /// @example subscribe
    ///     EventManager.Instance.AddListener<SomethingHappenedEvent>(OnSomethingHappened);
    ///
    /// @example unsubscribe
    ///     EventManager.Instance.RemoveListener<SomethingHappenedEvent>(OnSomethingHappened);
    ///
    /// @example publish an event
    ///     EventManager.Instance.Raise(new SomethingHappenedEvent() { parametersIfAny_1 = valueInt, paramIfAny_2 = valueString, ... });
    /// </summary>
    public class EventManager : Singleton<EventManager>
    {
        public delegate void EventDelegate<T>(T e) where T : CustomEvent;
        private delegate void EventDelegate(CustomEvent e);

        /// <summary>
        /// The actual delegate, there is one delegate per unique event. Each
        /// delegate has multiple invocation list items.
        /// </summary>
        private static Dictionary<Type, EventDelegate> delegates = new Dictionary<Type, EventDelegate>();

        /// <summary>
        /// Lookups only, there is one delegate lookup per listener.
        /// </summary>
        private static Dictionary<Delegate, EventDelegate> delegateLookup = new Dictionary<Delegate, EventDelegate>();

        /// <summary>
        /// Add the delegate.
        /// </summary>
        public static void AddListener<T>(EventDelegate<T> del) where T : CustomEvent
        {
            if (delegateLookup.ContainsKey(del))
            {
                return;
            }

            // Create a new non-generic delegate which calls our generic one. This
            // is the delegate we actually invoke.
            EventDelegate internalDelegate = (e) => del((T)e);
            delegateLookup[del] = internalDelegate;

            if (delegates.TryGetValue(typeof(T), out EventDelegate tempDelegate))
            {
                delegates[typeof(T)] = tempDelegate += internalDelegate;
            }
            else
            {
                delegates[typeof(T)] = internalDelegate;
            }
        }

        /// <summary>
        /// Remove the delegate. Can be called multiple times on same delegate.
        /// </summary>
        public static void RemoveListener<T>(EventDelegate<T> del) where T : CustomEvent
        {
            if (delegateLookup.TryGetValue(del, out EventDelegate internalDelegate))
            {
                if (delegates.TryGetValue(typeof(T), out EventDelegate tempDelegate))
                {
                    tempDelegate -= internalDelegate;
                    if (tempDelegate == null)
                    {
                        delegates.Remove(typeof(T));
                    }
                    else
                    {
                        delegates[typeof(T)] = tempDelegate;
                    }
                }

                delegateLookup.Remove(del);
            }
        }

        /// <summary>
        /// The count of delegate lookups. The delegate lookups will increase by
        /// one for each unique AddListener. Useful for debugging and not much else.
        /// </summary>
        public static int DelegateLookupCount { get { return delegateLookup.Count; } }

        /// <summary>
        /// Raise the event to all the listeners.
        /// </summary>
        public static void Raise(CustomEvent customEvent)
        {
            if (delegates.TryGetValue(customEvent.GetType(), out EventDelegate eventDelegate))
            {
                eventDelegate.Invoke(customEvent);
            }
        }
    }

    // Base class CustomEvent.
    public class CustomEvent { }
}
