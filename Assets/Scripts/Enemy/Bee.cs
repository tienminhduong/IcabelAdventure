using UnityEngine;

public class Bee : Enemy
{
    protected override void Attack(GameObject gameObject)
    {
        playerTest player = gameObject.GetComponent<playerTest>();
        if (player != null && player.IsAlive())
        {
            player.KnockOut();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(ConstValue.PLAYER_TAG))
        {
            Attack(collision.gameObject);
        }
    }
}
