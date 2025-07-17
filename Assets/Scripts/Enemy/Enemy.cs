using UnityEngine;

public class Enemy : PooledObject
{
    private Animator animator;
    [SerializeField] private float enemySpeed;
    public override float Speed => base.Speed + enemySpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //UpdateAminationSpeed();
    }   

    //private void UpdateAminationSpeed()
    //{
    //    animator.speed = speed / maxSpeed;
    //}    
}
