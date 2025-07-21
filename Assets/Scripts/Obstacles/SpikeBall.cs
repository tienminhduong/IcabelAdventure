using UnityEngine;

public class SpikeBall : Enemy, IPlayerTriggerCollidable
{
    [SerializeField] private float damage = 5f;

    public void OnTriggerCollisionWithPlayer(Player player)
    {
        player.TakeDamage(damage);
        ObjectPoolManager.ReturnToPool(gameObject);
    }
}
