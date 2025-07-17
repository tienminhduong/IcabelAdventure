using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }

    public virtual void ResetObject()
    {
        Debug.Log($"Resetting object {gameObject.name}");
    }
}
