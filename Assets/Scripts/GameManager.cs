using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    [SerializeField] private float gameSpeed;
    [SerializeField] private float maxGameSpeed;
    [SerializeField] private Transform playerCenterTransform;

    [SerializeField] private Player player;

    public float GameSpeed => Mathf.Min(gameSpeed + player.TotalCollected / 100, maxGameSpeed);
    public Vector3 PlayerCenterPosition => playerCenterTransform.position;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
