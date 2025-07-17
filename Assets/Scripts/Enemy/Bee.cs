using UnityEngine;

public class Bee : Enemy, IPlayerTriggerCollidable
{
    protected override void Attack(GameObject gameObject)
    {
        playerTest player = gameObject.GetComponent<playerTest>();
        if (player != null && player.IsAlive())
        {
            player.KnockOut();
        }
    }

    private void AttackPlayer(Player player)
    {
        player.KnockOut();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag(ConstValue.PLAYER_TAG))
    //    {
    //        Attack(collision.gameObject);
    //    }
    //}

    public void OnTriggerCollisionWithPlayer(Player player)
    {
        AttackPlayer(player);
    }
}
