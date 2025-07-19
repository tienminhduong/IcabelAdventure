using UnityEngine;

public class BlockingStone : PooledObject
{
    [SerializeField] private float damage = 1;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ConstValue.PLAYER_TAG))
        {
            Player player = collision.gameObject.GetComponent<Player>()!;
            ContactPoint2D[] contactPoints = new ContactPoint2D[collision.contactCount];
            collision.GetContacts(contactPoints);
            foreach (var contact in contactPoints)
            {
                Debug.Log($"Contact normal: {contact.normal.x}");
                if (contact.normal.x > 0.5f)
                    player.TakeDamage(damage);
            }
        }
    }
}
