using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    [SerializeField] private float gameSpeed;
    [SerializeField] private Transform playerCenterTransform;

    public float GameSpeed => gameSpeed;
    public Vector3 PlayerCenterPosition => playerCenterTransform.position;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
