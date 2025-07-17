using UnityEngine;

public class Bee : Enemy
{
    const string playerTag = "Player";
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
        if(collision.gameObject.CompareTag(playerTag))
        {
            Attack(collision.gameObject);
        }
    }
}
