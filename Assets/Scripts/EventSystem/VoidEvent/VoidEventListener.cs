using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    [SerializeField] private VoidEventPublisher publisher;
    [SerializeField] private UnityEvent responses;
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

    private void Respond()
    {
        responses?.Invoke();
    }
}
