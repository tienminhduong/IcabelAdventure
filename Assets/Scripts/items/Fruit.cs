using UnityEngine;

public class Fruit : PooledObject, IPlayerTriggerCollidable
{
    [SerializeField] private FruitData fruitData;

    protected override void Start()
    {
        base.Start();
        var animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = fruitData.animationController;
    }

    public void OnTriggerCollisionWithPlayer(Player player)
    {
        // add weight to player
        player.AddWeight(fruitData.weight);
        // return to pool
        ObjectPoolManager.ReturnToPool(this.gameObject);
    }
}
