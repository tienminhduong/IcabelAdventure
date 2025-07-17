using UnityEngine;

public abstract class Enemy : PooledObject
{
    private Animator animator;
    //[SerializeField] protected float maxSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        // Additional enemy-specific behavior can be added here
        // update animation speed
        //UpdateAminationSpeed();
    }   

    // Update speed of animtion
    //private void UpdateAminationSpeed()
    //{
    //    animator.speed = speed / maxSpeed;
    //}    

    // attack
    protected abstract void Attack(GameObject gameObject);
}
