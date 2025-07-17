using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpHeight;

    [SerializeField] private float jumpGravityScale = 5f;
    [SerializeField] private float fallGravityScale = 15f;

    [SerializeField] private float weight;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void JumpAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rigidBody.gravityScale = jumpGravityScale;
            float jumpForce = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y * rigidBody.gravityScale)) * rigidBody.mass;
            rigidBody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        if (context.canceled)
        {
            rigidBody.gravityScale = fallGravityScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPlayerTriggerCollidable collidable))
            collidable.OnTriggerCollisionWithPlayer(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPlayerCollidable collidable))
            collidable.OnCollisionWithPlayer(this);
    }

    public void TakeDamage(float damage)
    {
        weight -= damage;
        //if (weight < 0)
        //{
        //    weight = 0;
        //}
    }

    public void KnockOut()
    {
        weight = 0;
        Debug.Log("Player knocked out!");
    }
}
