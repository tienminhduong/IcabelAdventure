using UnityEngine;

public class TestObject : PooledObject
{
    float timer = 5;
    private void OnEnable()
    {
        timer = 5;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Destroying object: " + gameObject.name);
            ObjectPoolManager.ReturnToPool(gameObject);
        }
    }
}
