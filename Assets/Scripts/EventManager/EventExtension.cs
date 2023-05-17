using UnityEngine;
using UnityEngine.Events;

public static class EventExtension
{

    public static void Subscribe(this Component component, eEventType eventType, UnityAction<object> action)
    {
        EventManager.Subscribe(eventType, action);
    }

    public static void Unsubscribe(this Component component, eEventType eventType, UnityAction<object> action)
    {
        EventManager.Unsubscribe(eventType, action);
    }
    public static void OnEvent(this Component component, eEventType eventType, object o = null)
    {
        EventManager.OnEvent(eventType, o);
    }
        
}
