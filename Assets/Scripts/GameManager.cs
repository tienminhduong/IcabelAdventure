using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    [SerializeField] private float gameSpeed;

    public float GameSpeed => gameSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
