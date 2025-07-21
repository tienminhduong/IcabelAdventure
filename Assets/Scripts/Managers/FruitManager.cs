using System.Collections;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] private Fruit[] fruitPrefabs;

    [SerializeField] private bool enableFruitSpawning = false;

    /// <summary>
    /// Explain about the spawn fruit mechanic.
    /// After player has moved a certain distance, in this case distanceToSpawnFruit, a random 50/50 will be rolled
    /// If the roll is successful, a fruit will be spawned.
    /// </summary>
    private float distanceCountdown;
    [SerializeField] private float distanceToSpawnFruit;

    void Update()
    {
        distanceCountdown -= GameManager.Instance.GameSpeed * Time.deltaTime;
        if (distanceCountdown <= 0)
        {
            distanceCountdown = distanceToSpawnFruit;
            enableFruitSpawning = Random.Range(0f, 1f) < 0.5f;
        }
        if (enableFruitSpawning)
        {
            SpawnFruit();
            enableFruitSpawning = false;
        }
    }

    private void SpawnFruit()
    {
        int rIndex = Random.Range(0, fruitPrefabs.Length);
        ObjectPoolManager.SpawnObject(fruitPrefabs[rIndex], transform.position, Quaternion.identity);
    }
}
