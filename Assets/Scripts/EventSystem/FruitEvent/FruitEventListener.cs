using UnityEngine;
using UnityEngine.Events;

public class FruitEventListener : MonoBehaviour
{
    [SerializeField] private FruitEventPublisher publisher;
    [SerializeField] private UnityEvent<Fruit> responses;
    private void OnEnable()
    {
        if (publisher != null)
        {
            publisher.ListenEvent(Respond);
        }
    }

    private void OnDisable()
    {
        if (publisher != null)
        {
            publisher.UnlistenEvent(Respond);
        }
    }

    private void Respond(Fruit fruit)
    {
        responses?.Invoke(fruit);
    }
}
