using UnityEngine;

public abstract class Enemy : PooledObject
{
    private Animator animator;
    [SerializeField] protected float maxSpeed;
    [SerializeField] private float acceleration;
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
        // update enemy speed
        UpdateEnemySpeed();
        // update animation speed
        UpdateAminationSpeed();
    }   

    private void UpdateEnemySpeed()
    {
        speed += acceleration * Time.deltaTime;
        speed = (speed > maxSpeed) ? maxSpeed : speed;
    }    

    // Update speed of animtion
    private void UpdateAminationSpeed()
    {
        animator.speed = speed / maxSpeed;
    }    

    // attack
    protected abstract void Attack(GameObject gameObject);
}
