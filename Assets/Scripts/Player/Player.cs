using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEditor.Rendering;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpHeight;

    [SerializeField] private float jumpGravityScale = 5f;
    [SerializeField] private float fallGravityScale = 15f;

    [SerializeField] private float weight;
    [SerializeField] private FruitEventPublisher collectFruitPublisher;
    [SerializeField] private FruitEventPublisher throwRandomFruitPublisher;

    private Rigidbody2D rigidBody;

    private List<Fruit> collectedFruit = new();

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void JumpAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            float height = jumpHeight / (1f + 0.0005f * weight);
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
        float height = jumpHeight / (1f + 0.0005f * weight);
        Debug.Log(height);
        rigidBody.gravityScale = jumpGravityScale;
        float jumpForce = Mathf.Sqrt(2 * height * Mathf.Abs(Physics2D.gravity.y * rigidBody.gravityScale)) * rigidBody.mass;
        rigidBody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    public void OnJumpButtonReleased()
    {
        rigidBody.gravityScale = fallGravityScale;
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
        if (weight > 0)
        {
            var firstFruitInList = collectedFruit.FirstOrDefault();
            if (firstFruitInList != null)
                throwRandomFruitPublisher.RaiseEvent(firstFruitInList);
        }
        else
        {
            KnockOut();
        }
    }

    public void KnockOut()
    {
        weight = 0;
        Debug.Log("Player knocked out!");
    }

    public void AddWeight(float weight)
    {
        this.weight += weight;
    }

    public void AddFruitItem(Fruit fruit)
    {
        if (fruit == null) return;
        collectedFruit.Add(fruit);
        weight += fruit.FruitData.weight;
        collectFruitPublisher.RaiseEvent(fruit);
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
}