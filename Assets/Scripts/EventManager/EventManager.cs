using System.Collections.Generic;
using UnityEngine.Events;

public class EventAction : UnityEvent<object> { }
public static class EventManager
{
    private static Dictionary<eEventType, EventAction> eventDictionary = new Dictionary<eEventType , EventAction>();

    public static void OnEvent(eEventType eventType, object o) {
        EventAction eventData = new EventAction();
        if (eventDictionary.TryGetValue(eventType, out eventData))
        {
            eventData?.Invoke(o);
        }
    }
    public static void Subscribe(eEventType eventType, UnityAction<object> action)
    {
        EventAction eventData = new EventAction();
        if (eventDictionary.TryGetValue(eventType, out eventData))
        {
            eventData.AddListener(action);
        }
        else {
            eventData = new EventAction();
            eventData.AddListener(action);
            eventDictionary.Add(eventType, eventData);
        }
    }

    public static void Unsubscribe(eEventType eventType, UnityAction<object> action) {

        EventAction eventData = new EventAction();
        if (eventDictionary.TryGetValue(eventType, out eventData))
        {
            eventData.RemoveListener(action);
        }
    }
}
