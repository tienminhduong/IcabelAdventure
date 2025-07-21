using UnityEngine;

public class Fruit : PooledObject, IPlayerTriggerCollidable
{
    [SerializeField] private FruitData fruitData;
    public FruitData FruitData => fruitData;

    protected override void Start()
    {
        base.Start();
        var animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = fruitData.animationController;
    }

    public void OnTriggerCollisionWithPlayer(Player player)
    {
        player.AddFruitItem(this);
        ObjectPoolManager.ReturnToPool(this.gameObject);
    }
}
