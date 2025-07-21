using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] private Fruit[] fruitPrefabs;

    [SerializeField] private bool enableFruitSpawning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
