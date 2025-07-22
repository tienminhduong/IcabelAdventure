using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "VoidEventPublisher", menuName = "Scriptable Objects/Event System/VoidEventPublisher")]
public class VoidEventPublisher : ScriptableObject
{
    public UnityAction OnEventRaise;
    public void ListenEvent(UnityAction action)
    {
        OnEventRaise += action;
    }

    public void UnlistenEvent(UnityAction action)
    {
        OnEventRaise -= action;
    }

    public void RaiseEvent()
    {
        OnEventRaise?.Invoke();
    }
}
