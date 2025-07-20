using UnityEngine;

public class SpikeBall : PooledObject, IPlayerCollidable
{
    [SerializeField] private float damage = 5f;
    public void OnCollisionWithPlayer(Player player)
    {
        player.TakeDamage(damage);
        ObjectPoolManager.ReturnToPool(gameObject);
    }
}
