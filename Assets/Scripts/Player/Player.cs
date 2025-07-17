using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpHeight;

    [SerializeField] private float jumpGravityScale = 5f;
    [SerializeField] private float fallGravityScale = 15f;

    [SerializeField] private int weight;
    [SerializeField] private int maxWeight;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
