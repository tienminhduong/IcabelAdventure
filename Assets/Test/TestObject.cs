using UnityEngine;

public class TestObject : PooledObject
{
    float timer = 5;
    private void OnEnable()
    {
        timer = 5;
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
