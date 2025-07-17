using UnityEngine;

public class Bee : Enemy, IPlayerTriggerCollidable
{
    private void AttackPlayer(Player player)
    {
        player.KnockOut();
    }

    public void OnTriggerCollisionWithPlayer(Player player)
    {
        AttackPlayer(player);
    }
}
