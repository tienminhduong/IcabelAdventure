using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PooledObject : MonoBehaviour
{
    protected BoxCollider2D boxCollider;

    public virtual float Speed => GameManager.Instance.GameSpeed;
    public virtual float ObjectWidth => boxCollider.size.x;
    public virtual float ObjectHeight => boxCollider.size.y;

    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
            Debug.LogError($"BoxCollider2D not found on {gameObject.name}.");
    }

    protected virtual void Start()
    {
    }

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
