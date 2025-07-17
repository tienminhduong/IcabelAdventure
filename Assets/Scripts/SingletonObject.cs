using UnityEngine;

public class SingletonObject<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual bool IsDontDestroyOnLoad => false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this as T;
        if (IsDontDestroyOnLoad)
            DontDestroyOnLoad(gameObject);
    }
}
