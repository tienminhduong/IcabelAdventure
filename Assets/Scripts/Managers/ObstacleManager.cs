using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private PooledObject[] obstaclePrefabs;

    /// <summary>
    /// Obstacle spawning mechanic is the same as fruit spawning.
    /// </summary>
    [SerializeField] private bool enableObstacleSpawning = false;
    private float distanceCountdown;
    [SerializeField] private float distanceToSpawnObstacle;

    void Update()
    {
        distanceCountdown -= GameManager.Instance.GameSpeed * Time.deltaTime;
        if (distanceCountdown <= 0)
        {
            distanceCountdown = distanceToSpawnObstacle;
            enableObstacleSpawning = Random.Range(0f, 1f) < 0.5f;
        }
        if (enableObstacleSpawning)
        {
            SpawnObstacle();
            enableObstacleSpawning = false;
        }
    }

    private void SpawnObstacle()
    {
        int rIndex = Random.Range(0, obstaclePrefabs.Length);
        ObjectPoolManager.SpawnObject(obstaclePrefabs[rIndex], transform.position, Quaternion.identity);
    }
}
