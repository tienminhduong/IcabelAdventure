using UnityEngine;

public class Enemy : PooledObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        // Additional enemy-specific behavior can be added here
    }
}
