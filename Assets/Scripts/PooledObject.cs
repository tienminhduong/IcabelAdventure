using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private float baseSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;

    public virtual float Speed => baseSpeed;
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

    public void SetSpeed(float speed)
    {
        this.baseSpeed = speed;
    }

    public virtual void ResetObject()
    {
        Debug.Log($"Resetting object {gameObject.name}");
    }
}
