using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private bool isAddedToDontDestroyOnLoad = false;

    [SerializeField] private static GameObject gameObjectPoolHolder;

    private static Dictionary<GameObject, ObjectPool<GameObject>> objectPools;
    private static Dictionary<GameObject, GameObject> cloneToPrefabMap;

    private void Awake()
    {
        objectPools ??= new Dictionary<GameObject, ObjectPool<GameObject>>();
        cloneToPrefabMap ??= new Dictionary<GameObject, GameObject>();

        SetupHolder();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum PoolType
    {
        GameObject
    }

    private void SetupHolder()
    {
        gameObjectPoolHolder = new GameObject("GameObjects");
        gameObjectPoolHolder.transform.SetParent(transform);

        if (isAddedToDontDestroyOnLoad)
            DontDestroyOnLoad(gameObjectPoolHolder.transform.root);
    }

    private static void CreatePool(
        GameObject prefab,
        Vector3 position,
        Quaternion rotation,
        PoolType poolType = PoolType.GameObject)
    {
        ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
            createFunc: () => CreateObject(prefab, position, rotation, poolType),
            actionOnGet: OnGetObject,
            actionOnRelease: OnReleaseObject,
            actionOnDestroy: OnDestroyObject
            );

        objectPools.Add(prefab, pool);
    }

    private static GameObject CreateObject(
        GameObject prefab,
        Vector3 position,
        Quaternion rotation,
        PoolType poolType = PoolType.GameObject
        )
    {
        prefab.SetActive(false);
        GameObject obj = Instantiate(prefab, position, rotation);
        prefab.SetActive(true);

        var parentObj = GetParentObject(poolType);
        obj.transform.parent = parentObj.transform;

        return obj;
    }

    private static GameObject GetParentObject(PoolType poolType)
    {
        switch(poolType)
        {
            case PoolType.GameObject:
                return gameObjectPoolHolder;
            default:
                return null;
        }
    }

    private static void OnGetObject(GameObject obj)
    {
        if (!obj.TryGetComponent<PooledObject>(out var pooledObject))
        {
            Debug.LogWarning($"Object {obj.name} is not a PooledObject.");
        }
        else
        {
            pooledObject.ResetObject();
        }
    }

    private static void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    private static void OnDestroyObject(GameObject obj)
    {
        if (cloneToPrefabMap.ContainsKey(obj))
            cloneToPrefabMap.Remove(obj);
    }

    private static T SpawnObject<T>(
        GameObject objectToSpawm,
        Vector3 spawnPosition,
        Quaternion spawnRotation,
        PoolType poolType = PoolType.GameObject) where T : Object
    {
        if (!objectPools.ContainsKey(objectToSpawm))
            CreatePool(objectToSpawm, spawnPosition, spawnRotation, poolType);

        GameObject obj = objectPools[objectToSpawm].Get();

        if (obj != null)
        {
            if (!cloneToPrefabMap.ContainsKey(obj))
            {
                cloneToPrefabMap.Add(obj, objectToSpawm);
            }

            obj.transform.SetPositionAndRotation(spawnPosition, spawnRotation);
            obj.SetActive(true);

            if (typeof(T) == typeof(GameObject))
                return obj as T;

            T component = obj.GetComponent<T>();
            if (component == null)
            {
                Debug.LogError($"Object {objectToSpawm.name} doesn't have component of type {typeof(T)}");
                return null;
            }

            return component;
        }

        return null;
    }

    public static T SpawnObject<T>(
        T typePrefab,
        Vector3 spawnPosition,
        Quaternion spawnRotation,
        PoolType poolType = PoolType.GameObject) where T : Component
    {
        return SpawnObject<T>(typePrefab.gameObject, spawnPosition, spawnRotation, poolType);
    }

    public static GameObject SpawnObject(
        GameObject objectToSpawm,
        Vector3 spawnPosition,
        Quaternion spawnRotation,
        PoolType poolType = PoolType.GameObject
        )
    {
        return SpawnObject<GameObject>(objectToSpawm, spawnPosition, spawnRotation, poolType);
    }

    public static void ReturnToPool(GameObject obj, PoolType poolType = PoolType.GameObject)
    {
        if (cloneToPrefabMap.TryGetValue(obj, out GameObject prefab))
        {
            GameObject parentObj = GetParentObject(poolType);

            if (obj.transform.parent != parentObj.transform)
                obj.transform.SetParent(parentObj.transform);

            if (objectPools.TryGetValue(prefab, out ObjectPool<GameObject> pool))
                pool.Release(obj);
        }
        else
            Debug.LogWarning("Trying to return an object that is not pooled: " + obj.name);
    }
}
