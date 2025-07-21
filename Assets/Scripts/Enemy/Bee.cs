using UnityEngine;

public class Bee : Enemy, IPlayerTriggerCollidable
{

    public void OnTriggerCollisionWithPlayer(Player player)
    {
        player.TakeDamage(0);
    }
}
