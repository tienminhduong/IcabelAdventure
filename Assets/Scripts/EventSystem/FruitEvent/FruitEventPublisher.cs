using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FruitEventPublisher", menuName = "Scriptable Objects/Event System/FruitEventPublisher")]
public class FruitEventPublisher : ScriptableObject
{
    public UnityAction<Fruit> OnEventRaise;
    public void ListenEvent(UnityAction<Fruit> action)
    {
        OnEventRaise += action;
    }

    public void UnlistenEvent(UnityAction<Fruit> action)
    {
        OnEventRaise -= action;
    }

    public void RaiseEvent(Fruit fruit)
    {
        OnEventRaise?.Invoke(fruit);
    }
}
