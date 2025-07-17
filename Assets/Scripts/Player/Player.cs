using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpHeight;

    [SerializeField] private float jumpGravityScale = 5f;
    [SerializeField] private float fallGravityScale = 15f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.gravityScale = jumpGravityScale;
            float jumpForce = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y * rb.gravityScale)) * rb.mass;
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        else if (context.canceled)
        {
            rb.gravityScale = fallGravityScale;
        }
    }
}
