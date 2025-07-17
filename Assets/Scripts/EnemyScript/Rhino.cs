using UnityEngine;

public class Rhino : Enemy
{
    const string playerTag = "Player";
    [SerializeField] float damage;
    protected override void Attack(GameObject gameObject)
    {
        playerTest player = gameObject.GetComponent<playerTest>();
        if(player != null && player.IsAlive())
        {
            player.DecreaseHp(damage);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Attack(collision.gameObject);
        }
    }
}
