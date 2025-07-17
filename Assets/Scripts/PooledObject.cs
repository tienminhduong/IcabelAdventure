using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public virtual float Speed => GameManager.Instance.GameSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += Speed * Time.deltaTime * Vector3.left;
    }

    public void ReturnPool()
    {
        ObjectPoolManager.ReturnToPool(gameObject);
    }

    public virtual void ResetObject()
    {
        Debug.Log($"Resetting object {gameObject.name}");
    }
}
