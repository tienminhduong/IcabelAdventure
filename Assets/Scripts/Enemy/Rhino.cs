using UnityEngine;

public class Rhino : Enemy
{
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
        if (collision.gameObject.CompareTag(ConstValue.PLAYER_TAG))
        {
            Attack(collision.gameObject);
        }
    }
}
