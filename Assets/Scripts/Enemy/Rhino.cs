using UnityEngine;

public class Rhino : Enemy, IPlayerTriggerCollidable
{
    [SerializeField] float damage;

    public void OnTriggerCollisionWithPlayer(Player player)
    {
        player.TakeDamage(damage);
    }
}
