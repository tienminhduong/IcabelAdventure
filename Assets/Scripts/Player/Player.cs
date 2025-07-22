using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpHeight;

    [SerializeField] private float jumpGravityScale = 5f;
    [SerializeField] private float fallGravityScale = 15f;

    [SerializeField] private float totalPoint = 0;
    [SerializeField] private Animator animator;
    public float TotalPoint => totalPoint;

    [SerializeField] private float weight;
    [SerializeField] private FruitEventPublisher collectFruitPublisher;
    [SerializeField] private FruitEventPublisher throwRandomFruitPublisher;
    [SerializeField] private VoidEventPublisher endgamePublisher;

    [SerializeField] private bool isOnGround = false;

    private Rigidbody2D rigidBody;

    private List<Fruit> collectedFruit = new();

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CenterPlayer();
    }

    public void JumpAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            float height = jumpHeight / (1f + 0.005f * weight);
            Debug.Log(height);
            rigidBody.gravityScale = jumpGravityScale;
            float jumpForce = Mathf.Sqrt(2 * height * Mathf.Abs(Physics2D.gravity.y * rigidBody.gravityScale)) * rigidBody.mass;
            rigidBody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        if (context.canceled)
        {
            rigidBody.gravityScale = fallGravityScale;
        }
    }

    public void OnJumpButtonPressed()
    {
        if (!isOnGround)
            return;

        float height = jumpHeight / (1f + 0.01f * weight);
        Debug.Log(height);
        rigidBody.linearVelocity = Vector2.zero;
        rigidBody.gravityScale = jumpGravityScale;
        float jumpForce = Mathf.Sqrt(2 * height * Mathf.Abs(Physics2D.gravity.y * rigidBody.gravityScale)) * rigidBody.mass;
        rigidBody.AddForce(jumpForce * (new Vector2(0.5f, 9f)).normalized, ForceMode2D.Impulse);
        isOnGround = false;
        animator.SetTrigger("JumpTrigger");
        SFXManager.Instance.PlaySFX(SFXManager.SFXType.Jump);
    }

    public void OnJumpButtonReleased()
    {
        rigidBody.gravityScale = fallGravityScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPlayerTriggerCollidable collidable))
            collidable.OnTriggerCollisionWithPlayer(this);

        if (collision.gameObject.CompareTag(ConstValue.BARRIER_TAG))
        {
            endgamePublisher.RaiseEvent();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPlayerCollidable collidable))
            collidable.OnCollisionWithPlayer(this);

        if (collision.gameObject.CompareTag(ConstValue.GROUND_TAG))
            isOnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ConstValue.GROUND_TAG))
        {
            isOnGround = false;
        }
    }

    public void TakeDamage(float damage)
    {
        totalPoint -= damage;
        if (totalPoint < 0)
            totalPoint = 0;
        if (weight > 0)
        {
            var firstFruitInList = collectedFruit.FirstOrDefault();
            if (firstFruitInList != null)
                throwRandomFruitPublisher.RaiseEvent(firstFruitInList);

            animator.SetTrigger("AttackedTrigger");
            SFXManager.Instance.PlaySFX(SFXManager.SFXType.Punch);
        }
        else
        {
            KnockOut();
        }
    }

    public void KnockOut()
    {
        endgamePublisher.RaiseEvent();
    }

    public void AddFruitItem(Fruit fruit)
    {
        if (fruit == null) return;
        collectedFruit.Add(fruit);
        weight += fruit.FruitData.weight;
        totalPoint += fruit.FruitData.weight;
        collectFruitPublisher.RaiseEvent(fruit);

        animator.SetTrigger("EatTrigger");
        SFXManager.Instance.PlaySFX(SFXManager.SFXType.Eat);
    }

    public void ThrowFruit(Fruit fruit)
    {
        if (collectedFruit.Contains(fruit))
        {
            collectedFruit.Remove(fruit);
            weight -= fruit.FruitData.weight;
        }
        else
        {
            Debug.LogWarning($"Fruit {fruit.gameObject.name} not found in collected items.");
        }
    }

    private void CenterPlayer()
    {
        if (!isOnGround)
            return;

        if (transform.position.x == GameManager.Instance.PlayerCenterPosition.x)
            return;

        float dX = GameManager.Instance.PlayerCenterPosition.x - transform.position.x;
        rigidBody.linearVelocityX = 2 * dX;
    }
}